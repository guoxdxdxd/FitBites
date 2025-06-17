using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 角色应用服务实现
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return roles.Select(r => ToDto(r)).ToList();
        }

        /// <summary>
        /// 根据ID获取角色
        /// </summary>
        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetRoleWithPermissionsAsync(id);
            return ToDto(role);
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        public async Task<RoleDto> CreateAsync(RoleDto dto)
        {
            // 领域层可加唯一性校验等
            var role = new Role(Guid.NewGuid(), dto.RoleCode, dto.RoleName, dto.Description, DateTime.Now, DateTime.Now);
            await _roleRepository.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(role);
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        public async Task<RoleDto> UpdateAsync(RoleDto dto)
        {
            var role = await _roleRepository.GetByIdAsync(dto.Id);
            if (role == null) throw new Exception("角色不存在");
            // 充血模型：通过方法修改属性
            role.Update(dto.RoleName, dto.Description);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(role);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            await _roleRepository.RemoveAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        public async Task SetPermissionsAsync(Guid roleId, List<Guid> permissionIds)
        {
            var role = await _roleRepository.GetRoleWithPermissionsAsync(roleId);
            if (role == null) throw new Exception("角色不存在");
            // 充血模型：清空原有权限，添加新权限
            role.SetPermissions(permissionIds);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 实体转DTO
        /// </summary>
        private RoleDto ToDto(Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                RoleCode = role.RoleCode,
                RoleName = role.RoleName,
                Description = role.Description,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt,
                PermissionIds = role.PermissionMappings?.Select(pm => pm.PermissionId).ToList() ?? new List<Guid>(),
                PermissionNames = role.PermissionMappings?.Select(pm => pm.Permission?.Description).Where(n => n != null).ToList() ?? new List<string>()
            };
        }
    }
} 