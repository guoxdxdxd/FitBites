using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.Dtos;
using FitBites.Core.DependencyInjection;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 用户人群标签服务接口
    /// </summary>
    public interface IUserHumanGroupService : IScopedDependency
    {
        /// <summary>
        /// 获取用户的所有人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户人群标签列表</returns>
        Task<List<UserHumanGroupDto>> GetUserHumanGroupsAsync(Guid userId);
        
        /// <summary>
        /// 获取用户特定人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>用户人群标签</returns>
        Task<UserHumanGroupDto> GetUserHumanGroupAsync(Guid userId, Guid groupId);
        
        /// <summary>
        /// 添加用户人群标签
        /// </summary>
        /// <param name="dto">添加用户人群标签请求</param>
        /// <returns>添加的用户人群标签</returns>
        Task<UserHumanGroupDto> AddUserHumanGroupAsync(AddUserHumanGroupDto dto);
        
        /// <summary>
        /// 更新用户人群标签
        /// </summary>
        /// <param name="dto">更新用户人群标签请求</param>
        /// <returns>更新后的用户人群标签</returns>
        Task<UserHumanGroupDto> UpdateUserHumanGroupAsync(UpdateUserHumanGroupDto dto);
        
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