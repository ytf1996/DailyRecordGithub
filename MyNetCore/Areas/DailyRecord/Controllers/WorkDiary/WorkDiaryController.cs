using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class WorkDiaryController : DailyRecordBaseWithAuthController
    {
        private BusinessWorkDiary _businessWorkDiary = new BusinessWorkDiary();

        /// <summary>
        /// 获取指定日期范围内的工作日志列表
        /// </summary>
        /// <returns></returns>
        public IActionResult List(DateTime begDate, DateTime endDate)
        {
            Expression<Func<WorkDiaryInfo, bool>> predicate;
            var currentUser = GetCurrentUserInfo();
            if (currentUser != null && currentUser.UserType != UserType.Admin)
            {
                predicate = x => x.Dt >= begDate && x.Dt <= endDate && x.CreatedById == currentUser.Id;
            }
            else
            {
                predicate = x => x.Dt >= begDate && x.Dt <= endDate;
            }
            var list = _businessWorkDiary.GetList(null, out int totalCount, predicate, "Dt", needCheckRight: false);

            var result = list.ToList();

            return Success(data: result);
        }

        /// <summary>
        /// 添加工作日志
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] WorkDiaryInfo workDiaryInfo)
        {
            if (workDiaryInfo.Dt == DateTime.MinValue)
            {
                throw new LogicException("日期不能为空");
            }
            if (workDiaryInfo.WhatDay > 7 || workDiaryInfo.WhatDay < 1)
            {
                throw new LogicException("星期必须在1-7之间");
            }

            //考虑请假填写的情况

            //if (workDiaryInfo.JobClassificationInfoId == null)
            //{
            //    throw new LogicException("工作分类不能为空");
            //}
            //if (string.IsNullOrWhiteSpace(workDiaryInfo.JobContent))
            //{
            //    throw new LogicException("工作内容不能为空");
            //}

            _businessWorkDiary.Add(workDiaryInfo, needCheckRight: false);
            return Success();
        }

        /// <summary>
        /// 获取单条工作日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(int id)
        {
            var workDiaryInfo = _businessWorkDiary.GetById(id, needCheckRight: false);
            return Success(data: workDiaryInfo);
        }

        /// <summary>
        /// 修改工作日志
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] WorkDiaryInfo workDiaryInfo)
        {
            if (workDiaryInfo.Dt == DateTime.MinValue)
            {
                throw new LogicException("日期不能为空");
            }
            if (workDiaryInfo.WhatDay > 7 || workDiaryInfo.WhatDay < 1)
            {
                throw new LogicException("星期必须在1-7之间");
            }

            var workDiaryInfoDB = _businessWorkDiary.GetById(workDiaryInfo.Id, needCheckRight: false);
            workDiaryInfoDB.Dt = workDiaryInfo.Dt;
            workDiaryInfoDB.WhatDay = workDiaryInfo.WhatDay;
            workDiaryInfoDB.WhetherOnBusinessTrip = workDiaryInfo.WhetherOnBusinessTrip;
            workDiaryInfoDB.TravelSite = workDiaryInfo.TravelSite;
            workDiaryInfoDB.JobClassificationInfoId = workDiaryInfo.JobClassificationInfoId;
            workDiaryInfoDB.JobContent = workDiaryInfo.JobContent;
            workDiaryInfoDB.BegWorkTime = workDiaryInfo.BegWorkTime;
            workDiaryInfoDB.EndWorkTime = workDiaryInfo.EndWorkTime;
            workDiaryInfoDB.NormalWorkHour = workDiaryInfo.NormalWorkHour;
            workDiaryInfoDB.ExtraWorkHour = workDiaryInfo.ExtraWorkHour;
            workDiaryInfoDB.SubtotalWorkHour = workDiaryInfo.SubtotalWorkHour;
            workDiaryInfoDB.Remark = workDiaryInfo.Remark;

            _businessWorkDiary.Edit(workDiaryInfoDB, needCheckRight: false);
            return Success();
        }

        /// <summary>
        /// 删除工作日志
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            _businessWorkDiary.DeleteById(id, needCheckRight: false);
            return Success();
        }
    }
}
