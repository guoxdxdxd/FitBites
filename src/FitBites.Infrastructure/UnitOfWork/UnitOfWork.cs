using FitBites.Core.Interfaces;
using FitBites.Domain;
using FitBites.Domain.Entities.Base;
using FitBites.Infrastructure.Data;
using FitBites.Infrastructure.Events;
using FitBites.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace FitBites.Infrastructure.UnitOfWork
{
    /// <summary>
    /// 工作单元实现
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly DomainEventService _domainEventService;
        private readonly ILogger<UnitOfWork> _logger;
        private IDbContextTransaction _currentTransaction;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="domainEventService">领域事件服务</param>
        /// <param name="logger">日志记录器</param>
        public UnitOfWork(
            ApplicationDbContext context,
            DomainEventService domainEventService,
            ILogger<UnitOfWork> logger)
        {
            _context = context;
            _domainEventService = domainEventService;
            _logger = logger;
            _repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// 当前事务
        /// </summary>
        public IDbContextTransaction CurrentTransaction => _currentTransaction;

        /// <summary>
        /// 是否有活动事务
        /// </summary>
        public bool HasActiveTransaction => _currentTransaction != null;

        /// <summary>
        /// 获取特定类型的仓储
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <returns>实体仓储</returns>
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns>数据库事务</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return _currentTransaction;
            }

            _currentTransaction = await _context.Database.BeginTransactionAsync();
            return _currentTransaction;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction">数据库事务</param>
        /// <returns>任务</returns>
        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            if (transaction != _currentTransaction)
                throw new InvalidOperationException($"事务 {transaction.TransactionId} 不是当前事务");

            try
            {
                // 先保存所有更改
                await SaveChangesAsync();
                
                // 提交事务
                await transaction.CommitAsync();
                
                // 发布所有领域事件
                await _domainEventService.PublishEventsAsync();
            }
            catch
            {
                // 发生异常时回滚事务
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                // 无论成功失败，都要释放事务资源
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <returns>任务</returns>
        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.RollbackAsync();
                }
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// 保存更改并发布领域事件
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>影响的行数</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // 从DbContext中收集领域事件
            var domainEntities = _context.ChangeTracker
                .Entries<AggregateRoot>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            // 收集所有领域事件
            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            // 将事件添加到事件服务
            _domainEventService.AddEvents(domainEvents);

            // 清空实体中的事件
            foreach (var entity in domainEntities)
            {
                entity.Entity.ClearDomainEvents();
            }

            // 保存数据库更改
            var result = await _context.SaveChangesAsync(cancellationToken);

            // 如果不在事务中，立即发布事件
            if (_currentTransaction == null)
            {
                await _domainEventService.PublishEventsAsync();
            }

            return result;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _currentTransaction?.Dispose();
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
} 