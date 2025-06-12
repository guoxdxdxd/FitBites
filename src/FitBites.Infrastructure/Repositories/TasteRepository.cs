using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 口味仓储实现
    /// </summary>
    public class TasteRepository : PreferenceDictRepository<TasteDict>, ITasteRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public TasteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
} 