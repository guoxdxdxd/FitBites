using System;
using System.Linq;
using FitBites.Core.Enums;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户聚合根 - 偏好相关方法
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 添加用户偏好
        /// </summary>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <param name="preferenceType">偏好类型</param>
        /// <param name="remark">备注</param>
        /// <returns>添加的用户偏好</returns>
        public UserPreference AddPreference(PreferenceTargetType targetType, Guid targetId, PreferenceType preferenceType, string remark = "")
        {
            // 检查是否已存在相同偏好
            var existingPreference = UserPreferences.FirstOrDefault(p => 
                p.TargetType == targetType && 
                p.TargetId == targetId && 
                p.PreferenceType == preferenceType);
                
            if (existingPreference != null)
            {
                return existingPreference; // 已存在相同偏好，直接返回
            }
            
            // 创建新的偏好对象
            var preference = new UserPreference(Id, targetType, targetId, preferenceType, remark);
            
            // 添加到用户的偏好集合中
            UserPreferences.Add(preference);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceAddedEvent(Id, preference.Id, targetType, targetId, preferenceType));
            
            return preference;
        }
        
        /// <summary>
        /// 更新用户偏好
        /// </summary>
        /// <param name="preferenceId">偏好ID</param>
        /// <param name="preferenceType">新的偏好类型</param>
        /// <param name="remark">新的备注</param>
        /// <returns>是否更新成功</returns>
        public bool UpdatePreference(Guid preferenceId, PreferenceType preferenceType, string remark)
        {
            // 查找指定ID的偏好
            var preference = UserPreferences.FirstOrDefault(p => p.Id == preferenceId);
            
            if (preference == null)
            {
                return false; // 偏好不存在，更新失败
            }
            
            // 更新偏好
            preference.Update(preferenceType, remark);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceUpdatedEvent(Id, preference.Id, preference.TargetType, preference.TargetId, preferenceType));
            
            return true;
        }
        
        /// <summary>
        /// 删除用户偏好
        /// </summary>
        /// <param name="preferenceId">偏好ID</param>
        /// <returns>是否删除成功</returns>
        public bool RemovePreference(Guid preferenceId)
        {
            // 查找指定ID的偏好
            var preference = UserPreferences.FirstOrDefault(p => p.Id == preferenceId);
            
            if (preference == null)
            {
                return false; // 偏好不存在，删除失败
            }
            
            // 从集合中移除
            UserPreferences.Remove(preference);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceRemovedEvent(Id, preference.Id, preference.TargetType, preference.TargetId));
            
            return true;
        }
        
        /// <summary>
        /// 按类型和目标删除用户偏好
        /// </summary>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <returns>是否删除成功</returns>
        public bool RemovePreferenceByTarget(PreferenceTargetType targetType, Guid targetId)
        {
            // 查找所有匹配的偏好
            var preferences = UserPreferences.Where(p => 
                p.TargetType == targetType && 
                p.TargetId == targetId).ToList();
                
            if (!preferences.Any())
            {
                return false; // 没有找到匹配的偏好，删除失败
            }
            
            // 从集合中移除所有匹配的偏好
            foreach (var preference in preferences)
            {
                UserPreferences.Remove(preference);
                
                // 触发领域事件
                AddDomainEvent(new UserPreferenceRemovedEvent(Id, preference.Id, targetType, targetId));
            }
            
            return true;
        }
    }
} 