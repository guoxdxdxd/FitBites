using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Core.Interfaces;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 权限应用服务实现
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
        {
            _permissionRepository = permissionRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        public async Task<List<PermissionDto>> GetAllAsync()
        {
            var permissions = await _permissionRepository.GetAllAsync();
            return permissions.Select(ToDto).ToList();
        }

        /// <summary>
        /// 根据ID获取权限
        /// </summary>
        public async Task<PermissionDto> GetByIdAsync(Guid id)
        {
            var permission = await _permissionRepository.GetByIdAsync(id);
            return permission == null ? null : ToDto(permission);
        }

        /// <summary>
        /// 创建权限
        /// </summary>
        public async Task<PermissionDto> CreateAsync(PermissionDto dto)
        {
            // 可加唯一性校验
            var entity = new Permission(Guid.NewGuid(), dto.PermissionCode, dto.Description, dto.Module, DateTime.UtcNow, DateTime.UtcNow);
            await _permissionRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        /// <summary>
        /// 更新权限
        /// </summary>
        public async Task<PermissionDto> UpdateAsync(PermissionDto dto)
        {
            var entity = await _permissionRepository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("权限不存在");
            // 充血模型：通过方法修改属性（如有）
            // 这里只能直接赋值，若有Update方法应调用
            entity.GetType().GetProperty("Description")?.SetValue(entity, dto.Description);
            entity.GetType().GetProperty("Module")?.SetValue(entity, dto.Module);
            entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.UtcNow);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _permissionRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("权限不存在");
            await _permissionRepository.RemoveAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 实体转DTO
        /// </summary>
        private PermissionDto ToDto(Permission entity)
        {
            return new PermissionDto
            {
                Id = entity.Id,
                PermissionCode = entity.PermissionCode,
                Description = entity.Description,
                Module = entity.Module,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
} 