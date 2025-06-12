using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户-人群标签映射实体
    /// </summary>
    public class UserHumanGroup : EntityBase
    {


        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource? Source { get; private set; }

        /// <summary>
        /// 置信度（0~100，用于系统评估）
        /// </summary>
        public decimal? Confidence { get; private set; }



        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }

        /// <summary>
        /// 人群标签导航属性
        /// </summary>
        public virtual HumanGroupDict HumanGroup { get; private set; }
    }
} 