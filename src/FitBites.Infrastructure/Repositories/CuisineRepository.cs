using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 菜系仓储实现
    /// </summary>
    public class CuisineRepository : PreferenceDictRepository<CuisineDict>, ICuisineRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public CuisineRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
} 