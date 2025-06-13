using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FitBites.Core.Utils
{
    /// <summary>
    /// 枚举扩展方法
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取枚举的描述特性
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>描述</returns>
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }

        /// <summary>
        /// 获取枚举的所有值和描述
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns>枚举值和描述的列表</returns>
        public static List<(int Value, string Name, string Description)> GetAllValuesAndDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(v => (
                    Value: Convert.ToInt32(v), 
                    Name: v.ToString(), 
                    Description: GetDescription(v)
                ))
                .ToList();
        }
    }
} 