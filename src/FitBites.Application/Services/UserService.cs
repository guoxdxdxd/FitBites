using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Constants;
using FitBites.Core.Interfaces;
using FitBites.Domain;
using FitBites.Domain.Constants;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Domain.Services;
using FitBites.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IUserDomainService _userDomainService;
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="configuration">配置</param>
        /// <param name="userDomainService">用户领域服务</param>
        /// <param name="userRepository">用户仓库</param>
        /// <param name="jwtService">JWT服务</param>
        public UserService(
            IUnitOfWork unitOfWork, 
            IConfiguration configuration, 
            IUserDomainService userDomainService,
            IUserRepository userRepository,
            JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _userDomainService = userDomainService;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userRegisterDto">用户注册信息</param>
        /// <returns>注册结果</returns>
        public async Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            try
            {
                // 调用领域服务创建用户
                var user = await _userDomainService.CreateUserAsync(
                    userRegisterDto.Username,
                    userRegisterDto.Password,
                    userRegisterDto.Phone,
                    RoleConstants.USER_ROLE_ID // 普通用户角色ID
                );
                
                // 保存到数据库
                await _unitOfWork.GetRepository<User>().AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                
                // 返回用户DTO
                return MapToUserDto(user);
            }
            catch (DomainException ex)
            {
                // 领域异常转换为应用异常
                throw new ApplicationException(ex.Message, ex);
            }
        }
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userLoginDto">用户登录信息</param>
        /// <returns>登录结果</returns>
        public async Task<UserLoginResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                // 使用领域服务验证用户登录
                var user = await _userDomainService.ValidateUserLoginAsync(
                    userLoginDto.Account,
                    userLoginDto.Password
                );
         
                // 生成JWT令牌
                var token = GenerateJwtToken(user);
                var expiresMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");
                
                // 生成刷新令牌
                var refreshTokenExpiresMinutes = int.Parse(_configuration["Jwt:RefreshTokenExpireMinutes"] ?? "10080"); // 默认7天
                var refreshTokenExpireTime = DateTime.UtcNow.AddMinutes(refreshTokenExpiresMinutes);
                user.GenerateRefreshToken(refreshTokenExpireTime);

                await _unitOfWork.SaveChangesAsync();
                    
                // 构建返回结果
                return new UserLoginResponseDto
                {
                    User = MapToUserDto(user),
                    AccessToken = token,
                    TokenType = "Bearer",
                    ExpiresIn = expiresMinutes,
                    RefreshToken = user.RefreshToken,
                    RefreshTokenExpiresIn = refreshTokenExpiresMinutes
                };
            }
            catch (DomainException ex)
            {
                // 领域异常转换为应用异常
                throw new ApplicationException(ex.Message, ex);
            }
        }
        
        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="refreshTokenDto">刷新令牌信息</param>
        /// <returns>刷新结果</returns>
        public async Task<UserLoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            try
            {
                // 使用领域服务验证刷新令牌
                var user = await _userDomainService.ValidateRefreshTokenAsync(refreshTokenDto.RefreshToken);
                
                // 生成新的JWT令牌
                var token = GenerateJwtToken(user);
                var expiresMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");
                
                // 生成新的刷新令牌
                var refreshTokenExpiresMinutes = int.Parse(_configuration["Jwt:RefreshTokenExpireMinutes"] ?? "10080"); // 默认7天
                var refreshTokenExpireTime = DateTime.UtcNow.AddMinutes(refreshTokenExpiresMinutes);
                user.GenerateRefreshToken(refreshTokenExpireTime);
                
                await _unitOfWork.SaveChangesAsync();
                
                // 构建返回结果
                return new UserLoginResponseDto
                {
                    User = MapToUserDto(user),
                    AccessToken = token,
                    TokenType = "Bearer",
                    ExpiresIn = expiresMinutes,
                    RefreshToken = user.RefreshToken,
                    RefreshTokenExpiresIn = refreshTokenExpiresMinutes
                };
            }
            catch (DomainException ex)
            {
                // 领域异常转换为应用异常
                throw new ApplicationException(ex.Message, ex);
            }
        }
        
        /// <summary>
        /// 检查用户名是否已存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            return await _unitOfWork.GetRepository<User>().ExistsAsync(u => u.Username == username);
        }
        
        /// <summary>
        /// 检查手机号是否已存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>是否存在</returns>
        public async Task<bool> IsPhoneExistsAsync(string phone)
        {
            return await _unitOfWork.GetRepository<User>().ExistsAsync(u => u.Phone == phone);
        }
        
        /// <summary>
        /// 将用户实体映射为DTO
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>用户DTO</returns>
        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserCode = user.UserCode,
                Username = user.Username,
                Phone = user.Phone,
                Nickname = user.Nickname,
                Avatar = user.Avatar,
                CreatedAt = user.CreatedAt
            };
        }
        
        /// <summary>
        /// 从JWT令牌中解析用户信息
        /// </summary>
        /// <param name="principal">用户信息</param>
        /// <returns>用户信息DTO</returns>
        public UserTokenInfoDto ParseUserFromToken(ClaimsPrincipal principal)
        {
            try
            {
                // 提取声明
                var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
                {
                    throw new ApplicationException("令牌中缺少用户ID或格式无效");
                }
                
                // 构建用户信息DTO
                var userTokenInfo = new UserTokenInfoDto
                {
                    UserId = userId,
                    Username = principal.FindFirst(ClaimTypes.Name)?.Value,
                    UserCode = principal.FindFirst("userCode")?.Value,
                    Phone = principal.FindFirst("phone")?.Value,
                    Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList(),
                    Permissions = principal.FindAll("permission").Select(c => c.Value).ToList()
                };
                
                return userTokenInfo;
            }
            catch (SecurityTokenExpiredException)
            {
                throw new ApplicationException("令牌已过期");
            }
            catch (SecurityTokenException ex)
            {
                throw new ApplicationException($"令牌验证失败: {ex.Message}");
            }
        }
        
        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>JWT令牌</returns>
        private string GenerateJwtToken(User user)
        {
            var securityKey = _jwtService.GetSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            // 准备声明
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("userCode", user.UserCode),
                new Claim("phone", user.Phone ?? "")
            };
            
            // 添加角色声明
            foreach (var role in user.UserRoles.Select(o => o.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleCode));
            }
            
            // 添加权限声明
            foreach (var permission in user.AllPermissions)
            {
                claims.Add(new Claim("permission", permission.PermissionCode));
            }
            
            // 设置令牌有效期
            var expiresMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");
            var expiration = DateTime.UtcNow.AddMinutes(expiresMinutes);
            
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 