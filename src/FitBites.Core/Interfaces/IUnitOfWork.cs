using System;
using System.Threading.Tasks;
using FitBites.Core.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;

namespace FitBites.Core.Interfaces
{
    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable,IScopedDependency
    {
        /// <summary>
        /// 当前事务
        /// </summary>
        IDbContextTransaction CurrentTransaction { get; }
        
        /// <summary>
        /// 是否有活动事务
        /// </summary>
        bool HasActiveTransaction { get; }
        
        /// <summary>
        /// 获取仓储
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>仓储接口</returns>
        IRepository<T> GetRepository<T>() where T : class;
        
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns>数据库事务</returns>
        Task<IDbContextTransaction> BeginTransactionAsync();
        
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction">数据库事务</param>
        /// <returns>任务</returns>
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <returns>任务</returns>
        Task RollbackTransactionAsync();
        
        /// <summary>
        /// 保存更改并发布领域事件
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>影响的行数</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
} 