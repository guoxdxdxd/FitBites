using FitBites.Application.DTOs.Ingredient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 营养成分字典应用服务接口
    /// </summary>
    public interface IIngredientNutritionDictService:IScopedDependency
    {
        /// <summary>
        /// 获取所有营养成分字典
        /// </summary>
        Task<List<IngredientNutritionDictDto>> GetAllAsync();

        /// <summary>
        /// 根据ID获取营养成分字典
        /// </summary>
        Task<IngredientNutritionDictDto> GetByIdAsync(Guid id);

        /// <summary>
        /// 创建营养成分字典
        /// </summary>
        Task<IngredientNutritionDictDto> CreateAsync(CreateIngredientNutritionDictDto dto);

        /// <summary>
        /// 更新营养成分字典
        /// </summary>
        Task<IngredientNutritionDictDto> UpdateAsync(Guid id, UpdateIngredientNutritionDictDto dto);

        /// <summary>
        /// 删除营养成分字典
        /// </summary>
        Task DeleteAsync(Guid id);
    }
} 