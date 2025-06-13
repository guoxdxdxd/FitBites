using System;

namespace FitBites.Application.DTOs.Recipe
{
    /// <summary>
    /// 菜式烹饪步骤DTO
    /// </summary>
    public class RecipeCookingStepDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; set; }
        
        /// <summary>
        /// 步骤顺序
        /// </summary>
        public int StepOrder { get; set; }
        
        /// <summary>
        /// 步骤标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 步骤描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 步骤图片URL
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// 步骤视频URL
        /// </summary>
        public string VideoUrl { get; set; }
        
        /// <summary>
        /// 步骤小贴士
        /// </summary>
        public string Tips { get; set; }
    }
} 