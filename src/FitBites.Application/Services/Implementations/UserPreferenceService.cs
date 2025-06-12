using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.Dtos;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Enums;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace FitBites.Application.Services.Implementations
{
    /// <summary>
    /// 用户偏好应用服务实现
    /// </summary>
    public class UserPreferenceService : IUserPreferenceService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserPreferenceService> _logger;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userRepository">用户仓储</param>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="logger">日志记录器</param>
        public UserPreferenceService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ILogger<UserPreferenceService> logger)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        /// <summary>
        /// 获取用户所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户偏好DTO列表</returns>
        public async Task<List<UserPreferenceDto>> GetUserPreferencesAsync(Guid userId)
        {
            var user = await _userRepository.GetWithPreferencesByIdAsync(userId, null);
            if (user == null)
            {
                _logger.LogWarning("更新用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                throw new ApplicationException($"用户不存在：{userId}");
            }
            return user.UserPreferences.Select(UserPreferenceDto.FromEntity).ToList();
        }
        
        /// <summary>
        /// 获取用户指定类型的所有偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>用户偏好DTO列表</returns>
        public async Task<List<UserPreferenceDto>> GetUserPreferencesByTypeAsync(Guid userId, PreferenceTargetType targetType)
        {
            var user = await _userRepository.GetWithPreferencesByIdAsync(userId, targetType);
            if (user == null)
            {
                _logger.LogWarning("更新用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                throw new ApplicationException($"用户不存在：{userId}");
            }
            
            return user.UserPreferences
                .Select(UserPreferenceDto.FromEntity).ToList();
        }
        
        /// <summary>
        /// 添加用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="dto">创建用户偏好DTO</param>
        /// <returns>用户偏好DTO</returns>
        public async Task<UserPreferenceDto> AddPreferenceAsync(Guid userId, CreateUserPreferenceDto dto)
        {
            // 获取用户
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("添加用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                throw new ApplicationException($"用户不存在：{userId}");
            }
            
            // 添加偏好
            var preference = user.AddPreference(dto.TargetType, dto.TargetId, dto.PreferenceType, dto.Remark);
            
            // 保存更改
            await _unitOfWork.SaveChangesAsync();
            
            _logger.LogInformation("添加用户偏好成功：用户ID：{UserId}，偏好ID：{PreferenceId}", userId, preference.Id);
            
            return UserPreferenceDto.FromEntity(preference);
        }
        
        /// <summary>
        /// 更新用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="dto">更新用户偏好DTO</param>
        /// <returns>用户偏好DTO</returns>
        public async Task UpdatePreferenceAsync(Guid userId, UpdateUserPreferenceDto dto)
        {
            // 获取用户
            var user = await _userRepository.GetWithPreferencesByIdAsync(userId, null, dto.UserPreferenceId);
            if (user == null)
            {
                _logger.LogWarning("更新用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                throw new ApplicationException($"用户不存在：{userId}");
            }
            
            // 更新偏好
            var success = user.UpdatePreference(dto.UserPreferenceId, dto.PreferenceType, dto.Remark);
            if (!success)
            {
                _logger.LogWarning("更新用户偏好失败：更新操作返回失败，偏好ID：{PreferenceId}", dto.UserPreferenceId);
                throw new ApplicationException($"更新偏好失败：{dto.UserPreferenceId}");
            }
            
            // 保存更改
            await _unitOfWork.SaveChangesAsync();
            
            _logger.LogInformation("更新用户偏好成功：用户ID：{UserId}，偏好ID：{PreferenceId}", userId, dto.UserPreferenceId);
        }
        
        /// <summary>
        /// 删除用户偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userPreferenceId">偏好ID</param>
        /// <returns>是否删除成功</returns>
        public async Task<bool> DeletePreferenceAsync(Guid userId, Guid userPreferenceId)
        {
            // 获取用户
            var user = await _userRepository.GetWithPreferencesByIdAsync(userId, null, userPreferenceId);
            if (user == null)
            {
                _logger.LogWarning("删除用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                return false;
            }
            
            // 删除偏好
            var success = user.RemovePreference(userPreferenceId);
            if (!success)
            {
                _logger.LogWarning("删除用户偏好失败：删除操作返回失败，偏好ID：{PreferenceId}", userPreferenceId);
                return false;
            }
            
            // 保存更改
            await _unitOfWork.SaveChangesAsync();
            
            _logger.LogInformation("删除用户偏好成功：用户ID：{UserId}，偏好ID：{PreferenceId}", userId, userPreferenceId);
            
            return true;
        }
        
        /// <summary>
        /// 删除用户指定目标的偏好
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="targetId">目标ID</param>
        /// <returns>是否删除成功</returns>
        public async Task<bool> DeletePreferenceByTargetAsync(Guid userId, PreferenceTargetType targetType, Guid targetId)
        {
            // 获取用户
            var user = await _userRepository.GetWithPreferencesByIdAsync(userId, targetType);
            if (user == null)
            {
                _logger.LogWarning("删除用户偏好失败：用户不存在，用户ID：{UserId}", userId);
                return false;
            }
            
            // 删除偏好
            var success = user.RemovePreferenceByTarget(targetType, targetId);
            if (!success)
            {
                _logger.LogWarning("删除用户偏好失败：没有找到匹配的偏好，用户ID：{UserId}，目标类型：{TargetType}，目标ID：{TargetId}", 
                    userId, targetType, targetId);
                return false;
            }
            
            // 保存更改
            await _unitOfWork.SaveChangesAsync();
            
            _logger.LogInformation("删除用户偏好成功：用户ID：{UserId}，目标类型：{TargetType}，目标ID：{TargetId}", 
                userId, targetType, targetId);
            
            return true;
        }
    }
} 