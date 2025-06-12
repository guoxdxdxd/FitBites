using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 用户实体配置
    /// </summary>
    public class UserConfiguration : EntityTypeConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("Users");

            // 字段配置
            builder.Property(u => u.UserCode)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.Property(u => u.Nickname)
                .HasMaxLength(64);

            builder.Property(u => u.Avatar)
                .HasMaxLength(256);

            builder.Property(u => u.Status)
                .IsRequired();

            builder.Property(u => u.RefreshToken)
                .HasMaxLength(128)
                .IsRequired(false);

            builder.Property(u => u.RefreshTokenExpireTime)
                .IsRequired(false);

            // 关系配置
            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserPreferences)
                .WithOne(up => up.User)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserHumanGroups)
                .WithOne(uhg => uhg.User)
                .HasForeignKey(uhg => uhg.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.OwnedFamilies)
                .WithOne(f => f.Owner)
                .HasForeignKey(f => f.OwnerUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.PersonalMealPlans)
                .WithOne(mp => mp.User)
                .HasForeignKey(mp => mp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedMealPlans)
                .WithOne(mp => mp.Creator)
                .HasForeignKey(mp => mp.CreatorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // builder.HasMany(u => u.PermissionMappings)
            //     .WithOne(pm => pm.User)
            //     .HasForeignKey(pm => pm.ObjectId)
            //     .HasPrincipalKey(u => u.Id)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);

            // 索引配置
            builder.HasIndex(u => u.UserCode)
                .IsUnique();

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.HasIndex(u => u.Phone);
            builder.HasIndex(u => u.Status);
            builder.HasIndex(u => u.RefreshToken);
        }
    }
} 