using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 角色管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<RoleDto>>>> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(ApiResult<List<RoleDto>>.Success(roles));
        }

        /// <summary>
        /// 根据ID获取角色
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<RoleDto>>> GetById(Guid id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound(ApiResult<RoleDto>.Fail("角色不存在"));
            return Ok(ApiResult<RoleDto>.Success(role));
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResult<RoleDto>>> Create(RoleDto dto)
        {
            var role = await _roleService.CreateAsync(dto);
            return Ok(ApiResult<RoleDto>.Success(role, "角色创建成功"));
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ApiResult<RoleDto>>> Update(RoleDto dto)
        {
            var role = await _roleService.UpdateAsync(dto);
            return Ok(ApiResult<RoleDto>.Success(role, "角色更新成功"));
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(Guid id)
        {
            await _roleService.DeleteAsync(id);
            return ApiResult.Success("角色删除成功");
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        [HttpPost("{id}/permissions")]
        public async Task<ApiResult> SetPermissions(Guid id, [FromBody] List<Guid> permissionIds)
        {
            await _roleService.SetPermissionsAsync(id, permissionIds);
            return ApiResult.Success("权限设置成功");
        }
    }
} 