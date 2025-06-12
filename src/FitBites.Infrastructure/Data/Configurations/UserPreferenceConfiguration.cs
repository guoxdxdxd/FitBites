using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 用户口味偏好实体配置
    /// </summary>
    public class UserPreferenceConfiguration : EntityTypeConfigurationBase<UserPreference>
    {
        public override void Configure(EntityTypeBuilder<UserPreference> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("UserPreferences");

            // 字段配置
            builder.Property(p => p.UserId)
                .IsRequired();

            builder.Property(p => p.TargetType)
                .IsRequired();

            builder.Property(p => p.TargetId)
                .IsRequired();

            builder.Property(p => p.PreferenceType)
                .IsRequired();

            builder.Property(p => p.Remark)
                .HasMaxLength(200);

            // 外键配置
            builder.HasOne(p => p.User)
                .WithMany(u => u.UserPreferences)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // 索引配置
            builder.HasIndex(p => p.UserId);
            builder.HasIndex(p => p.TargetId);
            builder.HasIndex(p => p.TargetType);
            builder.HasIndex(p => p.PreferenceType);
            builder.HasIndex(p => new { p.UserId, p.TargetType, p.TargetId, p.PreferenceType }).IsUnique();
        }
    }
} 