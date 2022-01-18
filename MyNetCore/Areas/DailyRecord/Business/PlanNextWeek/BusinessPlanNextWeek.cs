using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.EntityFrameworkCore;
using MyNetCore.Models;

namespace MyNetCore.Business
{
    public class BusinessPlanNextWeek : BaseBusiness<PlanNextWeekInfo>
    {
        public override bool NeedCheckNameRepeat
        {
            get
            {
                return false;
            }
        }

        public override IQueryable<PlanNextWeekInfo> GetList(DataTableParameters param, out int totalCount, Expression<Func<PlanNextWeekInfo, bool>> predicate = null,
            string orderByExpression = null, bool? isDESC = null, bool needCheckRight = true, bool asNoTracking = true)
        {
            var list = base.GetList(param, out totalCount, predicate, orderByExpression, isDESC, needCheckRight, asNoTracking);

            if (list != null)
            {
                return list.Include(m => m.ProjectClassificationInfo);
            }
            return list;
        }

        //public void AddDefaultItemWhenNotexist(List<PlanNextWeekInfo> list, DateTime beg)
        //{
        //    var projectList = new BusinessProjectClassification().GetList(null, out int totalCount).ToList();

        //    foreach (var project in projectList)
        //    {
        //        var item = list.Where(x => x.BegDate == beg && x.ProjectClassificationInfoId == project.Id).FirstOrDefault();
        //        if (item == null)
        //        {
        //            item = new PlanNextWeekInfo
        //            {
        //                BegDate = beg,
        //                ProjectClassificationInfoId = project.Id
        //            };
        //            Add(item);
        //        }
        //    }
        //}

        public void CheckDate(DateTime date)
        {
            if (date != new DateTime(date.Year, date.Month, date.Day))
            {
                throw new LogicException($"{date}不为年月日格式");
            }
            //if (date.DayOfWeek != DayOfWeek.Monday)
            //{
            //    throw new LogicException($"{date}不为自然周的周一");
            //}
        }


        public void CheckRepeat(DateTime begDate, int projectClassificationInfoId, Users currentUser)
        {
            var list = GetList(null, out int beftotalCount, x => x.BegDate == begDate && x.ProjectClassificationInfoId == projectClassificationInfoId && x.CreatedById == currentUser.Id);

            var result = list.ToList();

            if (result.Count > 0)
            {
                var project = new BusinessProjectClassification().GetList(null, out int totalCount, x => x.Id == projectClassificationInfoId).FirstOrDefault()?.ClassificationName ?? projectClassificationInfoId.ToString();

                throw new Exception($"当前用户已存在 日期{begDate}、项目{project}的记录");
            }
        }
    }
}