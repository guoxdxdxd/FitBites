using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 菜谱营养实体配置
    /// </summary>
    public class MealPlanNutritionConfiguration : EntityTypeConfigurationBase<MealPlanNutrition>
    {
        public override void Configure(EntityTypeBuilder<MealPlanNutrition> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("MealPlanNutritions");

            // 字段配置
            builder.Property(n => n.MealPlanId)
                .IsRequired();

            builder.Property(n => n.NutrientId)
                .IsRequired();

            builder.Property(n => n.TotalAmount)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(n => n.Unit)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(n => n.Remark)
                .HasMaxLength(200);

            // 外键配置
            builder.HasOne(n => n.MealPlan)
                .WithMany(mp => mp.Nutritions)
                .HasForeignKey(n => n.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Nutrient)
                .WithMany()
                .HasForeignKey(n => n.NutrientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(n => n.MealPlanId);
            builder.HasIndex(n => n.NutrientId);
            builder.HasIndex(n => new { n.MealPlanId, n.NutrientId }).IsUnique();
        }
    }
} 