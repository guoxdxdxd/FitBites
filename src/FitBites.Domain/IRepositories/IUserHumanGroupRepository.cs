using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.Interfaces
{
    /// <summary>
    /// 用户人群标签仓储接口
    /// </summary>
    public interface IUserHumanGroupRepository : IRepository<UserHumanGroup>, IScopedDependency
    {
        /// <summary>
        /// 获取用户的所有人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户人群标签列表</returns>
        Task<List<UserHumanGroup>> GetUserHumanGroupsAsync(Guid userId);
        
        /// <summary>
        /// 获取用户特定人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>用户人群标签</returns>
        Task<UserHumanGroup> GetUserHumanGroupAsync(Guid userId, Guid groupId);
        
        /// <summary>
        /// 删除用户人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeleteUserHumanGroupAsync(Guid userId, Guid groupId);
        
        /// <summary>
        /// 检查用户是否属于指定人群
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否属于该人群</returns>
        Task<bool> CheckUserBelongsToGroupAsync(Guid userId, Guid groupId);
    }
} 