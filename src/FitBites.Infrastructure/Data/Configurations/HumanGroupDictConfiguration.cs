using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 人群标签字典实体配置
    /// </summary>
    public class HumanGroupDictConfiguration : EntityTypeConfigurationBase<HumanGroupDict>
    {
        public override void Configure(EntityTypeBuilder<HumanGroupDict> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("HumanGroupDicts");

            // 字段配置
            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.Description)
                .HasMaxLength(200);

            // 关系配置
            builder.HasMany(h => h.UserHumanGroups)
                .WithOne(uhg => uhg.HumanGroup)
                .HasForeignKey(uhg => uhg.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.IngredientHumanGroups)
                .WithOne(ihg => ihg.HumanGroup)
                .HasForeignKey(ihg => ihg.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(h => h.Name).IsUnique();
        }
    }
} 