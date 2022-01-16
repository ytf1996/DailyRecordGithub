using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class WorkDiaryController : DailyRecordBaseWithAuthController
    {
        private BusinessWorkDiary _businessWorkDiary = new BusinessWorkDiary();

        /// <summary>
        /// 获取某一年月的工作日志列表 （若无则新增空的默认行项）
        /// </summary>
        /// <param name="begDate">一个月的第一天</param>
        /// <returns></returns>
        public IActionResult List(DateTime begDate)
        {
            if(begDate!= new DateTime(begDate.Year, begDate.Month, 1))
            {
                throw new LogicException($"{begDate}不为年月格式，需为每月的第一天");
            }

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            var beflist = _businessWorkDiary.GetList(null, out int beftotalCount, x => x.Dt >= begDate && x.Dt <= begDate.AddMonths(1).AddDays(-1) && x.CreatedById == currentUser.Id, "Dt");

            var befesult = beflist.ToList();

            _businessWorkDiary.AddDefaultItemWhenNotexist(befesult, begDate);//检查并新增空默认行项

            var aftlist = _businessWorkDiary.GetList(null, out int afttotalCount, x => x.Dt >= begDate && x.Dt <= begDate.AddMonths(1).AddDays(-1) && x.CreatedById == currentUser.Id, "Dt");

            var aftresult = aftlist.ToList();

            return Success(data: aftresult);
        }


        /// <summary>
        /// 该方法不用于新增空的默认的日志周报列表   （暂设定管理员可以修改，但不能新增），因为普通用户是使用创建人作为筛选条件的，否则需要添加字段 保存该日志是为谁创建的
        /// </summary>
        /// <param name="begDate"></param>
        /// <returns></returns>
        public IActionResult List_ShowAll_ForAdministrator(DateTime begDate)
        {
            if (begDate != new DateTime(begDate.Year, begDate.Month, 1))
            {
                throw new LogicException($"{begDate}不为年月格式，需为每月的第一天");
            }

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }
            if (!currentUser.IsAdmin)
            {
                throw new Exception("您无此操作权限");
            }

            var list = _businessWorkDiary.GetList(null, out int totalCount, x => x.Dt >= begDate && x.Dt <= begDate.AddMonths(1).AddDays(-1));

            var result = list.OrderBy(x => x.CreatedById).ThenBy(x => x.Dt).ToList();

            return Success(data: result);
        }


        /// <summary>
        /// 日期星期不允许人工改动
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        private void EditInner(WorkDiaryInfo workDiaryInfo, Users currentUser)
        {
            var workDiaryInfoDB = _businessWorkDiary.GetById(workDiaryInfo.Id);
            if (workDiaryInfoDB == null)
            {
                throw new LogicException($"不存在主键id为{workDiaryInfo.Id}的日志周报明细记录");
            }

            if (!currentUser.IsAdmin && workDiaryInfoDB.CreatedById != currentUser.Id)
            {
                throw new Exception("非管理员没有权限修改他人的记录");
            }

            workDiaryInfoDB.WhetherOnBusinessTrip = workDiaryInfo.WhetherOnBusinessTrip;
            workDiaryInfoDB.TravelSite = workDiaryInfo.TravelSite;
            workDiaryInfoDB.JobClassificationInfoId = workDiaryInfo.JobClassificationInfoId;
            workDiaryInfoDB.JobContent = workDiaryInfo.JobContent;
            workDiaryInfoDB.BegWorkTime = workDiaryInfo.BegWorkTime;
            workDiaryInfoDB.EndWorkTime = workDiaryInfo.EndWorkTime;
            workDiaryInfoDB.NormalWorkHour = workDiaryInfo.NormalWorkHour;
            workDiaryInfoDB.ExtraWorkHour = workDiaryInfo.ExtraWorkHour;
            workDiaryInfoDB.SubtotalWorkHour = (workDiaryInfoDB.NormalWorkHour ?? 0) + (workDiaryInfoDB.ExtraWorkHour ?? 0);
            workDiaryInfoDB.Remark = workDiaryInfo.Remark;

            if ((workDiaryInfoDB.BegWorkTime == null && workDiaryInfoDB.EndWorkTime != null) || (workDiaryInfoDB.BegWorkTime != null && workDiaryInfoDB.EndWorkTime == null))
            {
                throw new LogicException("请填写完整上下班时间或均不填写");
            }
            if (!(workDiaryInfoDB.Dt <= workDiaryInfoDB.BegWorkTime && workDiaryInfoDB.BegWorkTime < workDiaryInfoDB.EndWorkTime && workDiaryInfoDB.EndWorkTime <= workDiaryInfoDB.Dt.AddDays(1)))
            {
                throw new LogicException("上下班时间应在当天之内，请重新填写");
            }
            if (workDiaryInfoDB.SubtotalWorkHour > 24)
            {
                throw new LogicException($"日工作总时长{workDiaryInfoDB.SubtotalWorkHour}大于24小时，请重新填写");
            }

            _businessWorkDiary.Edit(workDiaryInfoDB);
        }


        /// <summary>
        /// 修改工作日志
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] WorkDiaryInfo workDiaryInfo)
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }
            EditInner(workDiaryInfo, currentUser);
            return Success();
        }


        /// <summary>
        /// 批量修改工作日志
        /// </summary>
        /// <param name="workDiaryInfo"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Save([FromBody] List<WorkDiaryInfo> workDiaryInfoList)
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }

            foreach (var workDiaryInfo in workDiaryInfoList)
            {
                EditInner(workDiaryInfo, currentUser);
            }
            return Success();
        }
    }
}
