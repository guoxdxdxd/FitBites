using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 角色应用服务接口
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 获取所有角色
        /// </summary>
        Task<List<RoleDto>> GetAllAsync();

        /// <summary>
        /// 根据ID获取角色
        /// </summary>
        Task<RoleDto> GetByIdAsync(Guid id);

        /// <summary>
        /// 创建角色
        /// </summary>
        Task<RoleDto> CreateAsync(RoleDto dto);

        /// <summary>
        /// 更新角色
        /// </summary>
        Task<RoleDto> UpdateAsync(RoleDto dto);

        /// <summary>
        /// 删除角色
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 设置角色权限
        /// </summary>
        Task SetPermissionsAsync(Guid roleId, List<Guid> permissionIds);
    }
} 