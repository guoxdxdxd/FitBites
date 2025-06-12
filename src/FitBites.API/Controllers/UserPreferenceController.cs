using FitBites.Application.Dtos;
using FitBites.Application.DTOs;
using FitBites.Application.Extensions;
using FitBites.Application.Services;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Enums;
using FitBites.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 用户偏好控制器
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserPreferenceController : ControllerBase
    {
        private readonly IUserPreferenceService _userPreferenceService;
        private readonly IUserService _userService;
        private readonly ILogger<UserPreferenceController> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserPreferenceController(
            IUserPreferenceService userPreferenceService,
            IUserService userService,
            ILogger<UserPreferenceController> logger)
        {
            _userPreferenceService = userPreferenceService;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// 获取当前用户所有偏好
        /// </summary>
        /// <returns>用户偏好列表</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPreferences()
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var preferences = await _userPreferenceService.GetUserPreferencesAsync(user.UserId);
                return Ok(ApiResult<List<UserPreferenceDto>>.Success(preferences, "获取用户偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "获取用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "获取用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 获取当前用户指定类型的所有偏好
        /// </summary>
        /// <param name="targetType">目标类型</param>
        /// <returns>用户偏好列表</returns>
        [HttpGet("by-type/{targetType}")]
        [Authorize]
        public async Task<IActionResult> GetUserPreferencesByType(PreferenceTargetType targetType)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var preferences = await _userPreferenceService.GetUserPreferencesByTypeAsync(user.UserId, targetType);
                return Ok(ApiResult<List<UserPreferenceDto>>.Success(preferences, "获取用户偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "获取用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "获取用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 添加用户偏好
        /// </summary>
        /// <param name="dto">创建用户偏好DTO</param>
        /// <returns>用户偏好DTO</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPreference([FromBody] CreateUserPreferenceDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResult<string>.Fail("请求参数错误"));
                }
                
                var user = HttpContext.GetCurrentUser(_userService);
                var preference = await _userPreferenceService.AddPreferenceAsync(user.UserId, dto);
                return Ok(ApiResult<UserPreferenceDto>.Success(preference, "添加偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "添加用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "添加用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "添加用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 更新用户偏好
        /// </summary>
        /// <param name="dto">更新用户偏好DTO</param>
        /// <returns>操作结果</returns>
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdatePreference([FromBody] UpdateUserPreferenceDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResult<string>.Fail("请求参数错误"));
                }
                
                var user = HttpContext.GetCurrentUser(_userService);
                await _userPreferenceService.UpdatePreferenceAsync(user.UserId, dto);
                return Ok(ApiResult<string>.Success("更新偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "更新用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "更新用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 删除用户偏好
        /// </summary>
        /// <param name="preferenceId">偏好ID</param>
        /// <returns>操作结果</returns>
        [HttpDelete("{preferenceId}")]
        [Authorize]
        public async Task<IActionResult> DeletePreference(Guid preferenceId)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userPreferenceService.DeletePreferenceAsync(user.UserId, preferenceId);
                
                if (!result)
                {
                    return NotFound(ApiResult<string>.Fail("偏好不存在或已删除"));
                }
                
                return Ok(ApiResult<string>.Success("删除偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "删除用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "删除用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 删除用户指定目标的偏好
        /// </summary>
        /// <param name="targetType">目标类型</param>
        /// <param name="targetId">目标ID</param>
        /// <returns>操作结果</returns>
        [HttpDelete("by-target/{targetType}/{targetId}")]
        [Authorize]
        public async Task<IActionResult> DeletePreferenceByTarget(PreferenceTargetType targetType, Guid targetId)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userPreferenceService.DeletePreferenceByTargetAsync(user.UserId, targetType, targetId);
                
                if (!result)
                {
                    return NotFound(ApiResult<string>.Fail("偏好不存在或已删除"));
                }
                
                return Ok(ApiResult<string>.Success("删除偏好成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "删除用户偏好失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "删除用户偏好失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除用户偏好发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
    }
} 