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
    /// 权限管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(IPermissionService permissionService, ILogger<PermissionController> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有权限
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<PermissionDto>>>> GetAll()
        {
            var permissions = await _permissionService.GetAllAsync();
            return Ok(ApiResult<List<PermissionDto>>.Success(permissions));
        }

        /// <summary>
        /// 根据ID获取权限
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<PermissionDto>>> GetById(Guid id)
        {
            var permission = await _permissionService.GetByIdAsync(id);
            if (permission == null) return NotFound(ApiResult<PermissionDto>.Fail("权限不存在"));
            return Ok(ApiResult<PermissionDto>.Success(permission));
        }

        /// <summary>
        /// 创建权限
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ApiResult<PermissionDto>>> Create(PermissionDto dto)
        {
            var permission = await _permissionService.CreateAsync(dto);
            return Ok(ApiResult<PermissionDto>.Success(permission, "权限创建成功"));
        }

        /// <summary>
        /// 更新权限
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<ApiResult<PermissionDto>>> Update(PermissionDto dto)
        {
            var permission = await _permissionService.UpdateAsync(dto);
            return Ok(ApiResult<PermissionDto>.Success(permission, "权限更新成功"));
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(Guid id)
        {
            await _permissionService.DeleteAsync(id);
            return ApiResult.Success("权限删除成功");
        }
    }
} 