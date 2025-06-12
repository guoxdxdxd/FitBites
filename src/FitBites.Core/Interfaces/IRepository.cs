using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;

namespace FitBites.Core.Interfaces
{
    /// <summary>
    /// 通用仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity> : IScopedDependency where TEntity : class
    {
        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns>实体对象</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>实体集合</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 根据条件查询实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体集合</returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 判断符合条件的数据是否存在
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>如果存在返回true，否则返回false</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>添加结果</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>添加结果</returns>
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>更新结果</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>删除结果</returns>
        Task<bool> RemoveAsync(TEntity entity);

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>删除结果</returns>
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
} 