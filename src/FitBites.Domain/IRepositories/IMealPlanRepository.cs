using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 周菜谱仓储接口
    /// </summary>
    public interface IMealPlanRepository : ISingletonDependency
    {
        /// <summary>
        /// 根据ID获取周菜谱
        /// </summary>
        /// <param name="id">周菜谱ID</param>
        /// <param name="includeDetails">是否包含详情</param>
        /// <returns>周菜谱实体</returns>
        Task<WeeklyMealPlan> GetByIdAsync(Guid id, bool includeDetails = false);
        
        /// <summary>
        /// 根据代码获取周菜谱
        /// </summary>
        /// <param name="planCode">周菜谱代码</param>
        /// <returns>周菜谱实体</returns>
        Task<WeeklyMealPlan> GetByCodeAsync(string planCode);
        
        /// <summary>
        /// 获取用户的周菜谱列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="count">获取数量</param>
        /// <returns>周菜谱列表</returns>
        Task<IEnumerable<WeeklyMealPlan>> GetUserMealPlansAsync(Guid userId, int count = 10);
        
        /// <summary>
        /// 获取家庭的周菜谱列表
        /// </summary>
        /// <param name="familyId">家庭ID</param>
        /// <param name="count">获取数量</param>
        /// <returns>周菜谱列表</returns>
        Task<IEnumerable<WeeklyMealPlan>> GetFamilyMealPlansAsync(Guid familyId, int count = 10);
        
        /// <summary>
        /// 获取特定日期的菜谱
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="userId">用户ID</param>
        /// <param name="familyId">家庭ID</param>
        /// <returns>周菜谱列表</returns>
        Task<IEnumerable<WeeklyMealPlan>> GetMealPlansByDateAsync(DateTime date, Guid? userId = null, Guid? familyId = null);
        
        /// <summary>
        /// 添加周菜谱
        /// </summary>
        /// <param name="mealPlan">周菜谱实体</param>
        /// <returns>添加的周菜谱</returns>
        Task<WeeklyMealPlan> AddAsync(WeeklyMealPlan mealPlan);
        
        /// <summary>
        /// 更新周菜谱
        /// </summary>
        /// <param name="mealPlan">周菜谱实体</param>
        /// <returns>更新的周菜谱</returns>
        Task<WeeklyMealPlan> UpdateAsync(WeeklyMealPlan mealPlan);
        
        /// <summary>
        /// 获取给定状态的所有菜谱
        /// </summary>
        /// <param name="status">菜谱状态</param>
        /// <returns>周菜谱列表</returns>
        Task<IEnumerable<WeeklyMealPlan>> GetByStatusAsync(MealPlanStatus status);
        
        /// <summary>
        /// 获取当前生效的菜谱
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="familyId">家庭ID</param>
        /// <returns>周菜谱实体</returns>
        Task<WeeklyMealPlan> GetCurrentActiveMealPlanAsync(Guid? userId = null, Guid? familyId = null);
    }
} 