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
        /// 默认构造函数
        /// </summary>
        protected UserHumanGroup()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">来源</param>
        /// <param name="confidence">置信度</param>
        public UserHumanGroup(Guid userId, Guid groupId, HumanGroupSource source, decimal? confidence = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            GroupId = groupId;
            Source = source;
            Confidence = confidence;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

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

        /// <summary>
        /// 更新用户人群标签信息
        /// </summary>
        /// <param name="source">来源</param>
        /// <param name="confidence">置信度</param>
        public void Update(HumanGroupSource source, decimal? confidence)
        {
            Source = source;
            Confidence = confidence;
            UpdatedAt = DateTime.Now;
        }
    }
} 