using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户偏好实体
    /// </summary>
    public class UserPreference : EntityBase
    {
        /// <summary>
        /// 默认构造函数，供EF Core使用
        /// </summary>
        protected UserPreference()
        {
        }
        
        /// <summary>
        /// 创建新的用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <param name="preferenceType">偏好类型</param>
        /// <param name="remark">备注</param>
        public UserPreference(Guid userId, PreferenceTargetType targetType, Guid targetId, PreferenceType preferenceType, string remark = "")
        {
            Id = Guid.NewGuid();
            UserId = userId;
            TargetType = targetType;
            TargetId = targetId;
            PreferenceType = preferenceType;
            Remark = remark ?? string.Empty;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 更新偏好信息
        /// </summary>
        /// <param name="preferenceType">新的偏好类型</param>
        /// <param name="remark">新的备注</param>
        public void Update(PreferenceType preferenceType, string remark)
        {
            PreferenceType = preferenceType;
            Remark = remark ?? string.Empty;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; private set; }

        /// <summary>
        /// 偏好对象ID
        /// </summary>
        public Guid TargetId { get; private set; }

        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; private set; }

        /// <summary>
        /// 用户导航属性
        /// </summary>
        public virtual User User { get; private set; }
    }
} 