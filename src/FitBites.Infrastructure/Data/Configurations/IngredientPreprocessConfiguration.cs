using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 配料预处理实体配置
    /// </summary>
    public class IngredientPreprocessConfiguration : EntityTypeConfigurationBase<IngredientPreprocess>
    {
        public override void Configure(EntityTypeBuilder<IngredientPreprocess> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("IngredientPreprocesses");

            // 字段配置
            builder.Property(p => p.IngredientId)
                .IsRequired();

            builder.Property(p => p.Method)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(p => p.TemperatureDesc)
                .HasMaxLength(50);

            // 外键配置
            builder.HasOne(p => p.Ingredient)
                .WithMany()
                .HasForeignKey(p => p.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            // 索引配置
            builder.HasIndex(p => p.IngredientId);
            builder.HasIndex(p => p.Method);
        }
    }
} 