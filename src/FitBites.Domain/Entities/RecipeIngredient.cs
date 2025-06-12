using System;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 菜式食材实体
    /// </summary>
    public class RecipeIngredient : EntityBase
    {
        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public RecipeIngredient(Guid id, Guid recipeId, Guid ingredientId, string roleType, string processMethod, 
            string usageMethod, string ingredientWeight, int? usageOrder, string postProcessImage, 
            bool? isKeyIngredient, string notes, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            RecipeId = recipeId;
            IngredientId = ingredientId;
            RoleType = roleType;
            ProcessMethod = processMethod;
            UsageMethod = usageMethod;
            IngredientWeight = ingredientWeight;
            UsageOrder = usageOrder;
            PostProcessImage = postProcessImage;
            IsKeyIngredient = isKeyIngredient;
            Notes = notes;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// 菜式ID
        /// </summary>
        public Guid RecipeId { get; private set; }

        /// <summary>
        /// 食材ID
        /// </summary>
        public Guid IngredientId { get; private set; }

        /// <summary>
        /// 角色类型：主料、配料、调味等
        /// </summary>
        public string RoleType { get; private set; }

        /// <summary>
        /// 加工方式（切片、剁碎等）
        /// </summary>
        public string ProcessMethod { get; private set; }

        /// <summary>
        /// 使用方式（提前煸炒、与主料同炒等）
        /// </summary>
        public string UsageMethod { get; private set; }

        /// <summary>
        /// 用量（如：300g、适量）
        /// </summary>
        public string IngredientWeight { get; private set; }

        /// <summary>
        /// 添加顺序
        /// </summary>
        public int? UsageOrder { get; private set; }

        /// <summary>
        /// 加工完成后图片URL
        /// </summary>
        public string PostProcessImage { get; private set; }

        /// <summary>
        /// 是否关键食材
        /// </summary>
        public bool? IsKeyIngredient { get; private set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// 菜式导航属性
        /// </summary>
        public virtual Recipe Recipe { get; private set; }

        /// <summary>
        /// 食材导航属性
        /// </summary>
        public virtual Ingredient Ingredient { get; private set; }
    }
} 