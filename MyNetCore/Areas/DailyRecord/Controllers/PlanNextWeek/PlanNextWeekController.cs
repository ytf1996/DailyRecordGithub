using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class PlanNextWeekController : DailyRecordBaseWithAuthController
    {
        private BusinessPlanNextWeek _businessPlanNextWeek = new BusinessPlanNextWeek();

        /// <summary>
        /// 获取自然周开始时间的工作计划安排
        /// </summary>
        /// <returns></returns>
        public IActionResult List(DateTime beg)
        {
            Expression<Func<PlanNextWeekInfo, bool>> predicate;
            var currentUser = GetCurrentUserInfo();
            if (currentUser != null && currentUser.UserType != UserType.Admin)
            {
                predicate = x => x.Beg == beg && x.CreatedById == currentUser.Id;
            }
            else
            {
                predicate = x => x.Beg == beg;
            }
            var list = _businessPlanNextWeek.GetList(null, out int totalCount, predicate);

            var result = list.ToList();

            return Success(data: result);
        }

        /// <summary>
        /// 添加工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] PlanNextWeekInfo pPlanNextWeekInfo)
        {
            if (pPlanNextWeekInfo.Beg == DateTime.MinValue)
            {
                throw new LogicException("自然周日期不能为空");
            }
            if (pPlanNextWeekInfo.JobClassificationInfoId == 0)
            {
                throw new LogicException("项目分类不能为空");
            }
            if (string.IsNullOrWhiteSpace(pPlanNextWeekInfo.JobContent))
            {
                throw new LogicException("工作计划安排内容不能为空");
            }

            _businessPlanNextWeek.Add(pPlanNextWeekInfo);
            return Success();
        }

        /// <summary>
        /// 获取单条工作计划安排
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(int id)
        {
            var pPlanNextWeekInfo = _businessPlanNextWeek.GetById(id);
            return Success(data: pPlanNextWeekInfo);
        }

        /// <summary>
        /// 修改工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] PlanNextWeekInfo pPlanNextWeekInfo)
        {
            if (pPlanNextWeekInfo.Beg == DateTime.MinValue)
            {
                throw new LogicException("自然周日期不能为空");
            }
            if (pPlanNextWeekInfo.JobClassificationInfoId == 0)
            {
                throw new LogicException("项目分类不能为空");
            }
            if (string.IsNullOrWhiteSpace(pPlanNextWeekInfo.JobContent))
            {
                throw new LogicException("工作计划安排内容不能为空");
            }

            var workDiaryInfoDB = _businessPlanNextWeek.GetById(pPlanNextWeekInfo.Id);
            workDiaryInfoDB.Beg = pPlanNextWeekInfo.Beg;
            workDiaryInfoDB.JobClassificationInfoId = pPlanNextWeekInfo.JobClassificationInfoId;
            workDiaryInfoDB.JobContent = pPlanNextWeekInfo.JobContent;

            _businessPlanNextWeek.Edit(workDiaryInfoDB);
            return Success();
        }

        /// <summary>
        /// 删除工作计划安排
        /// </summary>
        /// <param name="pPlanNextWeekInfo"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            _businessPlanNextWeek.DeleteById(id);
            return Success();
        }
    }
}
