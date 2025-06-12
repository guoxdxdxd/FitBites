using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 食材实体配置
    /// </summary>
    public class IngredientConfiguration : EntityTypeConfigurationBase<Ingredient>
    {
        public override void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Ingredients");

            // 字段配置
            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Category)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(i => i.WaterContent)
                .HasMaxLength(50);

            builder.Property(i => i.FlavorProfile)
                .HasMaxLength(100);

            builder.Property(i => i.MainFunctions)
                .HasMaxLength(200);

            builder.Property(i => i.CookingBehavior)
                .HasMaxLength(200);

            builder.Property(i => i.PreferredUsage)
                .HasMaxLength(200);

            builder.Property(i => i.Notes)
                .HasMaxLength(500);

            // 关系配置
            builder.HasMany(i => i.Nutritions)
                .WithOne(n => n.Ingredient)
                .HasForeignKey(n => n.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.HumanGroups)
                .WithOne(hg => hg.Ingredient)
                .HasForeignKey(hg => hg.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Preprocesses)
                .WithOne(p => p.Ingredient)
                .HasForeignKey(p => p.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.RecipeIngredients)
                .WithOne(ri => ri.Ingredient)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(i => i.Name);
            builder.HasIndex(i => i.Category);
            builder.HasIndex(i => i.FlavorProfile);
        }
    }
} 