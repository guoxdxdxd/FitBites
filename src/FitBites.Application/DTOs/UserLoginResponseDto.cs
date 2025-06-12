using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 用户登录响应DTO
    /// </summary>
    public class UserLoginResponseDto
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserDto User { get; set; }
        
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }
        
        /// <summary>
        /// 令牌类型
        /// </summary>
        public string TokenType { get; set; }
        
        /// <summary>
        /// 过期时间（分钟）
        /// </summary>
        public int ExpiresIn { get; set; }
        
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string? RefreshToken { get; set; }
        
        /// <summary>
        /// 刷新令牌过期时间（分钟）
        /// </summary>
        public int? RefreshTokenExpiresIn { get; set; }
    }
} 