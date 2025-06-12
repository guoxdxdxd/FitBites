using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 食材-营养成分映射实体配置
    /// </summary>
    public class IngredientNutritionConfiguration : EntityTypeConfigurationBase<IngredientNutrition>
    {
        public override void Configure(EntityTypeBuilder<IngredientNutrition> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("IngredientNutritions");

            // 字段配置
            builder.Property(n => n.IngredientId)
                .IsRequired();

            builder.Property(n => n.NutrientId)
                .IsRequired();

            builder.Property(n => n.Amount)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(n => n.PerUnit)
                .HasMaxLength(20);

            // 外键配置
            builder.HasOne(n => n.Ingredient)
                .WithMany(i => i.Nutritions)
                .HasForeignKey(n => n.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Nutrient)
                .WithMany()
                .HasForeignKey(n => n.NutrientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(n => n.IngredientId);
            builder.HasIndex(n => n.NutrientId);
            builder.HasIndex(n => new { n.IngredientId, n.NutrientId }).IsUnique();
        }
    }
} 