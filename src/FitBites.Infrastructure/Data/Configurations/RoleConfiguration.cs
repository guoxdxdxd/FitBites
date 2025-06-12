using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 角色实体配置
    /// </summary>
    public class RoleConfiguration : EntityTypeConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Roles");

            // 字段配置
            builder.Property(r => r.RoleCode)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(r => r.Description)
                .HasMaxLength(256);

            // 关系配置
            // builder.HasMany(r => r.PermissionMappings)
            //     .WithOne(pm => pm.Role)
            //     .HasForeignKey(pm => pm.ObjectId)
            //     .HasPrincipalKey(r => r.Id)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);

            // 索引配置
            builder.HasIndex(r => r.RoleCode)
                .IsUnique();
        }
    }
} 