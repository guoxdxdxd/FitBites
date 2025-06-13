using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.Dtos;
using FitBites.Application.DTOs;
using FitBites.Application.Extensions;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 用户人群标签控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserHumanGroupController : ControllerBase
    {
        private readonly IUserHumanGroupService _userHumanGroupService;
        private readonly IUserService _userService;
        private readonly ILogger<UserHumanGroupController> _logger;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userHumanGroupService">用户人群标签服务</param>
        /// <param name="userService">用户服务</param>
        /// <param name="logger">日志服务</param>
        public UserHumanGroupController(
            IUserHumanGroupService userHumanGroupService,
            IUserService userService,
            ILogger<UserHumanGroupController> logger)
        {
            _userHumanGroupService = userHumanGroupService;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// 获取用户的所有人群标签
        /// </summary>
        /// <returns>用户人群标签列表</returns>
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUserHumanGroups()
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userHumanGroupService.GetUserHumanGroupsAsync(user.UserId);
                return Ok(ApiResult<List<UserHumanGroupDto>>.Success(result));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "获取用户人群标签失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "获取用户人群标签失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户人群标签发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 获取用户特定人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>用户人群标签</returns>
        [HttpGet("group/{groupId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetUserHumanGroup(Guid groupId)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userHumanGroupService.GetUserHumanGroupAsync(user.UserId, groupId);
                if (result == null)
                    return NotFound(ApiResult<string>.Fail("用户人群标签不存在"));

                return Ok(ApiResult<UserHumanGroupDto>.Success(result));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "获取用户人群标签失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "获取用户人群标签失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取用户人群标签发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 添加用户人群标签
        /// </summary>
        /// <param name="dto">添加用户人群标签请求</param>
        /// <returns>添加的用户人群标签</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResult<UserHumanGroupDto>>> AddUserHumanGroup(AddUserHumanGroupDto dto)
        {
            try
            {
                var result = await _userHumanGroupService.AddUserHumanGroupAsync(dto);
                return ApiResult<UserHumanGroupDto>.Success(result);
            }
            catch (Exception ex)
            {
                return ApiResult<UserHumanGroupDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新用户人群标签
        /// </summary>
        /// <param name="dto">更新用户人群标签请求</param>
        /// <returns>更新后的用户人群标签</returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResult<UserHumanGroupDto>>> UpdateUserHumanGroup(UpdateUserHumanGroupDto dto)
        {
            try
            {
                var result = await _userHumanGroupService.UpdateUserHumanGroupAsync(dto);
                return ApiResult<UserHumanGroupDto>.Success(result);
            }
            catch (Exception ex)
            {
                return ApiResult<UserHumanGroupDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除用户人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否删除成功</returns>
        [HttpDelete("group/{groupId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserHumanGroup(Guid groupId)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userHumanGroupService.DeleteUserHumanGroupAsync(user.UserId, groupId);
                
                if (!result)
                    return NotFound(ApiResult<string>.Fail("删除失败，用户人群标签不存在"));

                return Ok(ApiResult<bool>.Success(true, "删除成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "删除用户人群标签失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "删除用户人群标签失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除用户人群标签发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }

        /// <summary>
        /// 检查用户是否属于指定人群
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否属于该人群</returns>
        [HttpGet("check/group/{groupId}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> CheckUserBelongsToGroup(Guid groupId)
        {
            try
            {
                var user = HttpContext.GetCurrentUser(_userService);
                var result = await _userHumanGroupService.CheckUserBelongsToGroupAsync(user.UserId, groupId);
                return Ok(ApiResult<bool>.Success(result));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "检查用户人群归属失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "检查用户人群归属失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查用户人群归属发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
    }
} 