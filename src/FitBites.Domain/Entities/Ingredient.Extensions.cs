using FitBites.Core.Enums;
using System;
using System.Linq;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 食材实体 - 营养成分、人群标签和预处理方法相关功能
    /// </summary>
    public partial class Ingredient
    {
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
    }
} 