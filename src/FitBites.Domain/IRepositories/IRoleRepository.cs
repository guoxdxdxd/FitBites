using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 角色仓储接口
    /// </summary>
    public interface IRoleRepository : IRepository<Role>
    {
        /// <summary>
        /// 根据角色代码获取角色
        /// </summary>
        /// <param name="roleCode">角色代码</param>
        /// <returns>角色实体</returns>
        Task<Role?> GetRoleByCodeAsync(string roleCode);
        
        /// <summary>
        /// 获取角色及其权限信息
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns>角色实体，包含权限信息</returns>
        Task<Role?> GetRoleWithPermissionsAsync(Guid roleId);
        
        /// <summary>
        /// 获取用户所有角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>角色列表</returns>
        Task<List<Role>> GetUserRolesAsync(Guid userId);

    }
} 