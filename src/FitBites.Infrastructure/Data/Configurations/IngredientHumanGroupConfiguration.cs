using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 食材-人群适宜/忌用映射实体配置
    /// </summary>
    public class IngredientHumanGroupConfiguration : EntityTypeConfigurationBase<IngredientHumanGroup>
    {
        public override void Configure(EntityTypeBuilder<IngredientHumanGroup> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("IngredientHumanGroups");

            // 字段配置
            builder.Property(h => h.IngredientId)
                .IsRequired();

            builder.Property(h => h.GroupId)
                .IsRequired();

            builder.Property(h => h.Effect)
                .IsRequired();

            builder.Property(h => h.Notes)
                .HasMaxLength(200);

            // 外键配置
            builder.HasOne(h => h.Ingredient)
                .WithMany(i => i.HumanGroups)
                .HasForeignKey(h => h.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.HumanGroup)
                .WithMany()
                .HasForeignKey(h => h.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(h => h.IngredientId);
            builder.HasIndex(h => h.GroupId);
            builder.HasIndex(h => h.Effect);
            builder.HasIndex(h => new { h.IngredientId, h.GroupId }).IsUnique();
        }
    }
} 