using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCore.Models
{
    /// <summary>
    /// 下周计划
    /// </summary>
    public class PlanNextWeekInfo : BaseModel
    {
        /// <summary>
        /// 自然周开始日期
        /// </summary>
        [Display(Name = "自然周开始日期")]
        [CustomColumn(isRequired: true, laydateType: LaydateType.date)]
        public virtual DateTime BegDate { get; set; }

        /// <summary>
        /// 项目分类信息
        /// </summary>
        [Display(Name = "项目分类信息")]
        [ForeignKey("ProjectClassificationInfoId")]
        public virtual ProjectClassificationInfo ProjectClassificationInfo { get; set; }

        /// <summary>
        /// 项目分类信息Id
        /// </summary>
        [Display(Name = "项目分类信息Id")]
        [CustomColumn(isRequired: true)]
        public virtual int ProjectClassificationInfoId { get; set; }

        /// <summary>
        /// 工作计划安排
        /// </summary>
        [MaxLength(4000)]
        [Display(Name = "工作计划安排")]
       // [CustomColumn(isRequired: true)]
        public virtual string JobContent { get; set; }
    }


    public class PlanDto
    {
        /// <summary>
        /// 自然周开始日期（每周一）
        /// </summary>
        public virtual DateTime BegDate { get; set; }

        /// <summary>
        /// 明细项列表
        /// </summary>
        public virtual List<PlanItem> ItemList { get; set; }
    }

    public class PlanItem
    {
        /// <summary>
        /// 项目分类信息Id
        /// </summary>
        public virtual int ProjectClassificationInfoId { get; set; }

        /// <summary>
        /// 工作计划安排
        /// </summary>
        public virtual string JobContent { get; set; }
    }

}
