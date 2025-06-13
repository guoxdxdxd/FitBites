using FitBites.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.Application.Services.Interfaces
{
    /// <summary>
    /// 人群标签字典应用服务接口
    /// </summary>
    public interface IHumanGroupDictService
    {
        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        Task<List<HumanGroupDictDto>> GetAllAsync();

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        Task<HumanGroupDictDto> GetByIdAsync(Guid id);

        /// <summary>
        /// 创建人群标签
        /// </summary>
        /// <param name="dto">创建人群标签DTO</param>
        /// <returns>创建后的人群标签</returns>
        Task<HumanGroupDictDto> CreateAsync(CreateHumanGroupDictDto dto);

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="dto">更新人群标签DTO</param>
        /// <returns>更新后的人群标签</returns>
        Task<HumanGroupDictDto> UpdateAsync(Guid id, UpdateHumanGroupDictDto dto);

        /// <summary>
        /// 删除人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>任务</returns>
        Task DeleteAsync(Guid id);
        
        /// <summary>
        /// 刷新人群标签缓存
        /// </summary>
        Task RefreshCacheAsync();
    }
} 