using System;
using System.ComponentModel.DataAnnotations;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 刷新令牌请求DTO
    /// </summary>
    public class RefreshTokenDto
    {
        /// <summary>
        /// 刷新令牌
        /// </summary>
        [Required(ErrorMessage = "刷新令牌不能为空")]
        public string RefreshToken { get; set; }
    }
} 