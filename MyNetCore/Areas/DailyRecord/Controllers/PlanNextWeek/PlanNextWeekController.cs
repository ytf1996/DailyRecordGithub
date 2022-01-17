using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class PlanNextWeekController : DailyRecordBaseWithAuthController
    {
        private BusinessPlanNextWeek _businessPlanNextWeek = new BusinessPlanNextWeek();

        /// <summary>
        /// 获取自然周开始时间的工作计划安排
        /// </summary>
        /// <returns></returns>
        public IActionResult List(DateTime begDate)
        {
            _businessPlanNextWeek.CheckDate(begDate);

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            var beflist = _businessPlanNextWeek.GetList(null, out int beftotalCount, x => x.BegDate == begDate && x.CreatedById == currentUser.Id, "ProjectClassificationInfoId");

            var befesult = beflist.ToList();

            //_businessPlanNextWeek.AddDefaultItemWhenNotexist(befesult, begDate);//检查并新增空默认行项

            //var aftlist = _businessPlanNextWeek.GetList(null, out int afttotalCount, x => x.Beg == begDate && x.CreatedById == currentUser.Id, "ProjectClassificationInfoId");

            //var aftresult = aftlist.ToList();

            return Success(data: befesult);
        }


        /// <summary>
        /// 获取自然周开始时间的工作计划安排(管理员)
        /// </summary>
        /// <param name="begDate"></param>
        /// <returns></returns>
        public IActionResult List_ShowAll_ForAdministrator(DateTime begDate)
        {
            _businessPlanNextWeek.CheckDate(begDate);

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }
            if (!currentUser.IsAdmin)
            {
                throw new Exception("您无此操作权限");
            }

            var list = _businessPlanNextWeek.GetList(null, out int totalCount, x => x.BegDate == begDate);

            var result = list.OrderBy(x => x.CreatedById).ThenBy(x => x.ProjectClassificationInfoId).ToList();

            return Success(data: result);
        }


        /// <summary>
        /// 添加工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] PlanDto planDto)
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            _businessPlanNextWeek.CheckDate(planDto.BegDate);

            foreach (var item in planDto.ItemList)
            {
                if (item.ProjectClassificationInfoId == 0)
                {
                    throw new LogicException("项目分类不能为空");
                }
                if (string.IsNullOrWhiteSpace(item.JobContent))
                {
                    throw new LogicException("工作计划安排内容不能为空");
                }

                _businessPlanNextWeek.CheckRepeat(planDto.BegDate, item.ProjectClassificationInfoId, currentUser);
                var pPlanNextWeekInfo = new PlanNextWeekInfo
                {
                    BegDate = planDto.BegDate,
                    ProjectClassificationInfoId = item.ProjectClassificationInfoId,
                    JobContent = item.JobContent
                };

                _businessPlanNextWeek.Add(pPlanNextWeekInfo);
            }
            return Success();
        }


        /// <summary>
        /// 修改工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] List<PlanNextWeekInfo> pPlanNextWeekInfoList)
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            foreach (var pPlanNextWeekInfo in pPlanNextWeekInfoList)
            {
                var pPlanNextWeekInfoDB = _businessPlanNextWeek.GetById(pPlanNextWeekInfo.Id);
                if (pPlanNextWeekInfoDB == null)
                {
                    throw new LogicException($"不存在主键id为{pPlanNextWeekInfo.Id}的下周计划记录");
                }
                if (!currentUser.IsAdmin && pPlanNextWeekInfoDB.CreatedById != currentUser.Id)
                {
                    throw new Exception("非管理员没有权限修改他人的记录");
                }

                _businessPlanNextWeek.CheckDate(pPlanNextWeekInfo.BegDate);

                _businessPlanNextWeek.CheckRepeat(pPlanNextWeekInfo.BegDate, pPlanNextWeekInfo.ProjectClassificationInfoId, currentUser);

                pPlanNextWeekInfoDB.BegDate = pPlanNextWeekInfo.BegDate;
                //pPlanNextWeekInfoDB.ProjectClassificationInfoId = pPlanNextWeekInfo.ProjectClassificationInfoId;
                pPlanNextWeekInfoDB.JobContent = pPlanNextWeekInfo.JobContent;

                //if (pPlanNextWeekInfoDB.BegDate == DateTime.MinValue)
                //{
                //    throw new LogicException("自然周日期不能为空");
                //}
                //if (pPlanNextWeekInfoDB.ProjectClassificationInfoId == 0)
                //{
                //    throw new LogicException("项目分类不能为空");
                //}
                //if (string.IsNullOrWhiteSpace(pPlanNextWeekInfoDB.JobContent))
                //{
                //    throw new LogicException("工作计划安排内容不能为空");
                //}

                _businessPlanNextWeek.Edit(pPlanNextWeekInfoDB);
            }
            return Success();
        }


        /// <summary>
        /// 删除工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] List<int> idList)
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            foreach (var id in idList)
            {
                var pPlanNextWeekInfoDB = _businessPlanNextWeek.GetById(id);
                if (pPlanNextWeekInfoDB == null)
                {
                    throw new LogicException($"不存在主键id为{pPlanNextWeekInfoDB.Id}的下周计划记录");
                }
                if (!currentUser.IsAdmin && pPlanNextWeekInfoDB.CreatedById != currentUser.Id)
                {
                    throw new Exception("非管理员没有权限删除他人的记录");
                }

                _businessPlanNextWeek.Delete(pPlanNextWeekInfoDB);
            }

            return Success();
        }
    }
}
