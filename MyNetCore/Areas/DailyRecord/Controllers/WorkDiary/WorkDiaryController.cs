﻿using Microsoft.AspNetCore.Mvc;
using MyNetCore.Business;
using MyNetCore.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            rtnDto.SubtotalWorkHourSummary = Math.Round((((rtnDto.NormalWorkHourSummary ?? 0) + (rtnDto.ExtraWorkHourSummary ?? 0)) / 8), 2);
            rtnDto.ChargeDayNum = aftresult.Where(x => x.SubtotalWorkDay != null && x.SubtotalWorkDay != 0).Count();
            rtnDto.BusinessTripDayNum = aftresult.Where(x => x.SubtotalWorkDay != null && x.SubtotalWorkDay != 0 && (x.WhetherOnBusinessTrip ?? false)).Count();

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
            var allWorkDiaryList = _businessWorkDiary.GetList(null, out int totalCount, x => userAccounts.Contains(x.CreatedById) && x.Dt >= begDate && x.Dt <= begDate.AddMonths(1).AddDays(-1), "Dt");
            var hasWorkDiaryAcconts = allWorkDiaryList.Select(x => x.CreatedById).Distinct().ToList();
            userExpList = userExpList.Where(x => hasWorkDiaryAcconts.Contains(x.Id)).ToList();
            userAccounts = userExpList.Select(x => (int?)x.Id).ToList();

            var sheetNames = userExpList.Select(x => x.Name).ToList();
            var excelName = contractedSupplier + begDate.ToString("yyyyMM") + "日报";
            string path = @"C:\Users\16273\Desktop\DailyRecord\MyNetCore\";   //return path;

            #region 创建工作簿、克隆sheet页、获取特定单元格位置、赋值单元格日志值
            XSSFWorkbook workbookTemplate;
            XSSFSheet sheetTemplate;
            string templateExcelName = path + "日志导出模板.xlsx";
            Dictionary<string, (int, int)> dic = new Dictionary<string, (int, int)>();
            List<string> speCellNameList_user = new List<string>{
                nameof(Users.ContractedSupplier),
                nameof(Users.Group),
                nameof(Users.ServiceUnit),
                nameof(Users.Name),
                nameof(Users.CounselorPropertyDes),
            };
            List<string> speCellNameList_diary = new List<string>{
                nameof(WorkDiaryInfo.DtExport),
                nameof(WorkDiaryInfo.WhatDayDes),
                nameof(WorkDiaryInfo.WhetherOnBusinessTripExport),
                nameof(WorkDiaryInfo.TravelSite),
                nameof(WorkDiaryInfo.JobClassificationInfoIdExport),
                nameof(WorkDiaryInfo.JobContent),
                nameof(WorkDiaryInfo.BegWorkTimeExport),
                nameof(WorkDiaryInfo.EndWorkTimeExport),
                nameof(WorkDiaryInfo.NormalWorkHour),
                nameof(WorkDiaryInfo.ExtraWorkHour),
                nameof(WorkDiaryInfo.SubtotalWorkDay),
                nameof(WorkDiaryInfo.Remark)
            };
            List<string> speCellNameList_summary = new List<string>{
                "yyyyMM",
                "ChargeDayNum",
                "BisTripDayNum"
            };
            using (FileStream stream = new FileStream(templateExcelName, FileMode.Open, FileAccess.Read))
            {
                workbookTemplate = new XSSFWorkbook(stream);
                sheetTemplate = workbookTemplate.GetSheet("XXX") as XSSFSheet;
                //遍历模板excel获得行号列号
                for (var i = 0; i <= sheetTemplate.LastRowNum; i++)  //46行   LastRowNum=45
                {
                    XSSFRow row = (XSSFRow)sheetTemplate.GetRow(i);
                    for (int j = 0; j < (row.LastCellNum); j++) //12列    LastCellNum=12
                    {
                        XSSFCell cell = (XSSFCell)row.GetCell(j);

                        if (speCellNameList_user.Contains(cell.ToString()) || speCellNameList_diary.Contains(cell.ToString()) || speCellNameList_summary.Contains(cell.ToString()))
                        {
                            dic.Add(cell.ToString(), (i, j));
                        }
                    }
                }
            }

            XSSFWorkbook downLoadWorkBook = new XSSFWorkbook();
            foreach (var sheetName in sheetNames)
            {
                sheetTemplate.CopyTo(downLoadWorkBook, sheetName, true, true);
            }
            workbookTemplate.Close();

            var exportExcelName = path + excelName + ".xlsx";
            PropertyInfo[] propertyInfos_user = typeof(Users).GetProperties();
            PropertyInfo[] propertyInfos_diary = typeof(WorkDiaryInfo).GetProperties();
            WorkDiaryInfo.projectList = new BusinessJobClassification().GetList(null, out _, null).ToList();
            using (FileStream stream = new FileStream(exportExcelName, FileMode.Create, FileAccess.Write))  // If the file already  exists, it will be overwritten. 
            {
                foreach (var userId in userAccounts)  //对每个用户循环处理
                {
                    var userInfo = userExpList.Where(x => x.Id == userId).FirstOrDefault();
                    XSSFSheet curUserSheet = (XSSFSheet)downLoadWorkBook.GetSheet(userInfo.Name); //获取该用户对应的sheet页

                    speCellNameList_user.ForEach(cellName =>
                    {
                        ICell cell = curUserSheet.GetRow(dic[cellName].Item1).GetCell(dic[cellName].Item2);

                        var propertyInfo = propertyInfos_user.Where(y => y.Name == cellName).FirstOrDefault();

                        cell.SetCellValue(propertyInfo.GetValue(userInfo)?.ToString());
                    });

                    var curUserWorkDiaryList = allWorkDiaryList.Where(x => x.CreatedById == userId).OrderBy(x => x.Dt).ToList();
                    speCellNameList_diary.ForEach(cellName =>
                    {
                        var propertyInfo = propertyInfos_diary.Where(y => y.Name == cellName).FirstOrDefault();
                        var x = dic[cellName].Item1; var y = dic[cellName].Item2;

                        curUserWorkDiaryList.ForEach(userDiary =>
                        {
                            ICell cell = curUserSheet.GetRow(x++).GetCell(y);

                            cell.SetCellValue(propertyInfo.GetValue(userDiary)?.ToString());
                        });
                    });

                    speCellNameList_summary.ForEach(cellName =>
                    {
                        ICell cell = curUserSheet.GetRow(dic[cellName].Item1).GetCell(dic[cellName].Item2);

                        var val = string.Empty;
                        switch (cellName)
                        {
                            case "yyyyMM":
                                val = begDate.ToString("yyyy/MM");
                                break;
                            case "ChargeDayNum":
                                val = curUserWorkDiaryList.Where(x => x.SubtotalWorkDay != null && x.SubtotalWorkDay != 0).Count().ToString();
                                break;
                            case "BisTripDayNum":
                                val = curUserWorkDiaryList.Where(x => x.SubtotalWorkDay != null && x.SubtotalWorkDay != 0 && (x.WhetherOnBusinessTrip ?? false)).Count().ToString();
                                break;
                            default:
                                break;
                        }

                        cell.SetCellValue(val);
                    });
                }
                downLoadWorkBook.Write(stream);
            }
            downLoadWorkBook.Close();
            #endregion

            return Success();
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
            workDiaryInfoDB.SubtotalWorkDay = Math.Round((((workDiaryInfoDB.NormalWorkHour ?? 0) + (workDiaryInfoDB.ExtraWorkHour ?? 0)) / 8), 2);
            workDiaryInfoDB.Remark = workDiaryInfo.Remark;

            if ((workDiaryInfoDB.BegWorkTime == null && workDiaryInfoDB.EndWorkTime != null) || (workDiaryInfoDB.BegWorkTime != null && workDiaryInfoDB.EndWorkTime == null))
            {
                throw new LogicException("请填写完整上下班时间或均不填写");
            }
            if (!(workDiaryInfoDB.Dt <= workDiaryInfoDB.BegWorkTime && workDiaryInfoDB.BegWorkTime < workDiaryInfoDB.EndWorkTime && workDiaryInfoDB.EndWorkTime <= workDiaryInfoDB.Dt.AddDays(1)))
            {
                throw new LogicException("上下班时间应在当天之内，请重新填写");
            }
            if ((workDiaryInfoDB.NormalWorkHour ?? 0) + (workDiaryInfoDB.ExtraWorkHour ?? 0) > 24)
            {
                throw new LogicException($"日工作总时长大于24小时，请重新填写");
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
