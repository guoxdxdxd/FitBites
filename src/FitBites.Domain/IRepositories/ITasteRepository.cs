using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 口味仓储接口
    /// </summary>
    public interface ITasteRepository : IRepository<TasteDict>, IPreferenceDictRepository<TasteDict>
    {
        // 可添加口味特有的方法
    }
} 