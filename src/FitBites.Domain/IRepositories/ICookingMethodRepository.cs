using FitBites.Core.DependencyInjection;
using FitBites.Core.Interfaces;
using FitBites.Domain.Entities;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 烹饪方式仓储接口
    /// </summary>
    public interface ICookingMethodRepository : IRepository<CookingMethodDict>, IPreferenceDictRepository<CookingMethodDict>
    {
        // 可添加烹饪方式特有的方法
    }
} 