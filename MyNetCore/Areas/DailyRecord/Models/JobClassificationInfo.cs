﻿using Roim.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyNetCore.Models
{
    /// <summary>
    /// 工作分类
    /// </summary>
    public class JobClassificationInfo : BaseModel
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "分类名称")]
        [CustomColumn(isRequired: true)]
        public virtual string ClassificationName { get; set; }
    }

}