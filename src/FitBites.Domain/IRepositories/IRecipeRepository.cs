using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 菜式仓储接口
    /// </summary>
    public interface IRecipeRepository : ISingletonDependency
    {
        /// <summary>
        /// 根据ID获取菜式
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="includeDetails">是否包含详情</param>
        /// <returns>菜式实体</returns>
        Task<Recipe> GetByIdAsync(Guid id, bool includeDetails = false);
        
        /// <summary>
        /// 添加菜式
        /// </summary>
        /// <param name="recipe">菜式实体</param>
        /// <returns>添加的菜式</returns>
        Task<Recipe> AddAsync(Recipe recipe);
        
        /// <summary>
        /// 更新菜式
        /// </summary>
        /// <param name="recipe">菜式实体</param>
        /// <returns>更新的菜式</returns>
        Task<Recipe> UpdateAsync(Recipe recipe);
        
        /// <summary>
        /// 获取系统菜式列表
        /// </summary>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetSystemRecipesAsync(int count = 20);
        
        /// <summary>
        /// 获取家庭菜式列表
        /// </summary>
        /// <param name="familyId">家庭ID</param>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetFamilyRecipesAsync(Guid familyId, int count = 20);
        
        /// <summary>
        /// 获取用户菜式列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetUserRecipesAsync(Guid userId, int count = 20);
        
        /// <summary>
        /// 根据菜系获取菜式列表
        /// </summary>
        /// <param name="cuisineType">菜系类型</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetByCuisineTypeAsync(string cuisineType);
        
        /// <summary>
        /// 根据烹饪方式获取菜式列表
        /// </summary>
        /// <param name="cookingMethod">烹饪方式</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetByCookingMethodAsync(string cookingMethod);
        
        /// <summary>
        /// 根据口味获取菜式列表
        /// </summary>
        /// <param name="tasteProfile">口味</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetByTasteProfileAsync(string tasteProfile);
        
        /// <summary>
        /// 根据难度获取菜式列表
        /// </summary>
        /// <param name="difficultyLevel">难度</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetByDifficultyLevelAsync(string difficultyLevel);
        
        /// <summary>
        /// 获取推荐菜式列表
        /// </summary>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<List<Recipe>> GetRecommendedRecipesAsync(int count = 10);
        
        /// <summary>
        /// 根据关键词搜索菜式
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> SearchRecipesAsync(string keyword, int count = 20);
        
        /// <summary>
        /// 根据食材获取菜式列表
        /// </summary>
        /// <param name="ingredientIds">食材ID列表</param>
        /// <param name="count">获取数量</param>
        /// <returns>菜式列表</returns>
        Task<IEnumerable<Recipe>> GetRecipesByIngredientsAsync(IEnumerable<Guid> ingredientIds, int count = 20);

        /// <summary>
        /// 根据菜式名称查询菜式
        /// </summary>
        Task<Recipe> GetByNameAsync(string recipeName);
        
        /// <summary>
        /// 检查菜式名称是否存在
        /// </summary>
        Task<bool> ExistsByNameAsync(string recipeName);
        
        /// <summary>
        /// 根据难度获取菜式列表
        /// </summary>
        Task<List<Recipe>> GetRecipesByDifficultyLevelAsync(DifficultyLevel difficultyLevel, int count);
        
        /// <summary>
        /// 根据菜系ID获取菜式列表
        /// </summary>
        Task<List<Recipe>> GetRecipesByCuisineAsync(Guid cuisineId, int count);
        
        /// <summary>
        /// 根据烹饪方式ID获取菜式列表
        /// </summary>
        Task<List<Recipe>> GetRecipesByCookingMethodAsync(Guid cookingMethodId, int count);
        
        /// <summary>
        /// 根据口味ID获取菜式列表
        /// </summary>
        Task<List<Recipe>> GetRecipesByTasteAsync(Guid tasteId, int count);
        
        /// <summary>
        /// 根据来源获取菜式列表
        /// </summary>
        Task<List<Recipe>> GetRecipesBySourceAsync(RecipeSource source, Guid? sourceId, int page, int pageSize);
        
        /// <summary>
        /// 搜索菜式
        /// </summary>
        Task<List<Recipe>> SearchRecipesAsync(string keyword, int page, int pageSize);
        
        /// <summary>
        /// 获取菜式总数
        /// </summary>
        Task<int> GetRecipesCountAsync(RecipeSource? source = null, Guid? sourceId = null, string keyword = null);
        
        /// <summary>
        /// 分页获取菜式列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="keyword">关键词</param>
        /// <returns>分页结果</returns>
        Task<PaginationResult<Recipe>> GetRecipeListAsync(int page, int pageSize, string keyword);
    }
    
    /// <summary>
    /// 分页结果
    /// </summary>
    public class PaginationResult<T>
    {
        /// <summary>
        /// 当前页项目
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();
        
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }
        
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage { get; set; }
        
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevPage { get; set; }
    }
} 