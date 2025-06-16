using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Infrastructure.Data;

namespace FitBites.Infrastructure.Repositories
{
    public class MealTimeDictRepository : Repository<MealTimeDict>, IMealTimeDictRepository
    {
        public MealTimeDictRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<MealTimeDict> GetByCodeAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Code == code && !x.IsDeleted);
        }

        public async Task<IEnumerable<MealTimeDict>> GetAllActiveAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }
    }
} 