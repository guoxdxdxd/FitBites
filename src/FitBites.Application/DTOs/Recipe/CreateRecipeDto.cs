using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitBites.Core.Enums;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 创建菜式DTO
    /// </summary>
    public class CreateRecipeDto
    {
        /// <summary>
        /// 菜式名称
        /// </summary>
        [Required(ErrorMessage = "菜式名称不能为空")]
        [StringLength(100, ErrorMessage = "菜式名称长度不能超过100个字符")]
        public string RecipeName { get; set; }
        
        /// <summary>
        /// 主图URL
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// 菜式介绍
        /// </summary>
        [Required(ErrorMessage = "菜式介绍不能为空")]
        [StringLength(500, ErrorMessage = "菜式介绍长度不能超过500个字符")]
        public string Description { get; set; }
        
        /// <summary>
        /// 菜系ID
        /// </summary>
        public Guid? CuisineId { get; set; }
        
        /// <summary>
        /// 烹饪方式ID
        /// </summary>
        public Guid? CookingMethodId { get; set; }
        
        /// <summary>
        /// 口味ID
        /// </summary>
        public Guid? TasteId { get; set; }
        
        /// <summary>
        /// 难度（初级、中级、高级）
        /// </summary>
        [Required(ErrorMessage = "难度不能为空")]
        public DifficultyLevel DifficultyLevel { get; set; }
        
        /// <summary>
        /// 准备时间（分钟）
        /// </summary>
        public int? PrepTime { get; set; }
        
        /// <summary>
        /// 烹饪时间（分钟）
        /// </summary>
        public int? CookTime { get; set; }
        
        /// <summary>
        /// 几人份
        /// </summary>
        public int? Servings { get; set; }
        
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? Recommended { get; set; }
        
        /// <summary>
        /// 来源（系统0、家庭1、用户2）
        /// </summary>
        [Required(ErrorMessage = "菜式来源不能为空")]
        public RecipeSource Source { get; set; }
        
        /// <summary>
        /// 来源ID（家庭ID或用户ID）
        /// </summary>
        public Guid? SourceId { get; set; }
        
        /// <summary>
        /// 食材列表
        /// </summary>
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new List<CreateRecipeIngredientDto>();
        
        /// <summary>
        /// 烹饪步骤列表
        /// </summary>
        public List<CreateRecipeCookingStepDto> CookingSteps { get; set; } = new List<CreateRecipeCookingStepDto>();
    }
    
    /// <summary>
    /// 创建菜式食材DTO
    /// </summary>
    public class CreateRecipeIngredientDto
    {
        /// <summary>
        /// 食材ID
        /// </summary>
        [Required(ErrorMessage = "食材ID不能为空")]
        public Guid IngredientId { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        [Required(ErrorMessage = "食材数量不能为空")]
        [Range(0.01, 9999, ErrorMessage = "食材数量必须大于0")]
        public decimal Amount { get; set; }
        
        /// <summary>
        /// 单位
        /// </summary>
        [Required(ErrorMessage = "食材单位不能为空")]
        [StringLength(20, ErrorMessage = "食材单位长度不能超过20个字符")]
        public string Unit { get; set; }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(100, ErrorMessage = "备注长度不能超过100个字符")]
        public string Remark { get; set; }
    }
    
    /// <summary>
    /// 创建菜式烹饪步骤DTO
    /// </summary>
    public class CreateRecipeCookingStepDto
    {
        /// <summary>
        /// 步骤顺序
        /// </summary>
        [Required(ErrorMessage = "步骤顺序不能为空")]
        public int StepOrder { get; set; }
        
        /// <summary>
        /// 步骤标题
        /// </summary>
        [StringLength(100, ErrorMessage = "步骤标题长度不能超过100个字符")]
        public string Title { get; set; }
        
        /// <summary>
        /// 步骤描述
        /// </summary>
        [Required(ErrorMessage = "步骤描述不能为空")]
        [StringLength(500, ErrorMessage = "步骤描述长度不能超过500个字符")]
        public string Description { get; set; }
        
        /// <summary>
        /// 步骤图片URL
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// 步骤小贴士
        /// </summary>
        [StringLength(200, ErrorMessage = "小贴士长度不能超过200个字符")]
        public string Tips { get; set; }
    }
} 