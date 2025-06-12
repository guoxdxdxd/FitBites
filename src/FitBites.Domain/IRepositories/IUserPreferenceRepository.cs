using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 用户偏好仓储接口
    /// </summary>
    public interface IUserPreferenceRepository : IRepository<UserPreference>
    {
        /// <summary>
        /// 获取用户所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户偏好列表</returns>
        Task<List<UserPreference>> GetUserPreferencesAsync(Guid userId);
        
        /// <summary>
        /// 获取用户指定类型的所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>用户偏好列表</returns>
        Task<List<UserPreference>> GetUserPreferencesByTypeAsync(Guid userId, PreferenceTargetType targetType);
    }
} 