using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.Dtos;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 用户偏好应用服务接口
    /// </summary>
    public interface IUserPreferenceService : IScopedDependency
    {
        /// <summary>
        /// 获取用户所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户偏好DTO列表</returns>
        Task<List<UserPreferenceDto>> GetUserPreferencesAsync(Guid userId);
        
        /// <summary>
        /// 获取用户指定类型的所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>用户偏好DTO列表</returns>
        Task<List<UserPreferenceDto>> GetUserPreferencesByTypeAsync(Guid userId, PreferenceTargetType targetType);

        /// <summary>
        /// 添加用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="dto">创建用户偏好DTO</param>
        /// <returns>用户偏好DTO</returns>
        Task<UserPreferenceDto> AddPreferenceAsync(Guid userId, CreateUserPreferenceDto dto);
        
        /// <summary>
        /// 更新用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="dto">更新用户偏好DTO</param>
        /// <returns>用户偏好DTO</returns>
        Task UpdatePreferenceAsync(Guid userId, UpdateUserPreferenceDto dto);
        
        /// <summary>
        /// 删除用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userPreferenceId">偏好ID</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeletePreferenceAsync(Guid userId, Guid userPreferenceId);
        
        /// <summary>
        /// 删除用户指定目标的偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="targetId">目标ID</param>
        /// <returns>是否删除成功</returns>
        Task<bool> DeletePreferenceByTargetAsync(Guid userId, PreferenceTargetType targetType, Guid targetId);
    }
} 