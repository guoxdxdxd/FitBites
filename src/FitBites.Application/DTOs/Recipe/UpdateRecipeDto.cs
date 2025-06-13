using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitBites.Core.Enums;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 更新菜式DTO
    /// </summary>
    public class UpdateRecipeDto
    {
        /// <summary>
        /// 菜式ID
        /// </summary>
        [Required(ErrorMessage = "菜式ID不能为空")]
        public Guid Id { get; set; }
        
        /// <summary>
        /// 菜式名称
        /// </summary>
        [Required(ErrorMessage = "菜式名称不能为空")]
        [StringLength(100, ErrorMessage = "菜式名称长度不能超过100个字符")]
        public string RecipeName { get; set; }
        
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
    }
} 