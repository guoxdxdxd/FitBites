using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 周菜谱实体配置
    /// </summary>
    public class WeeklyMealPlanConfiguration : EntityTypeConfigurationBase<WeeklyMealPlan>
    {
        public override void Configure(EntityTypeBuilder<WeeklyMealPlan> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("WeeklyMealPlans");

            // 字段配置
            builder.Property(p => p.PlanCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Year)
                .IsRequired();

            builder.Property(p => p.WeekNumber)
                .IsRequired();

            builder.Property(p => p.StartDate)
                .IsRequired();

            builder.Property(p => p.EndDate)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.CreatorUserId)
                .IsRequired();

            // 外键配置
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Family)
                .WithMany()
                .HasForeignKey(p => p.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Creator)
                .WithMany()
                .HasForeignKey(p => p.CreatorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(p => p.PlanCode).IsUnique();
            builder.HasIndex(p => new { p.Year, p.WeekNumber });
            builder.HasIndex(p => p.StartDate);
            builder.HasIndex(p => p.EndDate);
            builder.HasIndex(p => p.UserId);
            builder.HasIndex(p => p.FamilyId);
            builder.HasIndex(p => p.Status);
        }
    }
} 