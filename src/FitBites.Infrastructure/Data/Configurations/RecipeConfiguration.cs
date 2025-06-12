using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 菜式实体配置
    /// </summary>
    public class RecipeConfiguration : EntityTypeConfigurationBase<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Recipes");

            // 字段配置
            builder.Property(r => r.RecipeName)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(r => r.Description)
                .HasMaxLength(500);

            builder.Property(r => r.ImageUrl)
                .HasMaxLength(256);

            // 枚举类型配置
            builder.Property(r => r.DifficultyLevel)
                .HasConversion<int>();

            builder.Property(r => r.Status)
                .IsRequired();

            builder.Property(r => r.Source)
                .IsRequired()
                .HasConversion<int>();

            // 配置导航属性关系
            builder.HasOne(r => r.Cuisine)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CuisineId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.CookingMethod)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CookingMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Taste)
                .WithMany(t => t.Recipes)
                .HasForeignKey(r => r.TasteId)
                .OnDelete(DeleteBehavior.Restrict);

            // 配置子集合关系
            builder.HasMany(r => r.Ingredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.CookingSteps)
                .WithOne(cs => cs.Recipe)
                .HasForeignKey(cs => cs.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.MealPlanDetails)
                .WithOne(mpd => mpd.Recipe)
                .HasForeignKey(mpd => mpd.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.MealPlanOrders)
                .WithOne(mpo => mpo.Recipe)
                .HasForeignKey(mpo => mpo.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(r => r.RecipeName);
            builder.HasIndex(r => r.CuisineId);
            builder.HasIndex(r => r.CookingMethodId);
            builder.HasIndex(r => r.TasteId);
            builder.HasIndex(r => r.DifficultyLevel);
            builder.HasIndex(r => r.Status);
            builder.HasIndex(r => r.Source);
            builder.HasIndex(r => r.SourceId);
        }
    }
} 