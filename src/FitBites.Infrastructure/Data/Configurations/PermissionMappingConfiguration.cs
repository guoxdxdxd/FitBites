using FitBites.Core.Enums;
using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 权限映射实体配置
    /// </summary>
    public class PermissionMappingConfiguration : EntityTypeConfigurationBase<PermissionMapping>
    {
        public override void Configure(EntityTypeBuilder<PermissionMapping> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("PermissionMappings");

            // 字段配置
            builder.Property(pm => pm.ObjectType)
                .IsRequired();

            builder.Property(pm => pm.ObjectId)
                .IsRequired();

            builder.Property(pm => pm.PermissionId)
                .IsRequired();

            builder.Property(pm => pm.Status)
                .IsRequired();

            // 外键配置
            builder.HasOne(pm => pm.Permission)
                .WithMany(p => p.PermissionMappings)
                .HasForeignKey(pm => pm.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // 用户外键配置 - 基于ObjectType为User类型时
            builder.HasOne(pm => pm.User)
                .WithMany(u => u.PermissionMappings)
                .HasForeignKey(pm => pm.ObjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_PermissionMappings_Users_ObjectId")
                .IsRequired(false);

            // 角色外键配置 - 基于ObjectType为Role类型时
            builder.HasOne(pm => pm.Role)
                .WithMany(r => r.PermissionMappings)
                .HasForeignKey(pm => pm.ObjectId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_PermissionMappings_Roles_ObjectId")
                .IsRequired(false);

            // 使用过滤器让EF Core在加载关系时根据ObjectType筛选
            builder.HasQueryFilter(pm => 
                (pm.ObjectType == ObjectType.User && pm.User != null) || 
                (pm.ObjectType == ObjectType.Role && pm.Role != null));

            // 索引配置
            builder.HasIndex(pm => new { pm.ObjectType, pm.ObjectId, pm.PermissionId })
                .IsUnique();
        }
    }
} 