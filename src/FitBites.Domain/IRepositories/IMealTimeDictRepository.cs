using FitBites.Domain.Entities;
using FitBites.Core.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 餐次字典仓储接口
    /// </summary>
    public interface IMealTimeDictRepository : IRepository<MealTimeDict>
    {
        // 可根据需要扩展自定义方法，如：
        Task<MealTimeDict> GetByCodeAsync(string code);
        Task<IEnumerable<MealTimeDict>> GetAllActiveAsync();
    }
} 