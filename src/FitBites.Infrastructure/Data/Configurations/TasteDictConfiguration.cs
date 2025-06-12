using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 口味字典实体配置
    /// </summary>
    public class TasteDictConfiguration : EntityTypeConfigurationBase<TasteDict>
    {
        public override void Configure(EntityTypeBuilder<TasteDict> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("TasteDicts");

            // 字段配置
            builder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .HasMaxLength(200);

            builder.Property(t => t.Status)
                .IsRequired();
                
            // 配置关系
            builder.HasMany(t => t.Recipes)
                .WithOne(r => r.Taste)
                .HasForeignKey(r => r.TasteId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(t => t.Code).IsUnique();
            builder.HasIndex(t => t.Name);
            builder.HasIndex(t => t.Status);
            builder.HasIndex(t => t.SortOrder);
        }
    }
} 