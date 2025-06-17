using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 权限应用服务接口
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 获取所有权限
        /// </summary>
        Task<List<PermissionDto>> GetAllAsync();

        /// <summary>
        /// 根据ID获取权限
        /// </summary>
        Task<PermissionDto> GetByIdAsync(Guid id);

        /// <summary>
        /// 创建权限
        /// </summary>
        Task<PermissionDto> CreateAsync(PermissionDto dto);

        /// <summary>
        /// 更新权限
        /// </summary>
        Task<PermissionDto> UpdateAsync(PermissionDto dto);

        /// <summary>
        /// 删除权限
        /// </summary>
        Task DeleteAsync(Guid id);
    }
} 