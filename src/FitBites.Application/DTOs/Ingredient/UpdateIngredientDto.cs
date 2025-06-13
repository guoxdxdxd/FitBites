using FitBites.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitBites.Application.DTOs.Ingredient
{
    /// <summary>
    /// 更新食材数据传输对象
    /// </summary>
    public class UpdateIngredientDto
    {
        /// <summary>
        /// 食材ID（必填）
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid Id { get; set; }

        /// <summary>
        /// 食材名称（必填）
        /// </summary>
        [Required(ErrorMessage = "食材名称不能为空")]
        [StringLength(50, ErrorMessage = "食材名称长度不能超过50个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 食材类别（必填）
        /// </summary>
        [Required(ErrorMessage = "食材类别不能为空")]
        public IngredientCategory Category { get; set; }

        /// <summary>
        /// 含水量
        /// </summary>
        [StringLength(50, ErrorMessage = "含水量长度不能超过50个字符")]
        public string WaterContent { get; set; }

        /// <summary>
        /// 味型
        /// </summary>
        [StringLength(100, ErrorMessage = "味型长度不能超过100个字符")]
        public string FlavorProfile { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        [StringLength(200, ErrorMessage = "功能长度不能超过200个字符")]
        public string MainFunctions { get; set; }

        /// <summary>
        /// 烹饪行为特性
        /// </summary>
        [StringLength(200, ErrorMessage = "烹饪行为特性长度不能超过200个字符")]
        public string CookingBehavior { get; set; }

        /// <summary>
        /// 推荐使用方式
        /// </summary>
        [StringLength(200, ErrorMessage = "推荐使用方式长度不能超过200个字符")]
        public string PreferredUsage { get; set; }

        /// <summary>
        /// 是否易挥发
        /// </summary>
        public bool? Volatile { get; set; }

        /// <summary>
        /// 其他备注
        /// </summary>
        [StringLength(500, ErrorMessage = "备注长度不能超过500个字符")]
        public string Notes { get; set; }
    }

    /// <summary>
    /// 添加食材营养成分数据传输对象
    /// </summary>
    public class AddIngredientNutritionDto
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 成分ID
        /// </summary>
        [Required(ErrorMessage = "成分ID不能为空")]
        public Guid NutrientId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        [Range(0, double.MaxValue, ErrorMessage = "数量必须大于等于0")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 每单位（如每100g）
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        [StringLength(20, ErrorMessage = "单位长度不能超过20个字符")]
        public string PerUnit { get; set; }
    }

    /// <summary>
    /// 更新食材营养成分数据传输对象
    /// </summary>
    public class UpdateIngredientNutritionDto
    {
        /// <summary>
        /// 营养成分映射ID
        /// </summary>
        [Required(ErrorMessage = "营养成分ID不能为空")]
        public Guid Id { get; set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "数量不能为空")]
        [Range(0, double.MaxValue, ErrorMessage = "数量必须大于等于0")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 每单位（如每100g）
        /// </summary>
        [Required(ErrorMessage = "单位不能为空")]
        [StringLength(20, ErrorMessage = "单位长度不能超过20个字符")]
        public string PerUnit { get; set; }
    }

    /// <summary>
    /// 添加食材人群适宜/忌用映射数据传输对象
    /// </summary>
    public class AddIngredientHumanGroupDto
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        [Required(ErrorMessage = "人群标签ID不能为空")]
        public Guid GroupId { get; set; }

        /// <summary>
        /// 类型（适用/忌用/慎用）
        /// </summary>
        [Required(ErrorMessage = "效果类型不能为空")]
        public EffectType Effect { get; set; }

        /// <summary>
        /// 补充说明
        /// </summary>
        [StringLength(200, ErrorMessage = "补充说明长度不能超过200个字符")]
        public string Notes { get; set; }
    }

    /// <summary>
    /// 更新食材人群适宜/忌用映射数据传输对象
    /// </summary>
    public class UpdateIngredientHumanGroupDto
    {
        /// <summary>
        /// 人群映射ID
        /// </summary>
        [Required(ErrorMessage = "人群映射ID不能为空")]
        public Guid Id { get; set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 类型（适用/忌用/慎用）
        /// </summary>
        [Required(ErrorMessage = "效果类型不能为空")]
        public EffectType Effect { get; set; }

        /// <summary>
        /// 补充说明
        /// </summary>
        [StringLength(200, ErrorMessage = "补充说明长度不能超过200个字符")]
        public string Notes { get; set; }
    }

    /// <summary>
    /// 添加食材预处理方法数据传输对象
    /// </summary>
    public class AddIngredientPreprocessDto
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 加工方式（如捣碎、焯水、冷藏、挂浆等）
        /// </summary>
        [Required(ErrorMessage = "处理方法不能为空")]
        [StringLength(50, ErrorMessage = "处理方法长度不能超过50个字符")]
        public string Method { get; set; }

        /// <summary>
        /// 加工描述
        /// </summary>
        [Required(ErrorMessage = "处理描述不能为空")]
        [StringLength(200, ErrorMessage = "处理描述长度不能超过200个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 加工图片URL
        /// </summary>
        [StringLength(500, ErrorMessage = "图片URL长度不能超过500个字符")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 处理时长（秒）
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "处理时长不能为负数")]
        public int? DurationSec { get; set; }

        /// <summary>
        /// 温度描述（如沸水、冷藏）
        /// </summary>
        [StringLength(50, ErrorMessage = "温度描述长度不能超过50个字符")]
        public string TemperatureDesc { get; set; }
    }

    /// <summary>
    /// 更新食材预处理方法数据传输对象
    /// </summary>
    public class UpdateIngredientPreprocessDto
    {
        /// <summary>
        /// 预处理方法ID
        /// </summary>
        [Required(ErrorMessage = "预处理方法ID不能为空")]
        public Guid Id { get; set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }

        /// <summary>
        /// 加工方式（如捣碎、焯水、冷藏、挂浆等）
        /// </summary>
        [Required(ErrorMessage = "处理方法不能为空")]
        [StringLength(50, ErrorMessage = "处理方法长度不能超过50个字符")]
        public string Method { get; set; }

        /// <summary>
        /// 加工描述
        /// </summary>
        [Required(ErrorMessage = "处理描述不能为空")]
        [StringLength(200, ErrorMessage = "处理描述长度不能超过200个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 加工图片URL
        /// </summary>
        [StringLength(500, ErrorMessage = "图片URL长度不能超过500个字符")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 处理时长（秒）
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "处理时长不能为负数")]
        public int? DurationSec { get; set; }

        /// <summary>
        /// 温度描述（如沸水、冷藏）
        /// </summary>
        [StringLength(50, ErrorMessage = "温度描述长度不能超过50个字符")]
        public string TemperatureDesc { get; set; }
    }
} 