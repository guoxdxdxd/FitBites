using System;
using FitBites.Core.Enums;

namespace FitBites.Domain.Events
{
    /// <summary>
    /// 用户偏好添加事件
    /// </summary>
    public class UserPreferenceAddedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 偏好ID
        /// </summary>
        public Guid PreferenceId { get; }
        
        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; }
        
        /// <summary>
        /// 偏好对象ID
        /// </summary>
        public Guid TargetId { get; }
        
        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="preferenceId">偏好ID</param>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <param name="preferenceType">偏好类型</param>
        public UserPreferenceAddedEvent(Guid userId, Guid preferenceId, PreferenceTargetType targetType, Guid targetId, PreferenceType preferenceType)
        {
            UserId = userId;
            PreferenceId = preferenceId;
            TargetType = targetType;
            TargetId = targetId;
            PreferenceType = preferenceType;
        }
    }
    
    /// <summary>
    /// 用户偏好更新事件
    /// </summary>
    public class UserPreferenceUpdatedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 偏好ID
        /// </summary>
        public Guid PreferenceId { get; }
        
        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; }
        
        /// <summary>
        /// 偏好对象ID
        /// </summary>
        public Guid TargetId { get; }
        
        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="preferenceId">偏好ID</param>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <param name="preferenceType">偏好类型</param>
        public UserPreferenceUpdatedEvent(Guid userId, Guid preferenceId, PreferenceTargetType targetType, Guid targetId, PreferenceType preferenceType)
        {
            UserId = userId;
            PreferenceId = preferenceId;
            TargetType = targetType;
            TargetId = targetId;
            PreferenceType = preferenceType;
        }
    }
    
    /// <summary>
    /// 用户偏好删除事件
    /// </summary>
    public class UserPreferenceRemovedEvent : DomainEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; }
        
        /// <summary>
        /// 偏好ID
        /// </summary>
        public Guid PreferenceId { get; }
        
        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; }
        
        /// <summary>
        /// 偏好对象ID
        /// </summary>
        public Guid TargetId { get; }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="preferenceId">偏好ID</param>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        public UserPreferenceRemovedEvent(Guid userId, Guid preferenceId, PreferenceTargetType targetType, Guid targetId)
        {
            UserId = userId;
            PreferenceId = preferenceId;
            TargetType = targetType;
            TargetId = targetId;
        }
    }
} 