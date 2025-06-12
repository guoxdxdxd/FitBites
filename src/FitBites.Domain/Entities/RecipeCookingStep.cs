using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 烹饪步骤实体
    /// </summary>
    public class RecipeCookingStep : EntityBase
    {
        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public RecipeCookingStep(Guid id, Guid recipeId, int stepNumber, string title, string description, 
            string imageUrl, string videoUrl, string ingredientRefs, string actionType, int? durationSec,
            string temperatureDesc, int? waitTimeSec, bool? isOptional, string aiInstruction, 
            DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            RecipeId = recipeId;
            StepNumber = stepNumber;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            VideoUrl = videoUrl;
            IngredientRefs = ingredientRefs;
            ActionType = actionType;
            DurationSec = durationSec;
            TemperatureDesc = temperatureDesc;
            WaitTimeSec = waitTimeSec;
            IsOptional = isOptional;
            AiInstruction = aiInstruction;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 所属菜式ID
        /// </summary>
        public Guid RecipeId { get; private set; }

        /// <summary>
        /// 步骤序号，从1开始
        /// </summary>
        public int StepNumber { get; private set; }

        /// <summary>
        /// 步骤标题（如"热锅爆香"）
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 步骤详述
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 步骤配图
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// 步骤视频（预留）
        /// </summary>
        public string VideoUrl { get; private set; }

        /// <summary>
        /// 使用配料ID列表（如：[1,3]）或数组对象
        /// </summary>
        public string IngredientRefs { get; private set; }

        /// <summary>
        /// 操作类型（加热、搅拌等）
        /// </summary>
        public string ActionType { get; private set; }

        /// <summary>
        /// 操作时长（如翻炒90秒）
        /// </summary>
        public int? DurationSec { get; private set; }

        /// <summary>
        /// 温度提示（如大火）
        /// </summary>
        public string TemperatureDesc { get; private set; }

        /// <summary>
        /// 等待时间（如腌制600秒）
        /// </summary>
        public int? WaitTimeSec { get; private set; }

        /// <summary>
        /// 是否为可选步骤
        /// </summary>
        public bool? IsOptional { get; private set; }

        /// <summary>
        /// AI教学提示（如：注意别糊锅）
        /// </summary>
        public string AiInstruction { get; private set; }

        /// <summary>
        /// 菜式导航属性
        /// </summary>
        public virtual Recipe Recipe { get; private set; }
    }
} 