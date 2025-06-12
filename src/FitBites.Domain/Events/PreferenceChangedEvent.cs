using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 偏好数据变更领域事件
    /// 当偏好数据（菜系、烹饪方式、口味）发生变化时触发
    /// </summary>
    public class PreferenceChangedEvent : DomainEvent
    {
        public PreferenceTargetType TargetType;

        /// <summary>
        /// 偏好项ID
        /// </summary>
        public Guid PreferenceId { get; }

        /// <summary>
        /// 创建偏好变更事件
        /// </summary>
        /// <param name="preferenceId">偏好项ID</param>
        /// <param name="targetType">偏好类型</param>
        public PreferenceChangedEvent(Guid preferenceId, PreferenceTargetType targetType)
        {
            TargetType = targetType;
            PreferenceId = preferenceId;
        }
    }
    
} 