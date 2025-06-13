using System;
using System.Collections.Generic;
using FitBites.Core.Enums;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 菜式DTO
    /// </summary>
    public class RecipeDto
    {
        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 菜式名称
        /// </summary>
        public string RecipeName { get; set; }
        
        /// <summary>
        /// 主图URL
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// 菜式介绍
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 菜系ID
        /// </summary>
        public Guid? CuisineId { get; set; }
        
        /// <summary>
        /// 菜系名称
        /// </summary>
        public string CuisineName { get; set; }
        
        /// <summary>
        /// 烹饪方式ID
        /// </summary>
        public Guid? CookingMethodId { get; set; }
        
        /// <summary>
        /// 烹饪方式名称
        /// </summary>
        public string CookingMethodName { get; set; }
        
        /// <summary>
        /// 口味ID
        /// </summary>
        public Guid? TasteId { get; set; }
        
        /// <summary>
        /// 口味名称
        /// </summary>
        public string TasteName { get; set; }
        
        /// <summary>
        /// 难度（初级、中级、高级）
        /// </summary>
        public DifficultyLevel DifficultyLevel { get; set; }
        
        /// <summary>
        /// 难度显示名称
        /// </summary>
        public string DifficultyLevelName { get; set; }
        
        /// <summary>
        /// 准备时间（分钟）
        /// </summary>
        public int? PrepTime { get; set; }
        
        /// <summary>
        /// 烹饪时间（分钟）
        /// </summary>
        public int? CookTime { get; set; }
        
        /// <summary>
        /// 总烹饪时间（分钟）
        /// </summary>
        public int TotalTime { get; set; }
        
        /// <summary>
        /// 几人份
        /// </summary>
        public int? Servings { get; set; }
        
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool? Recommended { get; set; }
        
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool Status { get; set; }
        
        /// <summary>
        /// 来源（系统0、家庭1、用户2）
        /// </summary>
        public RecipeSource Source { get; set; }
        
        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }
        
        /// <summary>
        /// 来源ID（家庭ID或用户ID）
        /// </summary>
        public Guid? SourceId { get; set; }
        
        /// <summary>
        /// 食材列表
        /// </summary>
        public List<RecipeIngredientDto> Ingredients { get; set; } = new List<RecipeIngredientDto>();
        
        /// <summary>
        /// 烹饪步骤列表
        /// </summary>
        public List<RecipeCookingStepDto> CookingSteps { get; set; } = new List<RecipeCookingStepDto>();
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 