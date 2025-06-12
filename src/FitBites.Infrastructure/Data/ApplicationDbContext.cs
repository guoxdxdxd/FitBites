using System;
using System.Threading;
using System.Threading.Tasks;
using FitBites.Domain.Entities;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Data
{
    /// <summary>
    /// 应用程序数据库上下文
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<WeeklyMealPlan> WeeklyMealPlans { get; set; }
        public DbSet<MealPlanDetail> MealPlanDetails { get; set; }
        public DbSet<MealPlanOrder> MealPlanOrders { get; set; }
        public DbSet<MealPlanNutrition> MealPlanNutritions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientNutrition> IngredientNutritions { get; set; }
        public DbSet<IngredientNutritionDict> IngredientNutritionDicts { get; set; }
        public DbSet<IngredientPreprocess> IngredientPreprocesses { get; set; }
        public DbSet<IngredientHumanGroup> IngredientHumanGroups { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeCookingStep> RecipeCookingSteps { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserHumanGroup> UserHumanGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionMapping> PermissionMappings { get; set; }
        public DbSet<HumanGroupDict> HumanGroupDicts { get; set; }
        public DbSet<TasteDict> TasteDicts { get; set; }
        public DbSet<MealTimeDict> MealTimeDicts { get; set; }
        public DbSet<CuisineDict> CuisineDicts { get; set; }
        public DbSet<CookingMethodDict> CookingMethodDicts { get; set; }
        #endregion

        /// <summary>
        /// 重写模型创建方法，应用实体配置
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<DomainEvent>();
            // 应用实体配置
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            // 应用字典表种子数据
            modelBuilder.SeedAllDictionaries();
        }

        /// <summary>
        /// 重写保存更改方法，自动更新创建时间和更新时间
        /// </summary>
        /// <returns>受影响的行数</returns>
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        /// <summary>
        /// 重写异步保存更改方法，自动更新创建时间和更新时间
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>受影响的行数</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 更新实体的创建时间和更新时间
        /// </summary>
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is EntityBase entityBase)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entityBase.CreatedAt = DateTime.Now;
                    }
                    entityBase.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
} 