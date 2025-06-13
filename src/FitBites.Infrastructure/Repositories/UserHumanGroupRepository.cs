using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Domain.Entities;
using FitBites.Domain.Interfaces;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 用户人群标签仓储实现
    /// </summary>
    public class UserHumanGroupRepository : Repository<UserHumanGroup>, IUserHumanGroupRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public UserHumanGroupRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        /// <summary>
        /// 获取用户的所有人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户人群标签列表</returns>
        public async Task<List<UserHumanGroup>> GetUserHumanGroupsAsync(Guid userId)
        {
            return await _dbSet
                .Include(ug => ug.HumanGroup)
                .Where(ug => ug.UserId == userId)
                .ToListAsync();
        }

        /// <summary>
        /// 获取用户特定人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>用户人群标签</returns>
        public async Task<UserHumanGroup> GetUserHumanGroupAsync(Guid userId, Guid groupId)
        {
            return await _dbSet
                .Include(ug => ug.HumanGroup)
                .FirstOrDefaultAsync(ug => ug.UserId == userId && ug.GroupId == groupId);
        }

        /// <summary>
        /// 删除用户人群标签
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否删除成功</returns>
        public async Task<bool> DeleteUserHumanGroupAsync(Guid userId, Guid groupId)
        {
            var userGroup = await _dbSet
                .FirstOrDefaultAsync(ug => ug.UserId == userId && ug.GroupId == groupId);

            if (userGroup == null)
                return false;

            _dbSet.Remove(userGroup);
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
            return await _dbSet
                .AnyAsync(ug => ug.UserId == userId && ug.GroupId == groupId);
        }
    }
} 