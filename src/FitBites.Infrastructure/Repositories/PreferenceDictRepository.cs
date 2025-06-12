using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 通用偏好字典仓储实现
    /// </summary>
    /// <typeparam name="TEntity">偏好字典实体类型</typeparam>
    public abstract class PreferenceDictRepository<TEntity> :Repository<TEntity>, IPreferenceDictRepository<TEntity> where TEntity : PreferenceDictBase
    {
        protected readonly ApplicationDbContext _dbContext;

        protected PreferenceDictRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 根据名称查询偏好字典列表
        /// </summary>
        /// <param name="name">名称（可为空）</param>
        /// <returns>偏好字典列表</returns>
        public async Task<List<PreferenceDictBase>> QueryListAsync(string? name)
        {
            var query = _dbContext.Set<TEntity>().Where(c => c.Status);

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            return await query
                .OrderBy(c => c.SortOrder)
                .Select(o => (PreferenceDictBase)o)
                .ToListAsync();
        }
    }
}