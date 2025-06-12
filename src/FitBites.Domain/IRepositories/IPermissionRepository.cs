using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 权限仓储接口
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户权限列表</returns>
        Task<List<Permission>> GetUserPermissionsAsync(Guid userId);
        
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>角色权限列表</returns>
        Task<List<Permission>> GetRolePermissionsAsync(Guid roleId);
    }
} 