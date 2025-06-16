using FitBites.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 营养成分字典仓储接口
    /// </summary>
    public interface IIngredientNutritionDictRepository
    {
        /// <summary>
        /// 获取所有营养成分字典
        /// </summary>
        Task<List<IngredientNutritionDict>> GetAllAsync();

        /// <summary>
        /// 根据ID获取营养成分字典
        /// </summary>
        Task<IngredientNutritionDict> GetByIdAsync(Guid id);

        /// <summary>
        /// 根据名称获取营养成分字典
        /// </summary>
        Task<IngredientNutritionDict> GetByNameAsync(string name);

        /// <summary>
        /// 添加营养成分字典
        /// </summary>
        Task AddAsync(IngredientNutritionDict entity);

        /// <summary>
        /// 更新营养成分字典
        /// </summary>
        Task UpdateAsync(IngredientNutritionDict entity);

        /// <summary>
        /// 删除营养成分字典
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 检查名称是否存在
        /// </summary>
        Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null);
    }
} 