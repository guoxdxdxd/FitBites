using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 菜系仓储接口
    /// </summary>
    public interface ICuisineRepository : IRepository<CuisineDict>, IPreferenceDictRepository<CuisineDict>
    {
        // 可添加菜系特有的方法
    }
}