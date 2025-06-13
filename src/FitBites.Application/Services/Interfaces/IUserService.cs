using System.Security.Claims;
using FitBites.Application.DTOs;
using FitBites.Core.DependencyInjection;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService : IScopedDependency
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userRegisterDto">用户注册信息</param>
        /// <returns>注册结果</returns>
        Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto);
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userLoginDto">用户登录信息</param>
        /// <returns>登录结果</returns>
        Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto);
        
        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="refreshTokenDto">刷新令牌信息</param>
        /// <returns>刷新结果</returns>
        Task<UserLoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
        
        /// <summary>
        /// 检查用户名是否已存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>是否存在</returns>
        Task<bool> IsUsernameExistsAsync(string username);
        
        /// <summary>
        /// 检查手机号是否已存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>是否存在</returns>
        Task<bool> IsPhoneExistsAsync(string phone);
        
        /// <summary>
        /// 从JWT令牌中解析用户信息
        /// </summary>
        /// <param name="principal">用户信息</param>
        /// <returns>用户信息DTO</returns>
        UserTokenInfoDto ParseUserFromToken(ClaimsPrincipal principal);
    }
} 