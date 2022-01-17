using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCore.Models
{
    /// <summary>
    /// 工作日志
    /// </summary>
    public class WorkDiaryInfo : BaseModel
    {
        /// <summary>
        /// 日期
        /// </summary>
        [Display(Name = "日期")]
        [CustomColumn(isRequired: true, laydateType: LaydateType.date)]
        public virtual DateTime Dt { get; set; }

        /// <summary>
        /// 星期几
        /// </summary>
        [Display(Name = "星期几")]
        [CustomColumn(isRequired: true)]
        public virtual int WhatDay { get; set; }

        /// <summary>
        /// 是否出差
        /// </summary>
        [Display(Name = "是否出差")]
        //[CustomColumn(isRequired: true)]
        public virtual bool? WhetherOnBusinessTrip { get; set; }

        /// <summary>
        /// 差旅地点
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "差旅地点")]
        public virtual string TravelSite { get; set; }

        /// <summary>
        /// 工作分类信息
        /// </summary>
        [Display(Name = "工作分类信息")]
        [ForeignKey("JobClassificationInfoId")]
        public virtual JobClassificationInfo JobClassificationInfo { get; set; }

        /// <summary>
        /// 工作分类信息Id
        /// </summary>
        [Display(Name = "工作分类信息Id")]
        //[CustomColumn(isRequired: true)]
        public virtual int? JobClassificationInfoId { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        [MaxLength(4000)]
        [Display(Name = "工作内容")]
        public virtual string JobContent { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        [Display(Name = "上班时间")]
        //[CustomColumn(isRequired: true, laydateType: LaydateType.dateNoChoose)]
        public virtual DateTime? BegWorkTime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        [Display(Name = "下班时间")]
        //[CustomColumn(isRequired: true, laydateType: LaydateType.dateNoChoose)]
        public virtual DateTime? EndWorkTime { get; set; }

        /// <summary>
        /// 正常小时工作数（小时）
        /// </summary>
        [Display(Name = "正常小时工作数（小时）")]
        //[CustomColumn(isRequired: true)]
        public virtual decimal? NormalWorkHour { get; set; }

        /// <summary>
        /// 加班（小时）
        /// </summary>
        [Display(Name = "加班（小时）")]
        public virtual decimal? ExtraWorkHour { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        [Display(Name = "小计")]
        //[CustomColumn(isRequired: true)]
        public virtual decimal? SubtotalWorkHour { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(4000)]
        [Display(Name = "备注")]
        public virtual string Remark { get; set; }
    }



    public class DiaryShowDto
    {
        /// <summary>
        /// 日志信息列表
        /// </summary>
        public List<WorkDiaryInfo> DiaryList { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        public Users User { get; set; }

        /// <summary>
        /// 正常小时
        /// </summary>
        public virtual decimal? NormalWorkHourSummary { get; set; }

        /// <summary>
        /// 加班工时
        /// </summary>
        public virtual decimal? ExtraWorkHourSummary { get; set; }

        /// <summary>
        /// 合计工作工时
        /// </summary>
        public virtual decimal? SubtotalWorkHourSummary { get; set; }

        /// <summary>
        /// 收费天数
        /// </summary>
        public virtual int? ChargeDayNum { get; set; }

        /// <summary>
        /// 出差天数
        /// </summary>
        public virtual int? BusinessTripDayNum { get; set; }
    }
}
