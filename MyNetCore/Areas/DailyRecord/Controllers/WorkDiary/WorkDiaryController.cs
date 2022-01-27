using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyNetCore.Areas.DailyRecord.Controllers
{
    public class WorkDiaryController : DailyRecordBaseWithAuthController
    {
        private BusinessWorkDiary _businessWorkDiary = new BusinessWorkDiary();
        private BusinessUsers _businessUsers = new BusinessUsers();

        public IActionResult QueryCurrentUserInfo()
        {
            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }
            return Success(data: currentUser);
        }

        /// <summary>
        /// 获取某一年月的工作日志列表 （若无则新增空的默认行项）
        /// </summary>
        /// <param name="begDate">一个月的第一天</param>
        /// <returns></returns>
        public IActionResult List(DateTime begDate)
        {
            begDate = new DateTime(begDate.Year, begDate.Month, 1);

            if (DateTime.Today.AddMonths(3) < begDate) throw new Exception("查询日期最多为当前月往后3个月");
            //if (begDate != new DateTime(begDate.Year, begDate.Month, 1))
            //{
            //    throw new LogicException($"{begDate}不为年月格式，需为每月的第一天");
            //}

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

            DiaryShowDto rtnDto = new DiaryShowDto();

            rtnDto.DiaryList = aftresult;
            rtnDto.User = currentUser; //待注释掉
            rtnDto.NormalWorkHourSummary = aftresult.Sum(x => x.NormalWorkHour ?? 0);
            rtnDto.ExtraWorkHourSummary = aftresult.Sum(x => x.ExtraWorkHour ?? 0);
            rtnDto.SubtotalWorkHourSummary = (rtnDto.NormalWorkHourSummary ?? 0) + (rtnDto.ExtraWorkHourSummary);
            rtnDto.ChargeDayNum = aftresult.Where(x => x.SubtotalWorkHour != null && x.SubtotalWorkHour != 0).Count();
            rtnDto.ChargeDayNum = aftresult.Where(x => x.SubtotalWorkHour != null && x.SubtotalWorkHour != 0 && (x.WhetherOnBusinessTrip ?? false)).Count();

            return Success(data: rtnDto);
        }


        /// <summary>
        /// 按公司+年月导出 所有人员的日报 为excel（管理员专用导出功能）
        /// </summary>
        /// <param name="begDate">年月</param>
        /// <param name="contractedSupplier">公司</param>
        /// <returns></returns>
        public IActionResult ExportByYearMonth(DateTime begDate, string contractedSupplier)
        {
            begDate = new DateTime(begDate.Year, begDate.Month, 1);

            var currentUser = GetCurrentUserInfo();
            if (currentUser == null)
            {
                throw new Exception("用户未登录");
            }
            if (!currentUser.IsAdmin)
            {
                throw new Exception("您无此操作权限");
            }

            var userExpList = _businessUsers.GetList(null, out int userTotalCount, x => x.ContractedSupplier == contractedSupplier && !x.Disabled, "UserOrder", null, false).ToList();
            var userAccounts = userExpList.Select(x => (int?)x.Id).ToList();

            var allWorkDiaryList = _businessWorkDiary.GetList(null, out int totalCount, x => userAccounts.Contains(x.CreatedById) && x.Dt >= begDate && x.Dt <= begDate.AddMonths(1).AddDays(-1));
            var hasWorkDiaryAcconts = allWorkDiaryList.Select(x => x.CreatedById).Distinct().ToList();

            userExpList = userExpList.Where(x => hasWorkDiaryAcconts.Contains(x.Id)).ToList();
            userAccounts= userExpList.Select(x => (int?)x.Id).ToList();

            foreach (var user in userAccounts)
            {
                var userInfo = userExpList.Where(x => x.Id == user).FirstOrDefault();
                var curUserWorkDiaryList = allWorkDiaryList.Where(x => x.CreatedById == user).OrderBy(x => x.Dt).ToList();

                NpoiOperation();
            }

            return Success();  //返回excel
        }


        public string NpoiOperation()
        {
            string file =AppContext.BaseDirectory+ "日志导出.xlsx";

            return file;
            IWorkbook workbook;
            ISheet sheet;
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);
                sheet = workbook.GetSheetAt(0);
            }

            //using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            //{
            //    for (var i = 1; i <= sheet.LastRowNum; i++)
            //    {
            //        IRow row = sheet.GetRow(i);
            //        ICell cell_ordGroup = row.GetCell(4);//获取订单组号列


            //            ICell cell_rst = row.CreateCell(10);//生成结果列
            //            cell_rst.SetCellValue("成功");

            //    }
            //    workbook.Write(stream);
            //}
            workbook.Close();
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
        [HttpPost]
        public IActionResult Edit(WorkDiaryInfo workDiaryInfo)
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
        [HttpPost]
        public IActionResult Save(List<WorkDiaryInfo> workDiaryInfoList)
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
