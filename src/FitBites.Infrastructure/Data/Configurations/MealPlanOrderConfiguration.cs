using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 菜谱点菜实体配置
    /// </summary>
    public class MealPlanOrderConfiguration : EntityTypeConfigurationBase<MealPlanOrder>
    {
        public override void Configure(EntityTypeBuilder<MealPlanOrder> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("MealPlanOrders");

            // 字段配置
            builder.Property(o => o.MealPlanId)
                .IsRequired();

            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.RecipeId)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.Remark)
                .HasMaxLength(200);

            // 外键配置
            builder.HasOne(o => o.MealPlan)
                .WithMany(mp => mp.Orders)
                .HasForeignKey(o => o.MealPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Recipe)
                .WithMany(r => r.MealPlanOrders)
                .HasForeignKey(o => o.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(o => o.MealPlanId);
            builder.HasIndex(o => o.UserId);
            builder.HasIndex(o => o.RecipeId);
            builder.HasIndex(o => o.Status);
            builder.HasIndex(o => new { o.MealPlanId, o.UserId, o.RecipeId }).IsUnique();
        }
    }
} 