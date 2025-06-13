using FitBites.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.Domain.IRepositories
{
    /// <summary>
    /// 人群标签字典仓储接口
    /// </summary>
    public interface IHumanGroupDictRepository
    {
        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        Task<List<HumanGroupDict>> GetAllAsync();

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        Task<HumanGroupDict> GetByIdAsync(Guid id);

        /// <summary>
        /// 根据名称获取人群标签
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <returns>人群标签</returns>
        Task<HumanGroupDict> GetByNameAsync(string name);

        /// <summary>
        /// 添加人群标签
        /// </summary>
        /// <param name="humanGroupDict">人群标签实体</param>
        /// <returns>任务</returns>
        Task AddAsync(HumanGroupDict humanGroupDict);

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="humanGroupDict">人群标签实体</param>
        /// <returns>任务</returns>
        Task UpdateAsync(HumanGroupDict humanGroupDict);

        /// <summary>
        /// 删除人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>任务</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 检查标签名称是否存在
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <param name="excludeId">排除的ID</param>
        /// <returns>是否存在</returns>
        Task<bool> ExistsByNameAsync(string name, Guid? excludeId = null);
    }
} 