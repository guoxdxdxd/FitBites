using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.Dtos;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.Interfaces;
using FitBites.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 用户人群标签服务实现
    /// </summary>
    public class UserHumanGroupService : IUserHumanGroupService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHumanGroupDictRepository _humanGroupDictRepository;
        private readonly IUserHumanGroupRepository _userHumanGroupRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserHumanGroupService(
            IUserRepository userRepository,
            IHumanGroupDictRepository humanGroupDictRepository,
            IUserHumanGroupRepository userHumanGroupRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _humanGroupDictRepository = humanGroupDictRepository;
            _userHumanGroupRepository = userHumanGroupRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取用户的所有人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户人群标签列表</returns>
        public async Task<List<UserHumanGroupDto>> GetUserHumanGroupsAsync(Guid userId)
        {
            var userGroups = await _userHumanGroupRepository.GetUserHumanGroupsAsync(userId);
            return userGroups.Select(g => new UserHumanGroupDto(g)).ToList();
        }

        /// <summary>
        /// 获取用户特定人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>用户人群标签</returns>
        public async Task<UserHumanGroupDto> GetUserHumanGroupAsync(Guid userId, Guid groupId)
        {
            var userGroup = await _userHumanGroupRepository.GetUserHumanGroupAsync(userId, groupId);
            if (userGroup == null)
                return null;

            return new UserHumanGroupDto(userGroup);
        }

        /// <summary>
        /// 添加用户人群标签
        /// </summary>
        /// <param name="dto">添加用户人群标签请求</param>
        /// <returns>添加的用户人群标签</returns>
        public async Task<UserHumanGroupDto> AddUserHumanGroupAsync(AddUserHumanGroupDto dto)
        {
            // 验证用户存在
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new ApplicationException("用户不存在");

            // 验证人群标签存在
            var humanGroup = await _humanGroupDictRepository.GetByIdAsync(dto.GroupId);
            if (humanGroup == null)
                throw new ApplicationException("人群标签不存在");

            // 通过充血模型添加人群标签
            var userHumanGroup = user.AddHumanGroup(dto.GroupId, dto.Source, dto.Confidence);

            // 保存更改
            await _unitOfWork.SaveChangesAsync();

            return new UserHumanGroupDto(userHumanGroup);
        }

        /// <summary>
        /// 更新用户人群标签
        /// </summary>
        /// <param name="dto">更新用户人群标签请求</param>
        /// <returns>更新后的用户人群标签</returns>
        public async Task<UserHumanGroupDto> UpdateUserHumanGroupAsync(UpdateUserHumanGroupDto dto)
        {
            // 验证用户存在
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                throw new ApplicationException("用户不存在");

            // 通过充血模型更新人群标签
            var updated = user.UpdateHumanGroup(dto.GroupId, dto.Source, dto.Confidence);
            if (!updated)
                throw new ApplicationException("人群标签不存在");

            // 保存更改
            await _unitOfWork.SaveChangesAsync();

            // 返回更新后的对象
            var userGroup = await _userHumanGroupRepository.GetUserHumanGroupAsync(dto.UserId, dto.GroupId);
            return new UserHumanGroupDto(userGroup);
        }

        /// <summary>
        /// 删除用户人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否删除成功</returns>
        public async Task<bool> DeleteUserHumanGroupAsync(Guid userId, Guid groupId)
        {
            // 验证用户存在
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new ApplicationException("用户不存在");

            // 通过充血模型移除人群标签
            var removed = user.RemoveHumanGroup(groupId);
            if (!removed)
                return false;

            // 保存更改
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// 检查用户是否属于指定人群
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否属于该人群</returns>
        public async Task<bool> CheckUserBelongsToGroupAsync(Guid userId, Guid groupId)
        {
            // 验证用户存在
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new ApplicationException("用户不存在");

            return user.BelongsToHumanGroup(groupId);
        }
    }
} 