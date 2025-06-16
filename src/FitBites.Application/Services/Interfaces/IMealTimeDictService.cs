using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 餐次字典应用服务接口
    /// </summary>
    public interface IMealTimeDictService
    {
        Task<MealTimeDictDto> GetByIdAsync(Guid id);
        Task<MealTimeDictDto> GetByCodeAsync(string code);
        Task<IEnumerable<MealTimeDictDto>> GetAllAsync();
        Task<MealTimeDictDto> CreateAsync(CreateMealTimeDictDto dto);
        Task<MealTimeDictDto> UpdateAsync(UpdateMealTimeDictDto dto);
        Task DeleteAsync(Guid id);
    }
} 