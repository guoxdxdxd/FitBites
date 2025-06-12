using System.ComponentModel.DataAnnotations;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 用户登录DTO
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// 用户名或手机号
        /// </summary>
        [Required(ErrorMessage = "用户名/手机号不能为空")]
        public string Account { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
    }
} 