using FitBites.Domain.Entities;
using FitBites.Infrastructure.Data.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitBites.Infrastructure.Data.Configurations
{
    /// <summary>
    /// 菜式食材实体配置
    /// </summary>
    public class RecipeIngredientConfiguration : EntityTypeConfigurationBase<RecipeIngredient>
    {
        public override void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            base.Configure(builder);

            // 表名设置
            builder.ToTable("RecipeIngredients");

            // 字段配置
            builder.Property(ri => ri.RecipeId)
                .IsRequired();

            builder.Property(ri => ri.IngredientId)
                .IsRequired();

            builder.Property(ri => ri.RoleType)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(ri => ri.ProcessMethod)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(ri => ri.UsageMethod)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(ri => ri.IngredientWeight)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(ri => ri.PostProcessImage)
                .HasMaxLength(256)
                .IsRequired(false);

            builder.Property(ri => ri.Notes)
                .HasMaxLength(500)
                .IsRequired(false);

            // 外键配置
            builder.HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ri => ri.Ingredient)
                .WithMany()
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // 索引配置
            builder.HasIndex(ri => ri.RecipeId);
            builder.HasIndex(ri => ri.IngredientId);
            builder.HasIndex(ri => new { ri.RecipeId, ri.IngredientId }).IsUnique();
            builder.HasIndex(ri => ri.RoleType);
        }
    }
} 