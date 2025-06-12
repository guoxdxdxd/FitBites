using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 权限实体配置
    /// </summary>
    public class PermissionConfiguration : EntityTypeConfigurationBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Permissions");

            // 字段配置
            builder.Property(p => p.PermissionCode)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(p => p.Description)
                .HasMaxLength(256);

            builder.Property(p => p.Module)
                .HasMaxLength(64);

            // 索引配置
            builder.HasIndex(p => p.PermissionCode)
                .IsUnique();

            builder.HasIndex(p => p.Module);
        }
    }
} 