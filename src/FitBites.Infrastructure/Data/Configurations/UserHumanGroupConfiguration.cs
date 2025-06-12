using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 用户-人群标签映射实体配置
    /// </summary>
    public class UserHumanGroupConfiguration : EntityTypeConfigurationBase<UserHumanGroup>
    {
        public override void Configure(EntityTypeBuilder<UserHumanGroup> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("UserHumanGroups");

            // 字段配置
            builder.Property(u => u.UserId)
                .IsRequired();

            builder.Property(u => u.GroupId)
                .IsRequired();

            builder.Property(u => u.Confidence)
                .HasPrecision(5, 2);

            // 外键配置
            builder.HasOne(u => u.User)
                .WithMany(user => user.UserHumanGroups)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.HumanGroup)
                .WithMany(hg => hg.UserHumanGroups)
                .HasForeignKey(u => u.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // 索引配置
            builder.HasIndex(u => u.UserId);
            builder.HasIndex(u => u.GroupId);
            builder.HasIndex(u => u.Source);
            builder.HasIndex(u => new { u.UserId, u.GroupId }).IsUnique();
        }
    }
} 