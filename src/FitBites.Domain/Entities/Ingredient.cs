using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 食材基础实体
    /// </summary>
    public class Ingredient : EntityBase
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public Ingredient()
        {
            Nutritions = new HashSet<IngredientNutrition>();
            HumanGroups = new HashSet<IngredientHumanGroup>();
            Preprocesses = new HashSet<IngredientPreprocess>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        public Ingredient(Guid id, string name, IngredientCategory category, string waterContent, string flavorProfile, 
            string mainFunctions, string cookingBehavior, string preferredUsage, bool? @volatile, string notes, 
            DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Category = category;
            WaterContent = waterContent;
            FlavorProfile = flavorProfile;
            MainFunctions = mainFunctions;
            CookingBehavior = cookingBehavior;
            PreferredUsage = preferredUsage;
            Volatile = @volatile;
            Notes = notes;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            
            Nutritions = new HashSet<IngredientNutrition>();
            HumanGroups = new HashSet<IngredientHumanGroup>();
            Preprocesses = new HashSet<IngredientPreprocess>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        /// <summary>
        /// 食材名称（如：鸡肉、蒜）
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 食材类别（主料、配料、香料等）
        /// </summary>
        public IngredientCategory Category { get; private set; }

        /// <summary>
        /// 含水量（高、中、低）或百分比
        /// </summary>
        public string WaterContent { get; private set; }

        /// <summary>
        /// 味型（如：辛辣、甘甜）
        /// </summary>
        public string FlavorProfile { get; private set; }

        /// <summary>
        /// 功能（去腥、提香）
        /// </summary>
        public string MainFunctions { get; private set; }

        /// <summary>
        /// 烹饪行为特性（如：需提前煸炒）
        /// </summary>
        public string CookingBehavior { get; private set; }

        /// <summary>
        /// 推荐使用方式（如：剁碎、切片）
        /// </summary>
        public string PreferredUsage { get; private set; }

        /// <summary>
        /// 是否易挥发
        /// </summary>
        public bool? Volatile { get; private set; }

        /// <summary>
        /// 其他备注
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// 营养成分集合
        /// </summary>
        public virtual ICollection<IngredientNutrition> Nutritions { get; private set; }

        /// <summary>
        /// 人群适宜/忌用映射集合
        /// </summary>
        public virtual ICollection<IngredientHumanGroup> HumanGroups { get; private set; }

        /// <summary>
        /// 预处理集合
        /// </summary>
        public virtual ICollection<IngredientPreprocess> Preprocesses { get; private set; }

        /// <summary>
        /// 菜式食材集合
        /// </summary>
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; private set; }
    }
} 