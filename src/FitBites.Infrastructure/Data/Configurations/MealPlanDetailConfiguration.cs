using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 菜谱明细实体配置
    /// </summary>
    public class MealPlanDetailConfiguration : EntityTypeConfigurationBase<MealPlanDetail>
    {
        public override void Configure(EntityTypeBuilder<MealPlanDetail> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("MealPlanDetails");

            // 字段配置
            builder.Property(d => d.MealPlanId)
                .IsRequired();

            builder.Property(d => d.WeekDay)
                .IsRequired();

            builder.Property(d => d.MealTimeId)
                .IsRequired();

            builder.Property(d => d.RecipeId)
                .IsRequired();

            builder.Property(d => d.Remark)
                .HasMaxLength(200);

            // 外键配置
            builder.HasOne(d => d.MealPlan)
                .WithMany(mp => mp.Details)
                .HasForeignKey(d => d.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.MealTime)
                .WithMany()
                .HasForeignKey(d => d.MealTimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Recipe)
                .WithMany(r => r.MealPlanDetails)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(d => d.MealPlanId);
            builder.HasIndex(d => d.WeekDay);
            builder.HasIndex(d => d.MealTimeId);
            builder.HasIndex(d => d.RecipeId);
            builder.HasIndex(d => new { d.MealPlanId, d.WeekDay, d.MealTimeId });
        }
    }
} 