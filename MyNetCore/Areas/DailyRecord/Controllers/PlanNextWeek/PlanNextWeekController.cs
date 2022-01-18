using MesMessagePlat;
using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class PlanNextWeekController : DailyRecordBaseWithAuthController
    {
        private BusinessPlanNextWeek _businessPlanNextWeek = new BusinessPlanNextWeek();
        private BusinessProjectClassification _businessProjectClassification = new BusinessProjectClassification();


        /// <summary>
        /// 获取自然周开始时间的工作计划安排
        /// </summary>
        /// <returns></returns>
        public IActionResult List(DateTime begDate, DateTime endDate)
        {
            _businessPlanNextWeek.CheckDate(begDate);
            _businessPlanNextWeek.CheckDate(endDate);
            if (begDate > endDate)
            {
                throw new Exception($"开始时间{begDate}大于结束时间{endDate}");
            }

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            PlanShowDto rtnDto = new PlanShowDto();

            var projectList = _businessProjectClassification.GetList(null, out int totalCount, null, "Id");
            rtnDto.WeeklyProjects = projectList.Select(x => new WeeklyProject
            {
                ProjectClassificationInfoId = x.Id.ToString(),
                ClassificationName = x.ClassificationName
            }).ToList();

            DataTable table = new DataTable();

            DataRow firstDr = table.NewRow();
            table.Columns.Add("BegDate", typeof(string));
            //firstDr["BegDate"] = null;
            rtnDto.WeeklyProjects.ForEach(x =>
            {
                table.Columns.Add(x.ProjectClassificationInfoId.ToString(), typeof(string));
                //firstDr[x.ProjectClassificationInfoId.ToString()] = x.ClassificationName;
            });
            //table.Rows.Add(firstDr);

            var dataList = _businessPlanNextWeek.GetList(null, out int beftotalCount, x => x.BegDate >= begDate && x.BegDate <= endDate && x.CreatedById == currentUser.Id).ToList();

            //string 
            for (var dt = begDate; dt <= endDate; dt = dt.AddDays(1))
            {
                var dataList_dt = dataList.Where(x => x.BegDate == dt).ToList();
                if (dataList_dt.Count == 0) continue;
                DataRow dr = table.NewRow();
                dr["BegDate"] = dt;
                rtnDto.WeeklyProjects.ForEach(project =>
                {
                    var pPlanNextWeekInfo = dataList_dt.Where(x => x.ProjectClassificationInfoId.ToString() == project.ProjectClassificationInfoId.ToString()).FirstOrDefault();

                    dr[project.ProjectClassificationInfoId.ToString()] = new CellDto { Id = pPlanNextWeekInfo?.Id, JobContent = pPlanNextWeekInfo?.JobContent };
                });
                table.Rows.Add(dr);
            }
             
            rtnDto.WeeklyData = table;

            return Success(data: rtnDto.ToJsonString());
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
                    throw new LogicException($"不存在主键id为{id}的下周计划记录");
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
