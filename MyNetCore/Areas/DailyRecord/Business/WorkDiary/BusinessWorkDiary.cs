﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.EntityFrameworkCore;
using MyNetCore.Models;
using Newtonsoft.Json;

namespace MyNetCore.Business
{
    public class BusinessWorkDiary : BaseBusiness<WorkDiaryInfo>
    {
        public override bool NeedCheckNameRepeat
        {
            get
            {
                return false;
            }
        }

        public override IQueryable<WorkDiaryInfo> GetList(DataTableParameters param, out int totalCount, Expression<Func<WorkDiaryInfo, bool>> predicate = null,
            string orderByExpression = null, bool? isDESC = null, bool needCheckRight = true, bool asNoTracking = true)
        {
            var list = base.GetList(param, out totalCount, predicate, orderByExpression, isDESC, needCheckRight, asNoTracking);

            if (list != null)
            {
                list = list.Include(m => m.JobClassificationInfo);
            }

            return list;
        }

        public void AddDefaultItemWhenNotexist(List<WorkDiaryInfo> list, DateTime begDate)
        {
            var calendarList = GetHoliday(begDate.ToString("yyyyMM"));
            for (var dt = begDate; dt < begDate.AddMonths(1); dt = dt.AddDays(1))
            {
                var item = list.Where(x => x.Dt == dt).FirstOrDefault();
                if (item == null)
                {
                    var calendarItem = calendarList.Where(x => x.Date == dt.ToString("yyyyMMdd")).FirstOrDefault();
                    var isWorkDay = calendarItem?.Workday == "1";
                    item = new WorkDiaryInfo
                    {
                        Dt = dt,
                        WhatDay = (int)dt.DayOfWeek,
                        WhetherOnBusinessTrip = false,
                        NormalWorkHour = isWorkDay ? 8 : 0,
                        ExtraWorkHour = 0
                    };
                    if (isWorkDay)
                    {
                        item.BegWorkTime = dt.AddHours(8);
                        item.EndWorkTime = dt.AddHours(17);
                    }
                    item.SubtotalWorkHour = item.NormalWorkHour + item.ExtraWorkHour;
                    Add(item);
                }
            }
        }


        /// <summary>
        /// 获取指定年月的 工作日、节假日、周末
        /// </summary>
        /// <param name="yyyyMM"></param>
        private List<EachDayInfo> GetHoliday(string yyyyMM)
        {
            List<EachDayInfo> result = null;
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                var url = $"https://api.apihubs.cn/holiday/get?month={yyyyMM}";
                var jsondata = client.DownloadString(url);

                var model = JsonConvert.DeserializeObject<Calendar>(jsondata);
                if (model.Code == "0")
                {
                    result = model.Data.List;
                }

                return result;
            }
            catch (Exception ex)
            {
                BusinessLog businessLog = new BusinessLog();
                businessLog.Error(ex.Message);
                return result;
            }
        }
    }
}