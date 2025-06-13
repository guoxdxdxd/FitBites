using FitBites.Core.DependencyInjection;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 人群标签字典仓储实现
    /// </summary>
    public class HumanGroupDictRepository : Repository<HumanGroupDict>, IHumanGroupDictRepository, IScopedDependency
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public HumanGroupDictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        public async Task<List<HumanGroupDict>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        public async Task<HumanGroupDict> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// 根据名称获取人群标签
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <returns>人群标签</returns>
        public async Task<HumanGroupDict> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(g => g.Name == name);
        }

        /// <summary>
        /// 添加人群标签
        /// </summary>
        /// <param name="humanGroupDict">人群标签实体</param>
        /// <returns>任务</returns>
        public async Task AddAsync(HumanGroupDict humanGroupDict)
        {
            await _dbSet.AddAsync(humanGroupDict);
        }

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="humanGroupDict">人群标签实体</param>
        /// <returns>任务</returns>
        public Task UpdateAsync(HumanGroupDict humanGroupDict)
        {
            _dbSet.Entry(humanGroupDict).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>任务</returns>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        /// <summary>
        /// 检查标签名称是否存在
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <param name="excludeId">排除的ID</param>
        /// <returns>是否存在</returns>
        public async Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null)
        {
            return await _dbSet.AnyAsync(x => 
                x.Name == name && 
                (!excludeId.HasValue || x.Id != excludeId.Value));
        }
    }
} 