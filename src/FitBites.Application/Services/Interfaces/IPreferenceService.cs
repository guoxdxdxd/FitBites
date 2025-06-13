using FitBites.Application.Dtos.Preference;
using FitBites.Core.DependencyInjection;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 偏好服务接口
    /// </summary>
    public interface IPreferenceService : IScopedDependency
    {
        /// <summary>
        /// 查询偏好列表
        /// </summary>
        /// <param name="queryDto">查询参数</param>
        /// <returns>偏好项目列表</returns>
        Task<List<PreferenceItemDto>> GetPreferenceItemsAsync(PreferenceQueryDto queryDto);
        
        /// <summary>
        /// 创建偏好项
        /// </summary>
        /// <param name="createDto">创建参数</param>
        /// <returns>创建的偏好项</returns>
        Task<PreferenceItemDto> CreatePreferenceAsync(PreferenceCreateDto createDto);
        
        /// <summary>
        /// 更新偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="updateDto">更新参数</param>
        Task UpdatePreferenceAsync(Guid id, PreferenceUpdateDto updateDto);
        
        /// <summary>
        /// 删除偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        Task DeletePreferenceAsync(Guid id, PreferenceTargetType type);
        
        /// <summary>
        /// 启用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        Task EnablePreferenceAsync(Guid id, PreferenceTargetType type);
        
        /// <summary>
        /// 禁用偏好项
        /// </summary>
        /// <param name="id">偏好项ID</param>
        /// <param name="type">偏好类型</param>
        Task DisablePreferenceAsync(Guid id, PreferenceTargetType type);
        
        /// <summary>
        /// 刷新所有偏好缓存
        /// 当偏好数据发生变更时调用此方法
        /// </summary>
        Task RefreshPreferenceCacheAsync();

        /// <summary>
        /// 刷新指定类型的偏好缓存
        /// </summary>
        /// <typeparam name="T">偏好字典实体类型</typeparam>
        /// <param name="queryFunc">数据库查询委托</param>
        Task RefreshCacheAsync<T>(Func<string, Task<List<PreferenceDictBase>>> queryFunc) where T : PreferenceDictBase;
    }
}