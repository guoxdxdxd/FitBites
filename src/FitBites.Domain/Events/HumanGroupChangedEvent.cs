using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 人群标签数据变更领域事件
    /// 当人群标签数据发生变化时触发
    /// </summary>
    public class HumanGroupChangedEvent : DomainEvent
    {
        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid HumanGroupId { get; }

        /// <summary>
        /// 创建人群标签变更事件
        /// </summary>
        /// <param name="humanGroupId">人群标签ID</param>
        public HumanGroupChangedEvent(Guid humanGroupId)
        {
            HumanGroupId = humanGroupId;
        }
    }
} 