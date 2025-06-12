using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Application.Dtos
{
    /// <summary>
    /// 用户偏好DTO
    /// </summary>
    public class UserPreferenceDto
    {
        /// <summary>
        /// 偏好ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; set; }
        
        /// <summary>
        /// 偏好对象类型名称
        /// </summary>
        public string TargetTypeName { get; set; }
        
        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// 从实体创建DTO
        /// </summary>
        /// <param name="preference">用户偏好实体</param>
        /// <returns>用户偏好DTO</returns>
        public static UserPreferenceDto FromEntity(UserPreference preference)
        {
            if (preference == null)
                return null;
                
            return new UserPreferenceDto
            {
                Id = preference.Id,
                TargetType = preference.TargetType,
                TargetTypeName = preference.TargetType.ToString(),
                PreferenceType = preference.PreferenceType,
                Remark = preference.Remark
            };
        }
    }
    
    /// <summary>
    /// 创建用户偏好DTO
    /// </summary>
    public class CreateUserPreferenceDto
    {
        /// <summary>
        /// 偏好对象类型
        /// </summary>
        public PreferenceTargetType TargetType { get; set; }
        
        /// <summary>
        /// 偏好对象ID
        /// </summary>
        public Guid TargetId { get; set; }
        
        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
    
    /// <summary>
    /// 更新用户偏好DTO
    /// </summary>
    public class UpdateUserPreferenceDto
    {
        /// <summary>
        /// 偏好ID
        /// </summary>
        public Guid UserPreferenceId { get; set; }
        
        /// <summary>
        /// 偏好类型
        /// </summary>
        public PreferenceType PreferenceType { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
} 