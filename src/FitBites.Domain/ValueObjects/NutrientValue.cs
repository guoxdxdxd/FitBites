using System;

namespace FitBites.Domain.ValueObjects
{
    /// <summary>
    /// 营养成分值对象
    /// </summary>
    public class NutrientValue : IEquatable<NutrientValue>
    {
        /// <summary>
        /// 营养成分ID
        /// </summary>
        public Guid NutritionId { get; private set; }

        /// <summary>
        /// 营养成分名称
        /// </summary>
        public string NutritionName { get; private set; }

        /// <summary>
        /// 含量数值
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// 私有构造函数，强制使用工厂方法创建
        /// </summary>
        private NutrientValue() { }

        /// <summary>
        /// 创建营养成分值
        /// </summary>
        /// <param name="nutritionId">营养成分ID</param>
        /// <param name="nutritionName">营养成分名称</param>
        /// <param name="value">含量数值</param>
        /// <param name="unit">单位</param>
        /// <returns>营养成分值对象</returns>
        public static NutrientValue Create(Guid nutritionId, string nutritionName, decimal value, string unit)
        {
            if (string.IsNullOrWhiteSpace(nutritionName))
                throw new ArgumentException("营养成分名称不能为空", nameof(nutritionName));
                
            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("单位不能为空", nameof(unit));
                
            if (value < 0)
                throw new ArgumentException("含量数值不能为负数", nameof(value));
                
            return new NutrientValue
            {
                NutritionId = nutritionId,
                NutritionName = nutritionName,
                Value = value,
                Unit = unit
            };
        }

        /// <summary>
        /// 判断值对象相等
        /// </summary>
        public bool Equals(NutrientValue other)
        {
            if (other == null)
                return false;

            return NutritionId == other.NutritionId 
                && Value == other.Value 
                && Unit == other.Unit;
        }

        /// <summary>
        /// 重写对象相等判断
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is NutrientValue nutrientValue)
                return Equals(nutrientValue);
                
            return false;
        }

        /// <summary>
        /// 重写获取哈希码
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(NutritionId, Value, Unit);
        }

        /// <summary>
        /// 实现相等运算符
        /// </summary>
        public static bool operator ==(NutrientValue left, NutrientValue right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
                
            return left.Equals(right);
        }

        /// <summary>
        /// 实现不等运算符
        /// </summary>
        public static bool operator !=(NutrientValue left, NutrientValue right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 转换为字符串表示
        /// </summary>
        public override string ToString()
        {
            return $"{NutritionName}: {Value} {Unit}";
        }
    }
} 