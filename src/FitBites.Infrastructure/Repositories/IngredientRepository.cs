using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 食材仓储实现
    /// </summary>
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 分页查询食材
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="category">食材分类（可选）</param>
        /// <param name="keyword">食材名称关键词（可选）</param>
        /// <returns>食材列表和总数</returns>
        public async Task<(IEnumerable<Ingredient> Ingredients, int TotalCount)> GetPagedIngredientsAsync(
            int pageIndex, 
            int pageSize, 
            IngredientCategory? category = null, 
            string keyword = null)
        {
            // 构建查询
            var query = _dbSet.AsQueryable();
            
            // 使用WhereIf扩展方法应用条件过滤
            query = query.WhereIf(category.HasValue, i => i.Category == category.Value)
                         .WhereIf(!string.IsNullOrWhiteSpace(keyword), i => i.Name.Contains(keyword));
            
            // 获取总记录数
            var totalCount = await query.CountAsync();
            
            // 分页并获取数据
            var ingredients = await query
                .OrderBy(i => i.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
                
            return (ingredients, totalCount);
        }

        /// <summary>
        /// 根据名称获取食材
        /// </summary>
        /// <param name="name">食材名称</param>
        /// <returns>食材实体</returns>
        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Name == name);
        }

        /// <summary>
        /// 根据分类获取食材列表
        /// </summary>
        /// <param name="category">食材分类</param>
        /// <returns>食材列表</returns>
        public async Task<IEnumerable<Ingredient>> GetByCategoryAsync(IngredientCategory category)
        {
            return await _dbSet.Where(i => i.Category == category).ToListAsync();
        }

        /// <summary>
        /// 获取食材及其所有关联数据
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <param name="includeNutritions">是否包含营养成分</param>
        /// <param name="includeHumanGroups">是否包含人群适宜/忌用</param>
        /// <param name="includePreprocesses">是否包含预处理方法</param>
        /// <returns>包含关联数据的食材</returns>
        public async Task<Ingredient> GetIngredientWithRelationsAsync(
            Guid id, 
            bool includeNutritions = true, 
            bool includeHumanGroups = true, 
            bool includePreprocesses = true)
        {
            var query = _dbSet
                .IncludeIf(includeNutritions, i => i.Nutritions)
                    .ThenIncludeIf(includeNutritions, n => n.Nutrient)
                .IncludeIf(includeHumanGroups, i => i.HumanGroups)
                .ThenIncludeIf(includeHumanGroups, h => h.HumanGroup)
                .IncludeIf(includePreprocesses, i => i.Preprocesses);
       
            return await query.AsSplitQuery()
                            .FirstOrDefaultAsync(i => i.Id == id);
        }

        /// <summary>
        /// 检查食材是否被菜谱使用
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>如果被使用返回true，否则返回false</returns>
        public async Task<bool> IsUsedByRecipesAsync(Guid id)
        {
            return await _context.Set<RecipeIngredient>().AnyAsync(ri => ri.IngredientId == id);
        }
    }
} 