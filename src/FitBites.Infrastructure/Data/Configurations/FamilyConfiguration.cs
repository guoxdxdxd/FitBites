using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 家庭实体配置
    /// </summary>
    public class FamilyConfiguration : EntityTypeConfigurationBase<Family>
    {
        public override void Configure(EntityTypeBuilder<Family> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Families");

            // 字段配置
            builder.Property(f => f.FamilyCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.FamilyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.OwnerUserId)
                .IsRequired();

            builder.Property(f => f.Description)
                .HasMaxLength(500);

            builder.Property(f => f.Avatar)
                .HasMaxLength(256);

            // 外键配置
            builder.HasOne(f => f.Owner)
                .WithMany(u => u.OwnedFamilies)
                .HasForeignKey(f => f.OwnerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // 关系配置
            builder.HasMany(f => f.Members)
                .WithOne(fm => fm.Family)
                .HasForeignKey(fm => fm.FamilyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.FamilyMealPlans)
                .WithOne(mp => mp.Family)
                .HasForeignKey(mp => mp.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(f => f.FamilyCode).IsUnique();
            builder.HasIndex(f => f.FamilyName);
            builder.HasIndex(f => f.OwnerUserId);
        }
    }
} 