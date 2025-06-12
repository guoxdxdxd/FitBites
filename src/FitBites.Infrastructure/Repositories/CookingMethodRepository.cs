using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Repositories
{
    /// <summary>
    /// 烹饪方法仓储实现
    /// </summary>
    public class CookingMethodRepository : PreferenceDictRepository<CookingMethodDict>, ICookingMethodRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">数据库上下文</param>
        public CookingMethodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
} 