using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Dtos.Preference;
using FitBites.Application.Services.Preference;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitBites.WebApi.Controllers
{
    /// <summary>
    /// 偏好控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PreferenceController : ControllerBase
    {
        private readonly IPreferenceService _preferenceService;
        private readonly ILogger<PreferenceController> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="preferenceService">偏好服务</param>
        /// <param name="logger">日志记录器</param>
        public PreferenceController(
            IPreferenceService preferenceService,
            ILogger<PreferenceController> logger)
        {
            _preferenceService = preferenceService;
            _logger = logger;
        }

        /// <summary>
        /// 查询偏好列表
        /// </summary>
        /// <param name="queryDto">查询参数</param>
        /// <returns>偏好项目列表</returns>
        [HttpGet("items")]
        public async Task<ActionResult<List<PreferenceItemDto>>> GetPreferenceItems([FromQuery] PreferenceQueryDto queryDto)
        {
            var result = await _preferenceService.GetPreferenceItemsAsync(queryDto);
            return Ok(ApiResult<List<PreferenceItemDto>>.Success(result, "查询成功"));
        }
        
        /// <summary>
        /// 创建偏好项
        /// </summary>
        /// <param name="createDto">创建参数</param>
        /// <returns>创建的偏好项</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PreferenceItemDto>> CreatePreference([FromBody] PreferenceCreateDto createDto)
        {
            _logger.LogInformation("接收到创建偏好项请求: {PreferenceType}, {Name}", createDto.Type, createDto.Name);
            
            try
            {
                var result = await _preferenceService.CreatePreferenceAsync(createDto);
                return Ok(ApiResult<PreferenceItemDto>.Success(result, "创建成功"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建偏好项失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string?>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 更新偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="updateDto">更新参数</param>
        /// <returns>更新结果</returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdatePreference(Guid id, [FromBody] PreferenceUpdateDto updateDto)
        {
            _logger.LogInformation("接收到更新偏好项请求: {Id}, {Name}", id, updateDto.Name);
            
            try
            {
                await _preferenceService.UpdatePreferenceAsync(id, updateDto);
                return Ok(ApiResult<string?>.Success(null, "更新成功"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新偏好项失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string?>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 删除偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        /// <returns>删除结果</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePreference(Guid id, [FromQuery] PreferenceTargetType type)
        {
            _logger.LogInformation("接收到删除偏好项请求: {Id}, {Type}", id, type);
            
            try
            {
                await _preferenceService.DeletePreferenceAsync(id, type);
                return Ok(ApiResult<string?>.Success(null, "删除成功"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除偏好项失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string?>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 启用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        /// <returns>操作结果</returns>
        [HttpPatch("{id}/enable")]
        [Authorize]
        public async Task<ActionResult> EnablePreference(Guid id, [FromQuery] PreferenceTargetType type)
        {
            _logger.LogInformation("接收到启用偏好项请求: {Id}, {Type}", id, type);
            
            try
            {
                await _preferenceService.EnablePreferenceAsync(id, type);
                return Ok(ApiResult<string?>.Success(null, "启用成功"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "启用偏好项失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string?>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 禁用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        /// <returns>操作结果</returns>
        [HttpPatch("{id}/disable")]
        [Authorize]
        public async Task<ActionResult> DisablePreference(Guid id, [FromQuery] PreferenceTargetType type)
        {
            _logger.LogInformation("接收到禁用偏好项请求: {Id}, {Type}", id, type);
            
            try
            {
                await _preferenceService.DisablePreferenceAsync(id, type);
                return Ok(ApiResult<string?>.Success(null, "禁用成功"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "禁用偏好项失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string?>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 刷新偏好缓存
        /// </summary>
        /// <returns>操作结果</returns>
        /// <remarks>
        /// 此API用于在偏好数据变更后手动刷新Redis缓存
        /// 需要管理员权限
        /// </remarks>
        [HttpPost("refresh-cache")]
        public async Task<ActionResult> RefreshCache()
        {
            _logger.LogInformation("接收到刷新偏好缓存的请求");
            
            try
            {
                await _preferenceService.RefreshPreferenceCacheAsync();
                _logger.LogInformation("偏好缓存刷新成功");
                return Ok(ApiResult<string?>.Success(null,"偏好缓存刷新成功"));
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "偏好缓存刷新失败");
                return StatusCode(500, ApiResult<string?>.Fail("偏好缓存刷新失败：" + ex.Message));
            }
        }
    }
}