using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private Ingredient()
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
        /// 创建新食材
        /// </summary>
        public static Ingredient Create(string name, IngredientCategory category, string waterContent = null, 
            string flavorProfile = null, string mainFunctions = null, string cookingBehavior = null, 
            string preferredUsage = null, bool? @volatile = null, string notes = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("食材名称不能为空", nameof(name));

            var ingredient = new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = name,
                Category = category,
                WaterContent = waterContent,
                FlavorProfile = flavorProfile,
                MainFunctions = mainFunctions,
                CookingBehavior = cookingBehavior,
                PreferredUsage = preferredUsage,
                Volatile = @volatile,
                Notes = notes,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return ingredient;
        }

        /// <summary>
        /// 更新食材信息
        /// </summary>
        public void Update(string name, IngredientCategory category, string waterContent = null, 
            string flavorProfile = null, string mainFunctions = null, string cookingBehavior = null, 
            string preferredUsage = null, bool? @volatile = null, string notes = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("食材名称不能为空", nameof(name));

            Name = name;
            Category = category;
            WaterContent = waterContent;
            FlavorProfile = flavorProfile;
            MainFunctions = mainFunctions;
            CookingBehavior = cookingBehavior;
            PreferredUsage = preferredUsage;
            Volatile = @volatile;
            Notes = notes;
            UpdatedAt = DateTime.Now;

        }

        /// <summary>
        /// 添加营养成分
        /// </summary>
        public IngredientNutrition AddNutrition(Guid nutrientId, decimal amount, string perUnit)
        {
            if (amount < 0)
                throw new ArgumentException("营养成分含量不能为负数", nameof(amount));
            
            if (string.IsNullOrWhiteSpace(perUnit))
                throw new ArgumentException("单位不能为空", nameof(perUnit));

            var existingNutrition = Nutritions.FirstOrDefault(n => n.NutrientId == nutrientId);
            if (existingNutrition != null)
                throw new InvalidOperationException("该营养成分已存在");

            var nutrition = new IngredientNutrition(
                Guid.NewGuid(),
                Id,
                nutrientId,
                amount,
                perUnit,
                DateTime.Now,
                DateTime.Now
            );

            Nutritions.Add(nutrition);
            UpdatedAt = DateTime.Now;

            return nutrition;
        }

        /// <summary>
        /// 更新营养成分
        /// </summary>
        public void UpdateNutrition(Guid nutritionId, decimal amount, string perUnit)
        {
            if (amount < 0)
                throw new ArgumentException("营养成分含量不能为负数", nameof(amount));
            
            if (string.IsNullOrWhiteSpace(perUnit))
                throw new ArgumentException("单位不能为空", nameof(perUnit));

            var nutrition = Nutritions.FirstOrDefault(n => n.Id == nutritionId);
            if (nutrition == null)
                throw new InvalidOperationException("营养成分不存在");

            // 由于IngredientNutrition的属性是私有set，我们需要创建一个新实例并替换
            var updatedNutrition = new IngredientNutrition(
                nutrition.Id,
                nutrition.IngredientId,
                nutrition.NutrientId,
                amount,
                perUnit,
                nutrition.CreatedAt,
                DateTime.Now
            );

            Nutritions.Remove(nutrition);
            Nutritions.Add(updatedNutrition);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 删除营养成分
        /// </summary>
        public void RemoveNutrition(Guid nutritionId)
        {
            var nutrition = Nutritions.FirstOrDefault(n => n.Id == nutritionId);
            if (nutrition == null)
                throw new InvalidOperationException("营养成分不存在");

            Nutritions.Remove(nutrition);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 添加人群适宜/忌用标签
        /// </summary>
        public IngredientHumanGroup AddHumanGroup(Guid groupId, EffectType effect, string notes = null)
        {
            var existingGroup = HumanGroups.FirstOrDefault(h => h.GroupId == groupId);
            if (existingGroup != null)
                throw new InvalidOperationException("该人群标签已存在");

            var humanGroup = new IngredientHumanGroup(
                Guid.NewGuid(),
                Id,
                groupId,
                effect,
                notes,
                DateTime.Now,
                DateTime.Now
            );

            HumanGroups.Add(humanGroup);
            UpdatedAt = DateTime.Now;

            return humanGroup;
        }

        /// <summary>
        /// 更新人群适宜/忌用标签
        /// </summary>
        public void UpdateHumanGroup(Guid humanGroupId, EffectType effect, string notes = null)
        {
            var humanGroup = HumanGroups.FirstOrDefault(h => h.Id == humanGroupId);
            if (humanGroup == null)
                throw new InvalidOperationException("人群标签不存在");

            // 由于IngredientHumanGroup的属性是私有set，我们需要创建一个新实例并替换
            var updatedHumanGroup = new IngredientHumanGroup(
                humanGroup.Id,
                humanGroup.IngredientId,
                humanGroup.GroupId,
                effect,
                notes,
                humanGroup.CreatedAt,
                DateTime.Now
            );

            HumanGroups.Remove(humanGroup);
            HumanGroups.Add(updatedHumanGroup);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 删除人群适宜/忌用标签
        /// </summary>
        public void RemoveHumanGroup(Guid humanGroupId)
        {
            var humanGroup = HumanGroups.FirstOrDefault(h => h.Id == humanGroupId);
            if (humanGroup == null)
                throw new InvalidOperationException("人群标签不存在");

            HumanGroups.Remove(humanGroup);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 添加预处理方法
        /// </summary>
        public IngredientPreprocess AddPreprocess(string method, string description, int? durationSec = null, 
            string temperatureDesc = null, string imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("处理方法不能为空", nameof(method));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("处理描述不能为空", nameof(description));

            var preprocess = new IngredientPreprocess(
                Guid.NewGuid(),
                Id,
                method,
                description,
                durationSec,
                temperatureDesc,
                DateTime.Now,
                DateTime.Now,
                imageUrl
            );

            Preprocesses.Add(preprocess);
            UpdatedAt = DateTime.Now;

            return preprocess;
        }

        /// <summary>
        /// 更新预处理方法
        /// </summary>
        public void UpdatePreprocess(Guid preprocessId, string method, string description, int? durationSec = null, 
            string temperatureDesc = null, string imageUrl = null)
        {
            if (string.IsNullOrWhiteSpace(method))
                throw new ArgumentException("处理方法不能为空", nameof(method));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("处理描述不能为空", nameof(description));

            var preprocess = Preprocesses.FirstOrDefault(p => p.Id == preprocessId);
            if (preprocess == null)
                throw new InvalidOperationException("预处理方法不存在");

            // 由于IngredientPreprocess的属性是私有set，我们需要创建一个新实例并替换
            var updatedPreprocess = new IngredientPreprocess(
                preprocess.Id,
                preprocess.IngredientId,
                method,
                description,
                durationSec,
                temperatureDesc,
                preprocess.CreatedAt,
                DateTime.Now,
                imageUrl
            );

            Preprocesses.Remove(preprocess);
            Preprocesses.Add(updatedPreprocess);
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// 删除预处理方法
        /// </summary>
        public void RemovePreprocess(Guid preprocessId)
        {
            var preprocess = Preprocesses.FirstOrDefault(p => p.Id == preprocessId);
            if (preprocess == null)
                throw new InvalidOperationException("预处理方法不存在");

            Preprocesses.Remove(preprocess);
            UpdatedAt = DateTime.Now;
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