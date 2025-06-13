using System;
using System.Collections.Generic;
using System.Linq;
using FitBites.Core.Enums;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户聚合根 - 人群标签相关方法
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 添加人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">来源</param>
        /// <param name="confidence">置信度</param>
        /// <returns>添加的用户人群标签</returns>
        public UserHumanGroup AddHumanGroup(Guid groupId, HumanGroupSource source, decimal? confidence = null)
        {
            // 检查是否已存在相同标签
            var existingGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
                
            if (existingGroup != null)
            {
                return existingGroup; // 已存在相同标签，直接返回
            }
            
            // 创建新的人群标签映射
            var userHumanGroup = new UserHumanGroup(Id, groupId, source, confidence);
            
            // 添加到用户的人群标签集合中
            UserHumanGroups.Add(userHumanGroup);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupAddedEvent(Id, groupId, source));
            
            return userHumanGroup;
        }
        
        /// <summary>
        /// 移除人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否移除成功</returns>
        public bool RemoveHumanGroup(Guid groupId)
        {
            // 查找指定标签ID的映射
            var userHumanGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
            
            if (userHumanGroup == null)
            {
                return false; // 标签不存在，移除失败
            }
            
            // 从集合中移除
            UserHumanGroups.Remove(userHumanGroup);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupRemovedEvent(Id, groupId));
            
            return true;
        }
        
        /// <summary>
        /// 更新人群标签信息
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">新的来源</param>
        /// <param name="confidence">新的置信度</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateHumanGroup(Guid groupId, HumanGroupSource source, decimal? confidence)
        {
            // 查找指定标签ID的映射
            var userHumanGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
            
            if (userHumanGroup == null)
            {
                return false; // 标签不存在，更新失败
            }
            
            // 更新人群标签信息
            userHumanGroup.Update(source, confidence);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupUpdatedEvent(Id, groupId, source, confidence));
            
            return true;
        }
        
        /// <summary>
        /// 检查用户是否属于指定人群
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否属于该人群</returns>
        public bool BelongsToHumanGroup(Guid groupId)
        {
            return UserHumanGroups.Any(g => g.GroupId == groupId);
        }
        
        /// <summary>
        /// 获取用户所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        public List<HumanGroupDict> GetHumanGroups()
        {
            return UserHumanGroups.Select(g => g.HumanGroup).ToList();
        }
    }
} 