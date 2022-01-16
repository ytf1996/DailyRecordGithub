using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.EntityFrameworkCore;
using MyNetCore.Models;

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
            for (var dt = begDate; dt < begDate.AddMonths(1); dt = dt.AddDays(1))
            {
                var item = list.Where(x => x.Dt == dt).FirstOrDefault();
                if (item == null)
                {
                    item = new WorkDiaryInfo
                    {
                        Dt = dt,
                        WhatDay = (int)dt.DayOfWeek,
                        WhetherOnBusinessTrip = false,
                        BegWorkTime = dt.AddHours(8),
                        EndWorkTime = dt.AddHours(17),
                        NormalWorkHour = 8,
                        ExtraWorkHour = 0,
                        SubtotalWorkHour = 8
                    };
                    Add(item);
                }
            }
        }
    }
}