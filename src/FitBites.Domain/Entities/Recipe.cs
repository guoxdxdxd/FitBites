using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 菜式实体
    /// </summary>
    public class Recipe : EntityBase
    {
        /// <summary>
        /// 菜式名称
        /// </summary>
        public string RecipeName { get; private set; }

        /// <summary>
        /// 主图URL
        /// </summary>
        public string ImageUrl { get; private set; }

        /// <summary>
        /// 菜式介绍
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 菜系ID
        /// </summary>
        public Guid? CuisineId { get; private set; }

        /// <summary>
        /// 菜系导航属性
        /// </summary>
        public virtual CuisineDict Cuisine { get; private set; }

        /// <summary>
        /// 烹饪方式ID
        /// </summary>
        public Guid? CookingMethodId { get; private set; }

        /// <summary>
        /// 烹饪方式导航属性
        /// </summary>
        public virtual CookingMethodDict CookingMethod { get; private set; }

        /// <summary>
        /// 口味ID
        /// </summary>
        public Guid? TasteId { get; private set; }

        /// <summary>
        /// 口味导航属性
        /// </summary>
        public virtual TasteDict Taste { get; private set; }

        /// <summary>
        /// 难度（初级、中级、高级）
        /// </summary>
        public DifficultyLevel DifficultyLevel { get; private set; }

        /// <summary>
        /// 准备时间（分钟）
        /// </summary>
        public int? PrepTime { get; private set; }

        /// <summary>
        /// 烹饪时间（分钟）
        /// </summary>
        public int? CookTime { get; private set; }

        /// <summary>
        /// 几人份
        /// </summary>
        public int? Servings { get; private set; }

        /// <summary>
        /// 是否推荐（0/1）
        /// </summary>
        public bool? Recommended { get; private set; }

        /// <summary>
        /// 启用状态（0/1）
        /// </summary>
        public bool Status { get; private set; }

        /// <summary>
        /// 来源（系统0、家庭1、用户2）
        /// </summary>
        public RecipeSource Source { get; private set; }

        /// <summary>
        /// 来源ID（家庭ID或用户ID）
        /// </summary>
        public Guid? SourceId { get; private set; }

        /// <summary>
        /// 食材集合
        /// </summary>
        public virtual ICollection<RecipeIngredient> Ingredients { get; private set; }

        /// <summary>
        /// 烹饪步骤集合
        /// </summary>
        public virtual ICollection<RecipeCookingStep> CookingSteps { get; private set; }

        /// <summary>
        /// 菜谱明细集合
        /// </summary>
        public virtual ICollection<MealPlanDetail> MealPlanDetails { get; private set; }

        /// <summary>
        /// 菜谱点菜集合
        /// </summary>
        public virtual ICollection<MealPlanOrder> MealPlanOrders { get; private set; }
        
        /// <summary>
        /// 私有构造函数，防止直接实例化
        /// </summary>
        private Recipe()
        {
            Ingredients = new HashSet<RecipeIngredient>();
            CookingSteps = new HashSet<RecipeCookingStep>();
            MealPlanDetails = new HashSet<MealPlanDetail>();
            MealPlanOrders = new HashSet<MealPlanOrder>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public Recipe(Guid id, string recipeName, string imageUrl, string description, 
            Guid? cuisineId, Guid? cookingMethodId, Guid? tasteId, DifficultyLevel difficultyLevel,
            int? prepTime, int? cookTime, int? servings, bool? recommended, bool status,
            RecipeSource source, Guid? sourceId, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            RecipeName = recipeName;
            ImageUrl = imageUrl;
            Description = description;
            CuisineId = cuisineId;
            CookingMethodId = cookingMethodId;
            TasteId = tasteId;
            DifficultyLevel = difficultyLevel;
            PrepTime = prepTime;
            CookTime = cookTime;
            Servings = servings;
            Recommended = recommended;
            Status = status;
            Source = source;
            SourceId = sourceId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            
            Ingredients = new HashSet<RecipeIngredient>();
            CookingSteps = new HashSet<RecipeCookingStep>();
            MealPlanDetails = new HashSet<MealPlanDetail>();
            MealPlanOrders = new HashSet<MealPlanOrder>();
        }

        /// <summary>
        /// 创建菜式（工厂方法）
        /// </summary>
        public static Recipe Create(
            string recipeName, 
            string description, 
            Guid? cuisineId,
            Guid? cookingMethodId, 
            Guid? tasteId, 
            DifficultyLevel difficultyLevel,
            RecipeSource source,
            Guid? sourceId)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                RecipeName = recipeName,
                Description = description,
                CuisineId = cuisineId,
                CookingMethodId = cookingMethodId,
                TasteId = tasteId,
                DifficultyLevel = difficultyLevel,
                Source = source,
                SourceId = sourceId,
                Status = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            // 添加领域事件
            // TODO: 创建并添加RecipeCreatedEvent领域事件
            
            return recipe;
        }
        
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        public void UpdateBasicInfo(
            string recipeName,
            string description,
            Guid? cuisineId,
            Guid? cookingMethodId,
            Guid? tasteId,
            DifficultyLevel difficultyLevel)
        {
            RecipeName = recipeName;
            Description = description;
            CuisineId = cuisineId;
            CookingMethodId = cookingMethodId;
            TasteId = tasteId;
            DifficultyLevel = difficultyLevel;
            UpdatedAt = DateTime.Now;
            
            // TODO: 添加RecipeUpdatedEvent领域事件
        }
        
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        public void SetImage(string imageUrl)
        {
            ImageUrl = imageUrl;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 设置烹饪时间信息
        /// </summary>
        public void SetTimeInfo(int? prepTime, int? cookTime, int? servings)
        {
            PrepTime = prepTime;
            CookTime = cookTime;
            Servings = servings;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 添加食材
        /// </summary>
        public void AddIngredient(RecipeIngredient ingredient)
        {
            if(ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));
                
            Ingredients.Add(ingredient);
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 添加烹饪步骤
        /// </summary>
        public void AddCookingStep(RecipeCookingStep step)
        {
            if(step == null)
                throw new ArgumentNullException(nameof(step));
                
            CookingSteps.Add(step);
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 设置推荐状态
        /// </summary>
        public void SetRecommendation(bool isRecommended)
        {
            Recommended = isRecommended;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        public void Enable()
        {
            Status = true;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        public void Disable()
        {
            Status = false;
            UpdatedAt = DateTime.Now;
        }
        
        /// <summary>
        /// 计算总烹饪时间（分钟）
        /// </summary>
        public int GetTotalCookingTime()
        {
            return (PrepTime ?? 0) + (CookTime ?? 0);
        }
    }
} 