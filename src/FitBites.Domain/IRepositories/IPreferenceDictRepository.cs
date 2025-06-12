using FitBites.Core.DependencyInjection;
using FitBites.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 偏好字典仓储接口
    /// 提供对所有偏好字典实体的通用查询功能
    /// </summary>
    /// <typeparam name="T">偏好字典实体类型，必须继承自PreferenceDictBase</typeparam>
    public interface IPreferenceDictRepository<T> : ISingletonDependency where T : PreferenceDictBase
    {
        /// <summary>
        /// 根据名称查询偏好字典列表
        /// </summary>
        /// <param name="name">名称（可为空）</param>
        /// <returns>偏好字典列表</returns>
        Task<List<PreferenceDictBase>> QueryListAsync(string? name);
    }
} 