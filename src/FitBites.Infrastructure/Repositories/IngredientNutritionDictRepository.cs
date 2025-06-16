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
    /// 营养成分字典仓储实现
    /// </summary>
    public class IngredientNutritionDictRepository : Repository<IngredientNutritionDict>, IIngredientNutritionDictRepository
    {
        public IngredientNutritionDictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<IngredientNutritionDict>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IngredientNutritionDict> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IngredientNutritionDict> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task AddAsync(IngredientNutritionDict entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task UpdateAsync(IngredientNutritionDict entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null)
        {
            return await _dbSet.AnyAsync(x => x.Name == name && (!excludeId.HasValue || x.Id != excludeId.Value));
        }
    }
} 