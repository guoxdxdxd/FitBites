
using FitBites.Core.Enums;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 用户人群标签添加事件
    /// </summary>
    public class UserHumanGroupAddedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource Source { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">来源</param>
        public UserHumanGroupAddedEvent(Guid userId, Guid groupId, HumanGroupSource source)
        {
            UserId = userId;
            GroupId = groupId;
            Source = source;
        }
    }

    /// <summary>
    /// 用户人群标签移除事件
    /// </summary>
    public class UserHumanGroupRemovedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        public UserHumanGroupRemovedEvent(Guid userId, Guid groupId)
        {
            UserId = userId;
            GroupId = groupId;
        }
    }

    /// <summary>
    /// 用户人群标签更新事件
    /// </summary>
    public class UserHumanGroupUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource Source { get; }

        /// <summary>
        /// 置信度
        /// </summary>
        public decimal? Confidence { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">来源</param>
        /// <param name="confidence">置信度</param>
        public UserHumanGroupUpdatedEvent(Guid userId, Guid groupId, HumanGroupSource source, decimal? confidence)
        {
            UserId = userId;
            GroupId = groupId;
            Source = source;
            Confidence = confidence;
        }
    }
} 