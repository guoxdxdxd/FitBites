using System;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services;
using FitBites.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FitBites.Application.Extensions;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService">用户服务</param>
        /// <param name="logger">日志记录器</param>
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userLoginDto">用户登录信息</param>
        /// <returns>登录结果</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResult<string>.Fail("请求参数错误"));
                }
                
                var result = await _userService.LoginAsync(userLoginDto);
                return Ok(ApiResult<UserLoginResponseDto>.Success(result, "登录成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "用户登录失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "用户登录失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "用户登录发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
        
        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="refreshTokenDto">刷新令牌信息</param>
        /// <returns>刷新结果</returns>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResult<string>.Fail("请求参数错误"));
                }
                
                var result = await _userService.RefreshTokenAsync(refreshTokenDto);
                return Ok(ApiResult<UserLoginResponseDto>.Success(result, "刷新令牌成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "刷新令牌失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "刷新令牌失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "刷新令牌发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
        
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userRegisterDto">用户注册信息</param>
        /// <returns>注册结果</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResult<string>.Fail("请求参数错误"));
                }
                
                var result = await _userService.RegisterAsync(userRegisterDto);
                return Ok(ApiResult<UserDto>.Success(result, "注册成功"));
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "用户注册失败（领域异常）: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (ApplicationException ex)
            {
                _logger.LogWarning(ex, "用户注册失败: {Message}", ex.Message);
                return BadRequest(ApiResult<string>.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "用户注册发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
        
        /// <summary>
        /// 检查用户名是否可用
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>是否可用</returns>
        [HttpGet("check-username")]
        public async Task<IActionResult> CheckUsername([FromQuery] string username)
        {
            try
            {
                var exists = await _userService.IsUsernameExistsAsync(username);
                return Ok(ApiResult<bool>.Success(!exists, exists ? "用户名已存在" : "用户名可用"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查用户名发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
        
        /// <summary>
        /// 检查手机号是否可用
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>是否可用</returns>
        [HttpGet("check-phone")]
        public async Task<IActionResult> CheckPhone([FromQuery] string phone)
        {
            try
            {
                var exists = await _userService.IsPhoneExistsAsync(phone);
                return Ok(ApiResult<bool>.Success(!exists, exists ? "手机号已存在" : "手机号可用"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查手机号发生异常");
                return StatusCode(500, ApiResult<string>.Fail("服务器内部错误，请稍后再试"));
            }
        }
        
        /// <summary>
        /// 校验权限
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            var user = HttpContext.GetCurrentUser(_userService);
            return Ok(ApiResult<UserTokenInfoDto?>.Success(user));
        }
    }
} 