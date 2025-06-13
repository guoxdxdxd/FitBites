using System.ComponentModel;

namespace FitBites.Core.Enums
{
    /// <summary>
    /// 食材类别枚举
    /// </summary>
    public enum IngredientCategory
    {
        /// <summary>
        /// 肉类
        /// </summary>
        [Description("肉类")]
        Meat,

        /// <summary>
        /// 豆制品
        /// </summary>
        [Description("豆制品")]
        BeanProduct,

        /// <summary>
        /// 蔬菜
        /// </summary>
        [Description("蔬菜")]
        Vegetable,

        /// <summary>
        /// 水果
        /// </summary>
        [Description("水果")]
        Fruit,

        /// <summary>
        /// 调味料
        /// </summary>
        [Description("调味料")]
        Seasoning,

        /// <summary>
        /// 菌类
        /// </summary>
        [Description("菌类")]
        Fungus,

        /// <summary>
        /// 谷物
        /// </summary>
        [Description("谷物")]
        Grain,

        /// <summary>
        /// 海鲜
        /// </summary>
        [Description("海鲜")]
        Seafood,

        /// <summary>
        /// 坚果
        /// </summary>
        [Description("坚果")]
        Nut,

        /// <summary>
        /// 奶制品
        /// </summary>
        [Description("奶制品")]
        DairyProduct,

        /// <summary>
        /// 饮品
        /// </summary>
        [Description("饮品")]
        Beverage,

        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other
    }
} 