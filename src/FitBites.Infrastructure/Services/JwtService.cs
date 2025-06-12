using System;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using FitBites.Core.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace FitBites.Infrastructure.Services
{
    /// <summary>
    /// JWT服务，提供统一的JWT配置和令牌验证参数
    /// </summary>
    public class JwtService:ISingletonDependency
    {
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置</param>
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            // 创建令牌验证参数
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "FitBitesSecretKey123456789012345678901234"))
            };
        }

        /// <summary>
        /// 获取令牌验证参数
        /// </summary>
        /// <returns>令牌验证参数</returns>
        public TokenValidationParameters GetTokenValidationParameters()
        {
            return _tokenValidationParameters;
        }
        
        /// <summary>
        /// 获取JWT密钥
        /// </summary>
        /// <returns>SymmetricSecurityKey</returns>
        public SymmetricSecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "FitBitesSecretKey123456789012345678901234"));
        }
    }
} 