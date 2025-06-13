using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 食材仓储接口
    /// </summary>
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        /// <summary>
        /// 分页查询食材
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="category">食材分类（可选）</param>
        /// <param name="keyword">食材名称关键词（可选）</param>
        /// <returns>食材列表和总数</returns>
        Task<(IEnumerable<Ingredient> Ingredients, int TotalCount)> GetPagedIngredientsAsync(
            int pageIndex, 
            int pageSize, 
            IngredientCategory? category = null, 
            string keyword = null);
            
        /// <summary>
        /// 根据名称获取食材
        /// </summary>
        /// <param name="name">食材名称</param>
        /// <returns>食材实体</returns>
        Task<Ingredient> GetByNameAsync(string name);
        
        /// <summary>
        /// 根据分类获取食材列表
        /// </summary>
        /// <param name="category">食材分类</param>
        /// <returns>食材列表</returns>
        Task<IEnumerable<Ingredient>> GetByCategoryAsync(IngredientCategory category);
        
        /// <summary>
        /// 获取食材及其关联数据
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <param name="includeNutritions">是否包含营养成分</param>
        /// <param name="includeHumanGroups">是否包含人群适宜/忌用</param>
        /// <param name="includePreprocesses">是否包含预处理方法</param>
        /// <returns>包含关联数据的食材</returns>
        Task<Ingredient> GetIngredientWithRelationsAsync(
            Guid id, 
            bool includeNutritions = true, 
            bool includeHumanGroups = true, 
            bool includePreprocesses = true);
        
        /// <summary>
        /// 检查食材是否被菜谱使用
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>如果被使用返回true，否则返回false</returns>
        Task<bool> IsUsedByRecipesAsync(Guid id);
    }
} 