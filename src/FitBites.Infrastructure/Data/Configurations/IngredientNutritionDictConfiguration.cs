using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 营养成分字典实体配置
    /// </summary>
    public class IngredientNutritionDictConfiguration : EntityTypeConfigurationBase<IngredientNutritionDict>
    {
        public override void Configure(EntityTypeBuilder<IngredientNutritionDict> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("IngredientNutritionDicts");

            // 字段配置
            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(n => n.Unit)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(n => n.Description)
                .HasMaxLength(200);

            // 关系配置
            builder.HasMany(n => n.IngredientNutritions)
                .WithOne(in1 => in1.Nutrient)
                .HasForeignKey(in1 => in1.NutrientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(n => n.MealPlanNutritions)
                .WithOne(mpn => mpn.Nutrient)
                .HasForeignKey(mpn => mpn.NutrientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(n => n.Name).IsUnique();
        }
    }
} 