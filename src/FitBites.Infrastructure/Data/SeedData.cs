using System;
using System.Collections.Generic;
using FitBites.Core.Enums;
using FitBites.Domain.Constants;
using FitBites.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitBites.Infrastructure.Data
{
    /// <summary>
    /// 种子数据配置类
    /// </summary>
    public static class SeedData
    {
        // 设置固定的种子数据时间，避免每次迁移时时间变化导致生成不同的迁移文件
        private static readonly DateTime _seedTime = new DateTime(2023, 1, 1);

        /// <summary>
        /// 添加所有字典数据
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        public static void SeedAllDictionaries(this ModelBuilder modelBuilder)
        {
            // 调用 各个 字典的种子数据方法
            modelBuilder.SeedMealTimeDicts();
            modelBuilder.SeedHumanGroupDicts();
            modelBuilder.SeedIngredientNutritionDicts();
            modelBuilder.SeedTasteDicts();
            modelBuilder.SeedCookingMethodDicts();
            modelBuilder.SeedCuisineDicts();
            
            // 添加用户种子数据
            modelBuilder.SeedUsers();
            modelBuilder.SeedUserRoles();
            
            // 添加角色和权限种子数据
            modelBuilder.SeedRoles();
            modelBuilder.SeedPermissions();
            modelBuilder.SeedPermissionMappings();
            
            // 添加菜式相关种子数据 
            modelBuilder.SeedIngredients();
            modelBuilder.SeedIngredientNutritions();
            modelBuilder.SeedIngredientHumanGroups();
            modelBuilder.SeedIngredientPreprocesses();
            modelBuilder.SeedRecipes();
            modelBuilder.SeedRecipeIngredients();
            modelBuilder.SeedRecipeCookingSteps();
        }

        /// <summary>
        /// 种子数据：餐次字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedMealTimeDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealTimeDict>().HasData(
                new MealTimeDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    "BREAKFAST",
                    "早餐",
                    "上午7-9点食用，提供一天活力的开始",
                    _seedTime,
                    _seedTime
                ),
                new MealTimeDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    "LUNCH",
                    "午餐",
                    "中午11-13点食用，提供一天主要能量来源",
                    _seedTime,
                    _seedTime
                ),
                new MealTimeDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    "DINNER",
                    "晚餐",
                    "晚上17-19点食用，提供睡前必要营养",
                    _seedTime,
                    _seedTime
                ),
                new MealTimeDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa9"),
                    "SNACK",
                    "加餐",
                    "两餐之间的少量食物补充",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：人群标签字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedHumanGroupDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HumanGroupDict>().HasData(
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb1"),
                    "孕妇",
                    "怀孕期间的女性",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb2"),
                    "哺乳期",
                    "哺乳期间的女性",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb3"),
                    "婴幼儿",
                    "3岁以下儿童",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb4"),
                    "儿童",
                    "3-12岁儿童",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb5"),
                    "老人",
                    "65岁以上老年人",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb6"),
                    "糖尿病",
                    "糖尿病患者",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb7"),
                    "高血压",
                    "高血压患者",
                    _seedTime,
                    _seedTime
                ),
                new HumanGroupDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb8"),
                    "高血脂",
                    "高血脂患者",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：营养成分字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedIngredientNutritionDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientNutritionDict>().HasData(
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"),
                    "能量",
                    "kcal",
                    "食物中所含的热量，表示为千卡",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"),
                    "蛋白质",
                    "g",
                    "食物中所含的蛋白质总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"),
                    "脂肪",
                    "g",
                    "食物中所含的脂肪总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"),
                    "碳水化合物",
                    "g",
                    "食物中所含的碳水化合物总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"),
                    "膳食纤维",
                    "g",
                    "食物中所含的膳食纤维总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd6"),
                    "维生素A",
                    "μg",
                    "食物中所含的维生素A总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"),
                    "维生素C",
                    "mg",
                    "食物中所含的维生素C总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd8"),
                    "维生素E",
                    "mg",
                    "食物中所含的维生素E总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd9"),
                    "钙",
                    "mg",
                    "食物中所含的钙元素总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afe1"),
                    "铁",
                    "mg",
                    "食物中所含的铁元素总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afe2"),
                    "锌",
                    "mg",
                    "食物中所含的锌元素总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afe3"),
                    "钾",
                    "mg",
                    "食物中所含的钾元素总量",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutritionDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afe4"),
                    "钠",
                    "mg",
                    "食物中所含的钠元素总量",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：口味字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedTasteDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TasteDict>().HasData(
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff1"),
                    "SWEET",
                    "甜味",
                    "以甜为主要口味",
                    true,
                    1,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff2"),
                    "SALTY",
                    "咸味",
                    "以咸为主要口味",
                    true,
                    2,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff3"),
                    "SOUR",
                    "酸味",
                    "以酸为主要口味",
                    true,
                    3,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff4"),
                    "BITTER",
                    "苦味",
                    "以苦为主要口味",
                    true,
                    4,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"),
                    "SPICY",
                    "辣味",
                    "以辣为主要口味",
                    true,
                    5,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"),
                    "SWEET_SOUR",
                    "酸甜",
                    "酸甜搭配的口味",
                    true,
                    6,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"),
                    "SALTY_FRESH",
                    "咸鲜",
                    "咸鲜搭配的口味",
                    true,
                    7,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff8"),
                    "SPICY_HOT",
                    "麻辣",
                    "麻辣搭配的口味",
                    true,
                    8,
                    _seedTime,
                    _seedTime
                ),
                // 添加缺少的口味
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"),
                    "SOUR_SPICY",
                    "酸辣",
                    "酸辣搭配的口味",
                    true,
                    9,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affa"),
                    "SALTY_SPICY",
                    "咸辣",
                    "咸辣搭配的口味",
                    true,
                    10,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"),
                    "FRESH",
                    "清淡",
                    "以清淡为主要口味",
                    true,
                    11,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"),
                    "SWEET_SALTY",
                    "甜咸",
                    "甜咸搭配的口味",
                    true,
                    12,
                    _seedTime,
                    _seedTime
                ),
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affd"),
                    "FRESH_SPICY",
                    "鲜辣",
                    "鲜辣搭配的口味",
                    true,
                    13,
                    _seedTime,
                    _seedTime
                ),
                // 添加微辣口味
                new TasteDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affe"),
                    "LIGHT_SPICY",
                    "微辣",
                    "轻微辣味，口感温和",
                    true,
                    14,
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：烹饪方式字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedCookingMethodDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CookingMethodDict>().HasData(
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"),
                    "FRY",
                    "炒",
                    "快速翻炒烹饪方式",
                    true,
                    1,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff2"),
                    "STEAM",
                    "蒸",
                    "蒸汽加热烹饪方式",
                    true,
                    2,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"),
                    "BOIL",
                    "煮",
                    "水煮烹饪方式",
                    true,
                    3,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff4"),
                    "STEW",
                    "炖",
                    "慢火长时间烹饪方式",
                    true,
                    4,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff5"),
                    "DEEP_FRY",
                    "炸",
                    "油炸烹饪方式",
                    true,
                    5,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff6"),
                    "BAKE",
                    "烤",
                    "烤箱烹饪方式",
                    true,
                    6,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff7"),
                    "SAUTE",
                    "煎",
                    "小火煎制烹饪方式",
                    true,
                    7,
                    _seedTime,
                    _seedTime
                ),
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"),
                    "BRAISE",
                    "焖",
                    "加盖闷煮烹饪方式",
                    true,
                    8,
                    _seedTime,
                    _seedTime
                ),
                // 添加冷菜烹饪方式
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff9"),
                    "COLD_DISH",
                    "冷菜",
                    "不需加热直接食用的烹饪方式",
                    true,
                    9,
                    _seedTime,
                    _seedTime
                ),
                // 添加发酵烹饪方式
                new CookingMethodDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bffa"),
                    "FERMENT",
                    "发酵",
                    "通过微生物作用发酵制作的烹饪方式",
                    true,
                    10,
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：菜系字典
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedCuisineDicts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuisineDict>().HasData(
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"),
                    "SICHUAN",
                    "川菜",
                    "四川菜系，特点是麻辣鲜香",
                    true,
                    1,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"),
                    "CANTONESE",
                    "粤菜",
                    "广东菜系，特点是清淡鲜美",
                    true,
                    2,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"),
                    "SHANDONG",
                    "鲁菜",
                    "山东菜系，特点是咸鲜为主",
                    true,
                    3,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff4"),
                    "JIANGSU",
                    "苏菜",
                    "江苏菜系，特点是清鲜甘醇",
                    true,
                    4,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff5"),
                    "ZHEJIANG",
                    "浙菜",
                    "浙江菜系，特点是鲜嫩脆爽",
                    true,
                    5,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff6"),
                    "ANHUI",
                    "徽菜",
                    "安徽菜系，特点是注重火功",
                    true,
                    6,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff7"),
                    "FUJIAN",
                    "闽菜",
                    "福建菜系，特点是清鲜、和、精",
                    true,
                    7,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff8"),
                    "HUNAN",
                    "湘菜",
                    "湖南菜系，特点是香辣酸",
                    true,
                    8,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff9"),
                    "WESTERN",
                    "西餐",
                    "西方国家菜系",
                    true,
                    9,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cffa"),
                    "JAPANESE",
                    "日料",
                    "日本料理",
                    true,
                    10,
                    _seedTime,
                    _seedTime
                ),
                new CuisineDict(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cffb"),
                    "KOREAN",
                    "韩餐",
                    "韩国料理",
                    true,
                    11,
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：角色
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"),
                    "ADMIN",
                    "系统管理员",
                    "拥有所有权限，包括系统管理、用户管理、内容管理等",
                    _seedTime,
                    _seedTime
                ),
                new Role(
                    RoleConstants.USER_ROLE_ID,
                    RoleConstants.USER_ROLE_CODE,
                    RoleConstants.USER_ROLE_NAME,
                    "基础权限：只能创建20个菜式，创建最近两周的菜谱，只能在一个家庭里面",
                    _seedTime,
                    _seedTime
                ),
                new Role(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d003"),
                    "VIP",
                    "VIP用户",
                    "高级权限：能创建50个菜式，创建最近两个月的菜谱，可以在5个家庭里面",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：权限
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedPermissions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                // 系统管理权限
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e001"),
                    "system.manage",
                    "系统管理权限",
                    "系统管理",
                    _seedTime,
                    _seedTime
                ),
                
                // 菜式权限
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e002"),
                    "recipe.create.basic",
                    "创建基础数量菜式（20个）",
                    "菜式管理",
                    _seedTime,
                    _seedTime
                ),
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e003"),
                    "recipe.create.advanced",
                    "创建高级数量菜式（50个）",
                    "菜式管理",
                    _seedTime,
                    _seedTime
                ),
                
                // 菜谱时间范围权限
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e004"),
                    "recipe.timerange.twoweeks",
                    "创建最近两周的菜谱",
                    "菜谱管理",
                    _seedTime,
                    _seedTime
                ),
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e005"),
                    "recipe.timerange.twomonths",
                    "创建最近两个月的菜谱",
                    "菜谱管理",
                    _seedTime,
                    _seedTime
                ),
                
                // 家庭数量权限
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e006"),
                    "family.count.one",
                    "最多加入一个家庭",
                    "家庭管理",
                    _seedTime,
                    _seedTime
                ),
                new Permission(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e007"),
                    "family.count.five",
                    "最多加入五个家庭",
                    "家庭管理",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：权限映射
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedPermissionMappings(this ModelBuilder modelBuilder)
        {
            // 系统管理员的权限映射（拥有所有权限）
            modelBuilder.Entity<PermissionMapping>().HasData(
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f001"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"), // 管理员角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e001"), // 系统管理权限
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f002"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"), // 管理员角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e003"), // 高级菜式数量
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f003"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"), // 管理员角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e005"), // 两个月菜谱
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f004"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"), // 管理员角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e007"), // 五个家庭
                    true,
                    _seedTime,
                    _seedTime
                ),
                
                // 普通用户的权限映射
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f005"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d002"), // 普通用户角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e002"), // 基础菜式数量
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f006"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d002"), // 普通用户角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e004"), // 两周菜谱
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f007"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d002"), // 普通用户角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e006"), // 一个家庭
                    true,
                    _seedTime,
                    _seedTime
                ),
                
                // VIP用户的权限映射
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f008"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d003"), // VIP角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e003"), // 高级菜式数量
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f009"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d003"), // VIP角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e005"), // 两个月菜谱
                    true,
                    _seedTime,
                    _seedTime
                ),
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f010"),
                    ObjectType.Role,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d003"), // VIP角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e007"), // 五个家庭
                    true,
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：用户
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedUsers(this ModelBuilder modelBuilder)
        {
            // 注意：这里需要查看User实体中是否有对应的种子数据构造函数
            // 如果没有，需要先在User实体中添加一个包含所有必要参数的构造函数
            modelBuilder.Entity<User>().HasData(
                // 假设User实体有一个适当的种子数据构造函数，参数顺序需要与实体中定义的一致
                // 这里的参数顺序和数量可能需要根据实际的User实体构造函数进行调整
                new User(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66a001"),
                    "ADMIN001",
                    "admin",
                    "21232f297a57a5a743894a0e4a801fc3", // admin的MD5加密
                    "13800000000",
                    "系统管理员",
                    "/assets/images/avatars/admin.png",
                    UserStatus.Enabled,
                    _seedTime,
                    _seedTime
                )
            );

            modelBuilder.Entity<PermissionMapping>().HasData(
                new PermissionMapping(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66f104"),
                    ObjectType.User,
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66a001"), // 管理员角色ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66e001"), // 系统管理权限
                    true,
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：用户角色关系
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66a101"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66a001"), // 管理员用户ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66d001"), // 管理员角色ID
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：食材基础信息
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedIngredients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
                // 鸡胸肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"),
                    "鸡胸肉",
                    IngredientCategory.Meat,
                    "中",
                    "鲜味",
                    "提供优质蛋白质",
                    "易熟易老",
                    "切片,切丁",
                    false,
                    "优质蛋白质来源，低脂肪",
                    _seedTime,
                    _seedTime),

                // 豆腐
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"),
                    "豆腐",
                    IngredientCategory.BeanProduct,
                    "高",
                    "清淡",
                    "提供植物蛋白",
                    "易碎,吸味",
                    "切块,炸,烫",
                    false,
                    "富含植物蛋白和钙质",
                    _seedTime,
                    _seedTime),

                // 青椒
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"),
                    "青椒",
                    IngredientCategory.Vegetable,
                    "高",
                    "微辣,清香",
                    "提供维生素C",
                    "爆炒保脆",
                    "切丝,切块",
                    false,
                    "富含维生素C和抗氧化物质",
                    _seedTime,
                    _seedTime),

                // 姜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa04"),
                    "姜",
                    IngredientCategory.Seasoning,
                    "中",
                    "辛辣",
                    "去腥,提香",
                    "爆香",
                    "切片,切丝,切末",
                    true,
                    "常用于提味和去腥",
                    _seedTime,
                    _seedTime),

                // 蒜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa05"),
                    "蒜",
                    IngredientCategory.Seasoning,
                    "低",
                    "辛辣",
                    "提香,增味",
                    "爆香",
                    "切片,切末,压泥",
                    true,
                    "常用于提味和增香",
                    _seedTime,
                    _seedTime),

                // 酱油
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa06"),
                    "酱油",
                    IngredientCategory.Seasoning,
                    "高",
                    "咸鲜",
                    "调味,上色",
                    "易糊",
                    "调味",
                    false,
                    "提供咸鲜味和褐色",
                    _seedTime,
                    _seedTime),

                // 盐
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa07"),
                    "盐",
                    IngredientCategory.Seasoning,
                    "极低",
                    "咸",
                    "调味",
                    "增强口感",
                    "调味",
                    false,
                    "基础调味品",
                    _seedTime,
                    _seedTime),

                // 木耳
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"),
                    "木耳",
                    IngredientCategory.Fungus,
                    "低(干品), 高(泡发后)",
                    "清香",
                    "补血,清肠",
                    "爽脆,吸味",
                    "泡发,切碎",
                    false,
                    "富含膳食纤维和铁质",
                    _seedTime,
                    _seedTime),
                
                // 牛肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"),
                    "牛肉",
                    IngredientCategory.Meat,
                    "低",
                    "鲜香",
                    "提供优质蛋白质和铁质",
                    "纤维感强,需要煮烂",
                    "切片,切丁,切条",
                    false,
                    "富含优质蛋白质和铁质，有助于补血",
                    _seedTime,
                    _seedTime),
                
                // 猪肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"),
                    "猪肉",
                    IngredientCategory.Meat,
                    "中",
                    "鲜甜",
                    "提供蛋白质和脂肪",
                    "油脂较多",
                    "切片,切丝,剁馅",
                    false,
                    "常见肉类，口感滑嫩",
                    _seedTime,
                    _seedTime),
                
                // 五花肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"),
                    "五花肉",
                    IngredientCategory.Meat,
                    "极低",
                    "肥美",
                    "提供丰富脂肪和蛋白质",
                    "需要长时间烹煮才够酥烂",
                    "切片,切块",
                    false,
                    "肥瘦相间，适合红烧、扣肉等",
                    _seedTime,
                    _seedTime),
                
                // 羊肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa12"),
                    "羊肉",
                    IngredientCategory.Meat,
                    "低",
                    "膻香",
                    "提供蛋白质和维生素",
                    "肉质细嫩,需去膻",
                    "切片,切块",
                    false,
                    "温补食材，冬季常食",
                    _seedTime,
                    _seedTime),
                
                // 鸭肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa13"),
                    "鸭肉",
                    IngredientCategory.Meat,
                    "低",
                    "鲜香",
                    "提供蛋白质和脂肪",
                    "肉质较韧,需适当烹煮",
                    "切块,切片",
                    false,
                    "肉质细嫩，脂肪含量适中",
                    _seedTime,
                    _seedTime),
                
                // 鱼肉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"),
                    "鱼肉",
                    IngredientCategory.Seafood,
                    "高",
                    "鲜香",
                    "提供优质蛋白质和不饱和脂肪酸",
                    "肉质脆嫩,易碎",
                    "片,切块",
                    false,
                    "富含蛋白质和DHA，有益健康",
                    _seedTime,
                    _seedTime),
                
                // 虾
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"),
                    "虾",
                    IngredientCategory.Seafood,
                    "高",
                    "鲜甜",
                    "提供优质蛋白质和矿物质",
                    "肉质爽脆,易熟",
                    "去壳,拍扁",
                    false,
                    "富含蛋白质，口感鲜甜",
                    _seedTime,
                    _seedTime),
                
                // 螃蟹
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa16"),
                    "螃蟹",
                    IngredientCategory.Seafood,
                    "中",
                    "鲜美",
                    "提供优质蛋白质",
                    "需要适当处理",
                    "清洗,去壳",
                    false,
                    "鲜美海鲜，富含蛋白质",
                    _seedTime,
                    _seedTime),
                
                // 茄子
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"),
                    "茄子",
                    IngredientCategory.Vegetable,
                    "高",
                    "清淡",
                    "提供膳食纤维",
                    "吸油,易软烂",
                    "切块,切条",
                    false,
                    "质地柔软，吸味能力强",
                    _seedTime,
                    _seedTime),
                
                // 土豆
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"),
                    "土豆",
                    IngredientCategory.Vegetable,
                    "中",
                    "清淡微甜",
                    "提供碳水化合物和维生素C",
                    "煮熟才可食用",
                    "切丝,切片,切块",
                    false,
                    "富含淀粉，可作主食或配菜",
                    _seedTime,
                    _seedTime),
                
                // 黄瓜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa19"),
                    "黄瓜",
                    IngredientCategory.Vegetable,
                    "极高",
                    "清爽",
                    "补水,提供膳食纤维",
                    "脆嫩多汁",
                    "切片,切条,拍碎",
                    false,
                    "水分充足，适合生食凉拌",
                    _seedTime,
                    _seedTime),
                
                // 西红柿
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa20"),
                    "西红柿",
                    IngredientCategory.Vegetable,
                    "高",
                    "酸甜",
                    "提供维生素C和番茄红素",
                    "多汁,酸甜",
                    "切片,切块",
                    false,
                    "富含番茄红素，有抗氧化作用",
                    _seedTime,
                    _seedTime),
                
                // 韭菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa21"),
                    "韭菜",
                    IngredientCategory.Vegetable,
                    "高",
                    "独特香气",
                    "提供膳食纤维和维生素",
                    "香味浓郁",
                    "切段",
                    false,
                    "香气浓郁，常与鸡蛋同炒",
                    _seedTime,
                    _seedTime),
                
                // 葱
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa22"),
                    "葱",
                    IngredientCategory.Seasoning,
                    "高",
                    "辛香",
                    "提香,增味",
                    "香味浓郁",
                    "切段,切丝,切花",
                    true,
                    "常用调味品，提香去腥",
                    _seedTime,
                    _seedTime),
                
                // 鸡蛋
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"),
                    "鸡蛋",
                    IngredientCategory.Other,
                    "低",
                    "鲜香",
                    "提供优质蛋白质",
                    "熟制方式多样",
                    "打散,煎,蒸",
                    false,
                    "营养丰富，烹饪方式多样",
                    _seedTime,
                    _seedTime),
                
                // 米饭
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa24"),
                    "米饭",
                    IngredientCategory.Grain,
                    "低",
                    "淡香",
                    "提供碳水化合物",
                    "口感柔软",
                    "蒸熟,炒",
                    false,
                    "主食，可做多种米饭料理",
                    _seedTime,
                    _seedTime),
                
                // 面条
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa25"),
                    "面条",
                    IngredientCategory.Grain,
                    "低",
                    "麦香",
                    "提供碳水化合物",
                    "韧性好",
                    "煮,炒,拌",
                    false,
                    "多种烹饪方式，可做汤面或炒面",
                    _seedTime,
                    _seedTime),
                
                // 花椒
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa26"),
                    "花椒",
                    IngredientCategory.Seasoning,
                    "极低",
                    "麻香",
                    "增香,提味",
                    "麻味强烈",
                    "炒香,研磨",
                    true,
                    "川菜常用调料，有独特麻味",
                    _seedTime,
                    _seedTime),
                
                // 干辣椒
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa27"),
                    "干辣椒",
                    IngredientCategory.Seasoning,
                    "极低",
                    "辣",
                    "增辣,提色",
                    "辣味浓郁",
                    "切段,泡发,炒香",
                    true,
                    "增添菜品辣味和红色",
                    _seedTime,
                    _seedTime),
                
                // 香菇
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa28"),
                    "香菇",
                    IngredientCategory.Fungus,
                    "高",
                    "鲜香",
                    "提供膳食纤维和蛋白质",
                    "鲜香味浓",
                    "切片,切丁",
                    false,
                    "菌类食材，风味独特",
                    _seedTime,
                    _seedTime),
                
                // 西兰花
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa29"),
                    "西兰花",
                    IngredientCategory.Vegetable,
                    "高",
                    "清香",
                    "提供维生素和膳食纤维",
                    "爽脆清香",
                    "切小朵",
                    false,
                    "富含维生素C和膳食纤维",
                    _seedTime,
                    _seedTime),
                
                // 油菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa30"),
                    "油菜",
                    IngredientCategory.Vegetable,
                    "高",
                    "清香",
                    "提供膳食纤维和维生素",
                    "质地柔嫩",
                    "切段",
                    false,
                    "叶绿菜，营养丰富易消化",
                    _seedTime,
                    _seedTime),
                
                // 莲藕
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa31"),
                    "莲藕",
                    IngredientCategory.Vegetable,
                    "中",
                    "清甜",
                    "提供淀粉和膳食纤维",
                    "脆嫩多孔",
                    "切片,切丁",
                    false,
                    "爽脆可口，可凉拌或炖煮",
                    _seedTime,
                    _seedTime),
                
                // 排骨
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa32"),
                    "排骨",
                    IngredientCategory.Meat,
                    "低",
                    "鲜香",
                    "提供蛋白质和钙质",
                    "骨肉相连",
                    "切段",
                    false,
                    "肉质鲜嫩，骨髓丰富",
                    _seedTime,
                    _seedTime),
                
                // 鱼头
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa33"),
                    "鱼头",
                    IngredientCategory.Seafood,
                    "中",
                    "鲜美",
                    "提供蛋白质和胶原蛋白",
                    "肉多刺多",
                    "切块",
                    false,
                    "肉质鲜嫩，适合炖煮或蒸制",
                    _seedTime,
                    _seedTime),
                
                // 梅菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa34"),
                    "梅菜",
                    IngredientCategory.Vegetable,
                    "中",
                    "咸香",
                    "提供膳食纤维",
                    "咸味浓郁",
                    "泡发,切碎",
                    false,
                    "腌制蔬菜，咸香可口",
                    _seedTime,
                    _seedTime),
                
                // 四季豆
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa35"),
                    "四季豆",
                    IngredientCategory.Vegetable,
                    "高",
                    "清香",
                    "提供膳食纤维和蛋白质",
                    "需煮熟食用",
                    "切段,去筋",
                    false,
                    "含植物蛋白，煮熟后食用",
                    _seedTime,
                    _seedTime),
                
                // 鸭肠
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa36"),
                    "鸭肠",
                    IngredientCategory.Meat,
                    "低",
                    "鲜香",
                    "提供蛋白质",
                    "脆嫩爽口",
                    "清洗,切段",
                    false,
                    "脆嫩有弹性，口感独特",
                    _seedTime,
                    _seedTime),
                
                // 酸菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa37"),
                    "酸菜",
                    IngredientCategory.Vegetable,
                    "高",
                    "酸爽",
                    "提供益生菌和膳食纤维",
                    "酸味浓郁",
                    "切段,挤干",
                    false,
                    "发酵蔬菜，酸爽开胃",
                    _seedTime,
                    _seedTime),
                
                // 河粉
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa38"),
                    "河粉",
                    IngredientCategory.Grain,
                    "低",
                    "米香",
                    "提供碳水化合物",
                    "柔滑爽口",
                    "焯水,炒",
                    false,
                    "宽扁米粉，口感滑爽",
                    _seedTime,
                    _seedTime),
                
                // 香茅
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa39"),
                    "香茅",
                    IngredientCategory.Seasoning,
                    "高",
                    "清香",
                    "提香,去腥",
                    "香味独特",
                    "切段,拍松",
                    true,
                    "泰国料理常用香料",
                    _seedTime,
                    _seedTime),
                
                // 柠檬叶
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa40"),
                    "柠檬叶",
                    IngredientCategory.Seasoning,
                    "高",
                    "清香",
                    "提香,增味",
                    "香气浓郁",
                    "切片,整叶",
                    true,
                    "泰国料理常用香料，柑橘香气",
                    _seedTime,
                    _seedTime),
                
                // 白菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa41"),
                    "白菜",
                    IngredientCategory.Vegetable,
                    "高",
                    "清甜",
                    "提供膳食纤维和维生素",
                    "口感柔嫩",
                    "切段,切片",
                    false,
                    "常见蔬菜，可炒可煮可腌制",
                    _seedTime,
                    _seedTime),
                
                // 生菜
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa42"),
                    "生菜",
                    IngredientCategory.Vegetable,
                    "极高",
                    "清爽",
                    "提供膳食纤维和维生素",
                    "脆嫩多水",
                    "撕片,整叶",
                    false,
                    "多水脆嫩，常用于沙拉",
                    _seedTime,
                    _seedTime),
                
                // 牛腩
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa43"),
                    "牛腩",
                    IngredientCategory.Meat,
                    "低",
                    "浓香",
                    "提供蛋白质和胶原蛋白",
                    "纤维较多,需炖煮",
                    "切块",
                    false,
                    "肉质紧实，需长时间炖煮",
                    _seedTime,
                    _seedTime),
                
                // 蚝油
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa44"),
                    "蚝油",
                    IngredientCategory.Seasoning,
                    "中",
                    "鲜咸",
                    "提鲜,增香",
                    "浓稠鲜香",
                    "调味",
                    false,
                    "浓稠酱料，增添鲜味",
                    _seedTime,
                    _seedTime),
                
                // 剁椒
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa45"),
                    "剁椒",
                    IngredientCategory.Seasoning,
                    "低",
                    "辣咸",
                    "增辣,提味",
                    "辣味浓郁",
                    "调味",
                    false,
                    "湖南特色调味品，辣咸开胃",
                    _seedTime,
                    _seedTime),
                
                // 孜然
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa46"),
                    "孜然",
                    IngredientCategory.Seasoning,
                    "极低",
                    "香辣",
                    "增香,提味",
                    "香气独特",
                    "研磨,撒面",
                    true,
                    "西北风味调料，香气特殊",
                    _seedTime,
                    _seedTime),
                
                // 寿司醋
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa47"),
                    "寿司醋",
                    IngredientCategory.Seasoning,
                    "中",
                    "酸甜",
                    "调味,提鲜",
                    "酸甜平衡",
                    "调味",
                    false,
                    "制作寿司的专用调味料",
                    _seedTime,
                    _seedTime),
                
                // 海苔
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa48"),
                    "海苔",
                    IngredientCategory.Seafood,
                    "高",
                    "海鲜香",
                    "包裹,装饰",
                    "薄脆",
                    "切片,整片",
                    false,
                    "日本料理常用食材",
                    _seedTime,
                    _seedTime),
                
                // 腐竹
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa49"),
                    "腐竹",
                    IngredientCategory.BeanProduct,
                    "低",
                    "豆香",
                    "提供植物蛋白",
                    "质地筋道",
                    "泡发,切段",
                    false,
                    "富含植物蛋白，口感筋道",
                    _seedTime,
                    _seedTime),
                
                // 芝麻
                new Ingredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa50"),
                    "芝麻",
                    IngredientCategory.Nut,
                    "极低",
                    "香浓",
                    "增香,装饰",
                    "香气浓郁",
                    "炒香,研磨",
                    true,
                    "增添香气和装饰效果",
                    _seedTime,
                    _seedTime)
            );
        }

        /// <summary>
        /// 种子数据：食材营养成分
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedIngredientNutritions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientNutrition>().HasData(
                // 鸡胸肉的营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab01"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    113m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab02"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    23.3m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab03"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    1.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 豆腐的营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab04"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    76m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab05"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    8.1m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 青椒的营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab06"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"), // 青椒ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    20m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab07"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"), // 青椒ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"), // 膳食纤维ID
                    1.4m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 木耳的营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab08"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    284m,
                    "100g干品",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab09"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"), // 膳食纤维ID
                    38.9m,
                    "100g干品",
                    _seedTime,
                    _seedTime
                ),
                
                // 牛肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab10"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    125m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab11"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    22.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab12"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    3.8m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab13"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afe1"), // 铁ID
                    3.0m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 猪肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab14"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"), // 猪肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    143m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab15"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"), // 猪肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    18.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab16"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"), // 猪肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    8.0m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 五花肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab17"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"), // 五花肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    395m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab18"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"), // 五花肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    12.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab19"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"), // 五花肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    37.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 鱼肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab20"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"), // 鱼肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    106m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab21"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"), // 鱼肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    20.1m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab22"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"), // 鱼肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    2.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 虾营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab23"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"), // 虾ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    95m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab24"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"), // 虾ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    20.3m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab25"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"), // 虾ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    1.1m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 茄子营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab26"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    24m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab27"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"), // 碳水化合物ID
                    5.7m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab28"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"), // 膳食纤维ID
                    2.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 土豆营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab29"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    81m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab30"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"), // 碳水化合物ID
                    19.1m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab31"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    27m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 西红柿营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab32"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa20"), // 西红柿ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    18m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab33"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa20"), // 西红柿ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    14m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 黄瓜营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab34"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa19"), // 黄瓜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    15m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab35"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa19"), // 黄瓜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"), // 膳食纤维ID
                    0.8m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 鸡蛋营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab36"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"), // 鸡蛋ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    144m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab37"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"), // 鸡蛋ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    12.8m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab38"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"), // 鸡蛋ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    10.3m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 米饭营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab39"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa24"), // 米饭ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    116m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab40"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa24"), // 米饭ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"), // 碳水化合物ID
                    25.9m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 面条营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab41"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa25"), // 面条ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    138m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab42"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa25"), // 面条ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"), // 碳水化合物ID
                    28.7m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 香菇营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab43"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa28"), // 香菇ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    34m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab44"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa28"), // 香菇ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd5"), // 膳食纤维ID
                    2.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 西兰花营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab45"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa29"), // 西兰花ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    34m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab46"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa29"), // 西兰花ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    89m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 油菜营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab47"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa30"), // 油菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    20m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab48"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa30"), // 油菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    35m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 莲藕营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab49"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa31"), // 莲藕ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    74m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab50"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa31"), // 莲藕ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd4"), // 碳水化合物ID
                    17.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 排骨营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab51"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa32"), // 排骨ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    213m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab52"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa32"), // 排骨ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    16.9m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab53"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa32"), // 排骨ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    15.2m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 白菜营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab54"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa41"), // 白菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    12m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab55"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa41"), // 白菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    27m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 生菜营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab56"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa42"), // 生菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    15m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab57"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa42"), // 生菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    9m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 牛腩营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab58"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa43"), // 牛腩ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    252m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab59"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa43"), // 牛腩ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    19.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab60"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa43"), // 牛腩ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    18.7m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 韭菜营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab61"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa21"), // 韭菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    27m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab62"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa21"), // 韭菜ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd7"), // 维生素C ID
                    27m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 羊肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab63"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa12"), // 羊肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    203m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab64"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa12"), // 羊肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    18.8m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab65"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa12"), // 羊肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    14.5m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 鸭肉营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab66"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa13"), // 鸭肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    240m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab67"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa13"), // 鸭肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    16.2m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab68"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa13"), // 鸭肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd3"), // 脂肪ID
                    19.7m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                
                // 四季豆营养成分
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab69"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa35"), // 四季豆ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd1"), // 能量ID
                    33m,
                    "100g",
                    _seedTime,
                    _seedTime
                ),
                new IngredientNutrition(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ab70"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa35"), // 四季豆ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afd2"), // 蛋白质ID
                    1.9m,
                    "100g",
                    _seedTime,
                    _seedTime
                )
                
            );
        }
        
        /// <summary>
        /// 种子数据：食材适宜/忌用人群
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedIngredientHumanGroups(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientHumanGroup>().HasData(
                // 鸡胸肉适宜人群
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac01"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb1"), // 孕妇ID
                    EffectType.Suitable,
                    "优质蛋白质来源，适合孕期补充营养",
                    _seedTime,
                    _seedTime
                ),
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac02"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb6"), // 糖尿病ID
                    EffectType.Suitable,
                    "低脂肪高蛋白，适合糖尿病人食用",
                    _seedTime,
                    _seedTime
                ),
                
                // 豆腐适宜/忌用人群
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac03"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb7"), // 高血压ID
                    EffectType.Suitable,
                    "低钠高钙，适合高血压患者",
                    _seedTime,
                    _seedTime
                ),
                
                // 青椒适宜/忌用人群
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac04"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"), // 青椒ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb5"), // 老人ID
                    EffectType.UseWithCaution,
                    "部分老人可能不易消化青椒的皮",
                    _seedTime,
                    _seedTime
                ),
                
                // 木耳适宜/忌用人群
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac05"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb8"), // 高血脂ID
                    EffectType.Suitable,
                    "含有膳食纤维，有助降低血脂",
                    _seedTime,
                    _seedTime
                ),
                new IngredientHumanGroup(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ac06"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afb1"), // 孕妇ID
                    EffectType.Suitable,
                    "富含铁质，有助预防孕期贫血",
                    _seedTime,
                    _seedTime
                )
            );
        }
        
        /// <summary>
        /// 种子数据：食材预处理
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedIngredientPreprocesses(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientPreprocess>().HasData(
                // 鸡胸肉预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad01"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    "切丝",
                    "将鸡胸肉洗净，切成细丝，便于快速烹饪",
                    120,
                    "室温",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/chicken-slice.jpg" // 添加ImageUrl
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad02"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    "腌制",
                    "将切好的鸡胸肉加入盐、淀粉和料酒腌制入味",
                    600,
                    "冷藏",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/chicken-marinate.jpg" // 添加ImageUrl
                ),
                
                // 豆腐预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad03"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    "切块",
                    "将豆腐切成均匀的小方块",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/tofu-cube.jpg" // 添加ImageUrl
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad04"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    "焯水",
                    "将豆腐块放入沸水中焯烫30秒，捞出沥干水分",
                    30,
                    "沸水",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/tofu-blanch.jpg" // 添加ImageUrl
                ),
                
                // 青椒预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad05"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"), // 青椒ID
                    "切丝",
                    "将青椒洗净，去蒂和籽，切成细丝",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/pepper-slice.jpg" // 添加ImageUrl
                ),
                
                // 木耳预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad06"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    "泡发",
                    "将干木耳放入冷水中浸泡至完全泡发",
                    7200,
                    "冷水",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/black-fungus-soak.jpg" // 添加ImageUrl
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad07"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    "去杂",
                    "将泡发后的木耳去除根部和硬质部分",
                    120,
                    "室温",
                    _seedTime,
                    _seedTime,
                    "/assets/images/preprocess/black-fungus-clean.jpg" // 添加ImageUrl
                ),
                
                // 姜预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad08"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa04"), // 姜ID
                    "切末",
                    "将姜去皮洗净后切成细末，便于爆香提味",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad09"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa04"), // 姜ID
                    "切片",
                    "将姜去皮洗净后切成薄片，适合用于煮汤或焖煮菜肴",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 蒜预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad10"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa05"), // 蒜ID
                    "切末",
                    "将蒜去皮后切成细末，便于爆香增味",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad11"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa05"), // 蒜ID
                    "拍碎",
                    "将蒜瓣用刀背拍碎，保留整体形状，适合烹饪大块食材",
                    30,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 酱油预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad12"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa06"), // 酱油ID
                    "调配",
                    "根据菜式需要与其他调料混合调配，如加入糖、料酒等",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 牛肉预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad13"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    "切片",
                    "将牛肉逆着纹理切成薄片，适合快炒或火锅",
                    120,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad14"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    "切丁",
                    "将牛肉切成1-2厘米的小丁，适合红烧或炖煮",
                    90,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad15"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa09"), // 牛肉ID
                    "腌制",
                    "将牛肉加入料酒、酱油、姜片等腌制入味",
                    300,
                    "冷藏",
                    _seedTime,
                    _seedTime
                ),
                
                // 猪肉预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad16"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"), // 猪肉ID
                    "切丝",
                    "将猪肉切成细丝，适合炒菜",
                    90,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad17"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa10"), // 猪肉ID
                    "剁末",
                    "将猪肉剁成肉末，适合肉馅或肉沫炒菜",
                    120,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 五花肉预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad18"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"), // 五花肉ID
                    "切片",
                    "将五花肉切成薄片，适合煸炒或烤制",
                    90,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad19"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa11"), // 五花肉ID
                    "切块",
                    "将五花肉切成方块，适合红烧或炖煮",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 茄子预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad20"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    "切条",
                    "将茄子切成长条，适合炒菜或炸制",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad21"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    "切块",
                    "将茄子切成方块，适合烧煮或炖汤",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad22"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa17"), // 茄子ID
                    "盐水浸泡",
                    "将切好的茄子放入盐水中浸泡，减少吸油量",
                    600,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 土豆预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad23"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    "切丝",
                    "将土豆切成细丝，适合快炒或炸薯条",
                    90,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad24"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    "切块",
                    "将土豆切成方块，适合炖煮或烧菜",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad25"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa18"), // 土豆ID
                    "水浸泡",
                    "将切好的土豆放入清水中浸泡，去除多余淀粉",
                    300,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 黄瓜预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad26"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa19"), // 黄瓜ID
                    "切片",
                    "将黄瓜切成圆片，适合凉拌或沙拉",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad27"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa19"), // 黄瓜ID
                    "切丝",
                    "将黄瓜切成细丝，适合凉拌或热炒",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                
                // 西红柿预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad28"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa20"), // 西红柿ID
                    "切块",
                    "将西红柿切成方块，适合炒菜或煮汤",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad29"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa20"), // 西红柿ID
                    "去皮",
                    "将西红柿放入沸水中烫30秒，然后迅速放入冷水中，去皮",
                    120,
                    "沸水",
                    _seedTime,
                    _seedTime
                ),
                
                // 鸡蛋预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad30"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"), // 鸡蛋ID
                    "打散",
                    "将鸡蛋打入碗中搅拌均匀，适合炒蛋或蒸蛋",
                    60,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad31"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa23"), // 鸡蛋ID
                    "煮熟",
                    "将鸡蛋放入冷水中，煮沸后继续煮5-7分钟，煮熟",
                    420,
                    "沸水",
                    _seedTime,
                    _seedTime
                ),
                
                // 鱼肉预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad32"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"), // 鱼肉ID
                    "去刺",
                    "将鱼肉处理后去除鱼刺，便于食用",
                    180,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad33"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa14"), // 鱼肉ID
                    "腌制",
                    "将鱼肉加入盐、料酒、姜片腌制，去除腥味",
                    600,
                    "冷藏",
                    _seedTime,
                    _seedTime
                ),
                
                // 虾预处理
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad34"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"), // 虾ID
                    "去壳",
                    "去除虾壳、虾头和虾线，保留虾肉",
                    180,
                    "室温",
                    _seedTime,
                    _seedTime
                ),
                new IngredientPreprocess(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ad35"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa15"), // 虾ID
                    "腌制",
                    "用盐、料酒、姜片腌制虾肉，去腥增味",
                    300,
                    "冷藏",
                    _seedTime,
                    _seedTime
                )
            );
        }

        /// <summary>
        /// 种子数据：菜式
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedRecipes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                // 鸡丝炒木耳
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"),
                    "鸡丝炒木耳",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/jisi-muer.jpg",
                    "鸡丝炒木耳是一道营养健康的家常菜，木耳的脆嫩与鸡丝的鲜香相得益彰，色香味俱全。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣味
                    DifficultyLevel.Easy, // 简单
                    10, // 准备时间
                    15, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 麻婆豆腐
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"),
                    "麻婆豆腐",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mapo-tofu.jpg",
                    "麻婆豆腐是四川传统名菜，由豆腐、牛肉末和辣椒等烹制而成，麻辣鲜香，口感丰富。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 焖
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff8"), // 麻辣
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    20, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 清蒸鱼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"),
                    "清蒸鱼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-fish.jpg",
                    "清蒸鱼是一道广东名菜，保留了鱼的鲜美与营养，口感细嫩，清淡鲜香。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff2"), // 蒸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    15, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 宫保鸡丁
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba04"),
                    "宫保鸡丁",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/kungpao-chicken.jpg",
                    "宫保鸡丁是川菜代表菜之一，鸡肉鲜嫩，花生香脆，辣味适中，口感丰富。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣味
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 红烧肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"),
                    "红烧肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-pork.jpg",
                    "红烧肉是中国特色传统名菜，五花肉经过焯水、煸炒、红烧等工序制作而成，肥而不腻，入口即化。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 苏菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 焖
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"), // 酸甜
                    DifficultyLevel.Medium, // 中等
                    30, // 准备时间
                    90, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 鱼香肉丝
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba06"),
                    "鱼香肉丝",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/yuxiang-pork.jpg",
                    "鱼香肉丝是四川名菜，以猪肉丝、木耳、笋丝等为主料，调以鱼香味型调料烹制而成，酸甜辣香。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff3"), // 酸味(SOUR)
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 蔬菜沙拉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba07"),
                    "蔬菜沙拉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/vegetable-salad.jpg",
                    "蔬菜沙拉是一道健康低卡的素食料理，富含多种维生素和膳食纤维，清爽可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff9"), // 西餐
                    null, // 冷菜(暂无此选项，设为null)
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"), // 酸甜
                    DifficultyLevel.Easy, // 简单
                    15, // 准备时间
                    0, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 糖醋排骨
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba08"),
                    "糖醋排骨",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sweet-sour-ribs.jpg",
                    "糖醋排骨是一道传统汉族名菜，属于粤菜系。以猪排骨为主料，配以糖、醋等调料烹制而成，口味酸甜可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff5"), // 炸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"), // 酸甜
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    40, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 水煮鱼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba09"),
                    "水煮鱼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/boiled-fish.jpg",
                    "水煮鱼是四川传统名菜，以鲜嫩的鱼片配以麻辣的汤底，麻辣鲜香，味道浓郁。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff8"), // 麻辣
                    DifficultyLevel.Hard, // 难
                    30, // 准备时间
                    25, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 蒜蓉西兰花
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba10"),
                    "蒜蓉西兰花",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/garlic-broccoli.jpg",
                    "蒜蓉西兰花是一道营养丰富的素食菜肴，西兰花保持脆嫩，蒜香浓郁，口感清爽。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜 (没有清淡口味，用咸鲜代替)
                    DifficultyLevel.Easy, // 简单
                    10, // 准备时间
                    10, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 酸辣汤
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba11"),
                    "酸辣汤",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/hot-sour-soup.jpg",
                    "酸辣汤是一道经典的中式汤品，酸辣可口，配料丰富，开胃爽口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    20, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 西红柿炒鸡蛋
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba12"),
                    "西红柿炒鸡蛋",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tomato-egg.jpg",
                    "西红柿炒鸡蛋是中国最常见的家常菜之一，酸甜可口，色泽鲜艳，营养丰富。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"), // 酸甜
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    10, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 干煸四季豆
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba13"),
                    "干煸四季豆",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/fried-green-beans.jpg",
                    "干煸四季豆是一道经典川菜，四季豆经过油炸后与肉末一起干煸，干香脆嫩，风味独特。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff5"), // 炸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affa"), // 咸辣
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    20, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 回锅肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba14"),
                    "回锅肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/twice-cooked-pork.jpg",
                    "回锅肉是四川传统名菜，将煮熟的猪肉与青椒、蒜苗一起煸炒，肥而不腻，口感独特。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 蚝油生菜
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba15"),
                    "蚝油生菜",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/oyster-sauce-lettuce.jpg",
                    "蚝油生菜是粤菜的代表菜品之一，清淡爽口，健康营养，制作简单快捷。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    5, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 东坡肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba16"),
                    "东坡肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/dongpo-pork.jpg",
                    "东坡肉是江浙名菜，源于宋代文豪苏东坡，肉质软烂，色泽红亮，肥而不腻。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff5"), // 浙菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 烧
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Hard, // 难
                    30, // 准备时间
                    150, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 葱爆羊肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba17"),
                    "葱爆羊肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/scallion-lamb.jpg",
                    "葱爆羊肉是北方传统名菜，羊肉鲜嫩，葱香浓郁，风味独特。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affd"), // 鲜辣
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 鸡蛋羹
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba18"),
                    "鸡蛋羹",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-egg.jpg",
                    "鸡蛋羹是一道传统的家常蒸菜，口感嫩滑，营养丰富，适合各个年龄段的人食用。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff4"), // 苏菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff2"), // 蒸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    15, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 虎皮青椒
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba19"),
                    "虎皮青椒",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/blistered-peppers.jpg",
                    "虎皮青椒是一道家常菜，青椒经过煎制后皮呈焦黄色，状如虎皮，味道鲜香可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff8"), // 湘菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff7"), // 煎
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affe"), // 微辣
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    10, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 香菇油菜
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba20"),
                    "香菇油菜",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mushroom-bokchoy.jpg",
                    "香菇油菜是一道简单健康的素食菜肴，香菇鲜香，油菜清脆，营养丰富。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Easy, // 简单
                    10, // 准备时间
                    8, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 青椒土豆丝
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba21"),
                    "青椒土豆丝",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/pepper-potato.jpg",
                    "青椒土豆丝是一道家常炒菜，土豆丝脆嫩，青椒清香，简单美味。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affe"), // 微辣
                    DifficultyLevel.Easy, // 简单
                    15, // 准备时间
                    10, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 红烧狮子头
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba22"),
                    "红烧狮子头",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-meatballs.jpg",
                    "红烧狮子头是江浙名菜，大肉丸形似狮子头，肉质细嫩，味道鲜美。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff4"), // 苏菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 烧
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Medium, // 中等
                    30, // 准备时间
                    60, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 鱼香茄子
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba23"),
                    "鱼香茄子",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/yuxiang-eggplant.jpg",
                    "鱼香茄子是四川传统名菜，茄子软糯，鱼香味浓郁，酸甜辣香。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    20, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 蒜泥白肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba24"),
                    "蒜泥白肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/garlic-pork.jpg",
                    "蒜泥白肉是四川名菜，将煮熟的猪肉切片，蘸以蒜泥调味汁食用，鲜香爽口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affd"), // 鲜辣
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    60, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 番茄牛腩
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba25"),
                    "番茄牛腩",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tomato-beef-stew.jpg",
                    "番茄牛腩是一道经典粤菜，牛腩炖至软烂，番茄酸甜，汤汁浓郁。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff4"), // 炖
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff6"), // 酸甜
                    DifficultyLevel.Hard, // 难
                    30, // 准备时间
                    120, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 韭菜炒鸡蛋
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba26"),
                    "韭菜炒鸡蛋",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/chive-eggs.jpg",
                    "韭菜炒鸡蛋是一道家常菜，韭菜鲜香，鸡蛋嫩滑，营养丰富。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    10, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 日式寿司
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba27"),
                    "日式寿司",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sushi.jpg",
                    "寿司是日本传统料理，以醋饭配以鱼生、海鲜或蔬菜等食材制成，鲜美可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cffa"), // 日料
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff9"), // 冷菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Hard, // 难
                    40, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 意大利面
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba28"),
                    "意大利肉酱面",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/spaghetti.jpg",
                    "意大利肉酱面是西餐中的经典料理，面条搭配番茄肉酱，风味浓郁。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff9"), // 西餐
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    25, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 泰式冬阴功汤
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba29"),
                    "泰式冬阴功汤",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/tom-yum-soup.jpg",
                    "冬阴功汤是泰国著名的酸辣汤，以香茅、柠檬叶等香料调味，酸辣鲜香。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff9"), // 泰国菜归类到西餐
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 韩式泡菜
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba30"),
                    "韩式泡菜",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/kimchi.jpg",
                    "韩式泡菜是韩国传统发酵食品，酸辣爽口，可作为配菜或料理材料。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cffb"), // 韩餐
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bffa"), // 发酵
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Hard, // 难
                    60, // 准备时间
                    0, // 烹饪时间（需要发酵时间）
                    6, // 6人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 葱油饼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba31"),
                    "葱油饼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/scallion-pancake.jpg",
                    "葱油饼是中国传统面食，外脆内软，葱香四溢，是受欢迎的早餐或小吃。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff7"), // 煎
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 烤鱼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba32"),
                    "烤鱼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/grilled-fish.jpg",
                    "烤鱼是一道美味的烧烤类菜肴，鱼肉嫩滑，外皮酥脆，香辣可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff6"), // 烤
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff8"), // 麻辣
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    35, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 木须肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba33"),
                    "木须肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/muxu-pork.jpg",
                    "木须肉是一道传统的家常菜，猪肉、鸡蛋、木耳、黄花菜等配料丰富，营养均衡。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜
                    DifficultyLevel.Easy, // 简单
                    15, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 佛跳墙
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba34"),
                    "佛跳墙",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/buddha-jump-wall.jpg",
                    "佛跳墙是福建闽菜的代表菜之一，由多种山珍海味炖制而成，香气扑鼻，味道鲜美。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff7"), // 闽菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff4"), // 炖
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 鲜
                    DifficultyLevel.Hard, // 难
                    120, // 准备时间
                    180, // 烹饪时间
                    6, // 6人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 辣子鸡
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba35"),
                    "辣子鸡",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/laziji.jpg",
                    "辣子鸡是四川传统名菜，鸡肉经油炸后与干辣椒一起爆炒，麻辣香脆。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff5"), // 炸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff8"), // 麻辣
                    DifficultyLevel.Medium, // 中等
                    30, // 准备时间
                    25, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 蛋炒饭
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba36"),
                    "蛋炒饭",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/egg-fried-rice.jpg",
                    "蛋炒饭是一道简单美味的家常饭，米饭粒粒分明，鸡蛋香滑，营养美味。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Easy, // 简单
                    5, // 准备时间
                    10, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 拍黄瓜
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba37"),
                    "拍黄瓜",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/smashed-cucumber.jpg",
                    "拍黄瓜是一道清爽开胃的凉菜，黄瓜脆嫩，调味鲜美，制作简单。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff9"), // 凉菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Easy, // 简单
                    10, // 准备时间
                    0, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 清蒸螃蟹
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba38"),
                    "清蒸螃蟹",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/steamed-crab.jpg",
                    "清蒸螃蟹是一道鲜美的海鲜料理，保留了螃蟹的原汁原味，肉质鲜嫩。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff2"), // 蒸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    20, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 烤羊肉串
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba39"),
                    "烤羊肉串",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/lamb-skewers.jpg",
                    "烤羊肉串是新疆特色美食，羊肉鲜嫩多汁，孜然香气四溢，风味独特。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff9"), // 西餐
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff6"), // 烤
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣味
                    DifficultyLevel.Easy, // 简单
                    20, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 凉拌豆腐
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba40"),
                    "凉拌豆腐",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/cold-tofu.jpg",
                    "凉拌豆腐是一道简单美味的凉菜，豆腐嫩滑，调味鲜香，清爽开胃。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    null, // 凉菜(暂无此选项，设为null)
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣味
                    DifficultyLevel.Easy, // 简单
                    10, // 准备时间
                    5, // 烹饪时间
                    2, // 2人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 酱爆鸭肠
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba41"),
                    "酱爆鸭肠",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/duck-intestine.jpg",
                    "酱爆鸭肠是一道特色川菜，鸭肠脆嫩，口感独特，酱香浓郁。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 三杯鸡
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba42"),
                    "三杯鸡",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/three-cup-chicken.jpg",
                    "三杯鸡是台湾特色菜，以一杯酱油、一杯米酒、一杯麻油焖炖而成，鸡肉香嫩入味。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff7"), // 闽菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 焖
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 白切鸡
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba43"),
                    "白切鸡",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/white-cut-chicken.jpg",
                    "白切鸡是广东名菜，整鸡煮熟后切块食用，肉质鲜嫩，皮滑肉香。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    45, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 酸菜鱼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba44"),
                    "酸菜鱼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/sour-soup-fish.jpg",
                    "酸菜鱼是四川名菜，以鲜嫩的鱼片和酸爽的泡菜为主料，酸辣可口，汤鲜味美。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff1"), // 川菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff9"), // 酸辣
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 炒河粉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba45"),
                    "炒河粉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/fried-rice-noodles.jpg",
                    "炒河粉是广东传统名菜，河粉滑爽，配料丰富，鲜香可口。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff1"), // 炒
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff7"), // 咸鲜
                    DifficultyLevel.Medium, // 中等
                    15, // 准备时间
                    15, // 烹饪时间
                    3, // 3人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 北京烤鸭
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba46"),
                    "北京烤鸭",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/peking-duck.jpg",
                    "北京烤鸭是中国传统名菜，皮酥肉嫩，色泽红亮，香气四溢。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff3"), // 鲁菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff6"), // 烤
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Hard, // 难
                    60, // 准备时间
                    90, // 烹饪时间
                    6, // 6人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 莲藕排骨汤
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba47"),
                    "莲藕排骨汤",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/lotus-rib-soup.jpg",
                    "莲藕排骨汤是一道滋补汤品，排骨鲜香，莲藕甘甜，汤汁清澈，营养丰富。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff3"), // 煮
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affb"), // 清淡
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    90, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 剁椒鱼头
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba48"),
                    "剁椒鱼头",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/chili-fish-head.jpg",
                    "剁椒鱼头是湖南名菜，以鱼头和剁椒为主料，蒸制而成，鲜辣可口。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff8"), // 湘菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff2"), // 蒸
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aff5"), // 辣
                    DifficultyLevel.Medium, // 中等
                    25, // 准备时间
                    25, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 梅菜扣肉
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba49"),
                    "梅菜扣肉",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/mei-cai-kou-rou.jpg",
                    "梅菜扣肉是客家传统名菜，肥肉软烂，梅菜咸香，肥而不腻，味道浓郁。",
                     Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff2"), // 粤菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 烧
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Hard, // 难
                    30, // 准备时间
                    120, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                ),
                
                // 红烧鱼
                new Recipe(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba50"),
                    "红烧鱼",
                    "https://fitbites-images.oss-cn-beijing.aliyuncs.com/recipes/braised-fish.jpg",
                    "红烧鱼是一道家常菜，鱼肉鲜嫩，汤汁浓郁，色泽红亮，营养丰富。",
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66cff4"), // 苏菜
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bff8"), // 烧
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66affc"), // 甜咸
                    DifficultyLevel.Medium, // 中等
                    20, // 准备时间
                    30, // 烹饪时间
                    4, // 4人份
                    true, // 推荐
                    true, // 启用
                    RecipeSource.System,
                    null,
                    _seedTime,
                    _seedTime
                )
            );
        }
        
        /// <summary>
        /// 种子数据：菜式食材
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedRecipeIngredients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasData(
                // 鸡丝炒木耳的食材
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb01"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa01"), // 鸡胸肉ID
                    "主料", // 角色类型
                    "切丝", // 加工方式
                    "先炒", // 使用方式
                    "200g", // 用量
                    1, // 添加顺序
                    null, // 加工完成后图片
                    true, // 关键食材
                    "鸡胸肉要切成细丝，更容易入味且口感好", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb02"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa08"), // 木耳ID
                    "主料", // 角色类型
                    "泡发,撕小块", // 加工方式
                    "后炒", // 使用方式
                    "100g", // 用量
                    2, // 添加顺序
                    null, // 加工完成后图片
                    true, // 关键食材
                    "木耳要提前泡发，去除硬根", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb03"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa03"), // 青椒ID
                    "辅料", // 角色类型
                    "切丝", // 加工方式
                    "最后炒", // 使用方式
                    "1个", // 用量
                    3, // 添加顺序
                    null, // 加工完成后图片
                    false, // 关键食材
                    "青椒提香增色，可以根据个人喜好增减", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb04"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa04"), // 姜ID
                    "调料", // 角色类型
                    "切末", // 加工方式
                    "爆香", // 使用方式
                    "适量", // 用量
                    0, // 添加顺序
                    null, // 加工完成后图片
                    false, // 关键食材
                    "姜末用于去腥提香", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb05"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa06"), // 酱油ID
                    "调料", // 角色类型
                    "原样", // 加工方式
                    "调味", // 使用方式
                    "1勺", // 用量
                    4, // 添加顺序
                    null, // 加工完成后图片
                    false, // 关键食材
                    "提鲜上色", // 备注
                    _seedTime,
                    _seedTime
                ),
                
                // 麻婆豆腐的食材
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb06"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa02"), // 豆腐ID
                    "主料", // 角色类型
                    "切块", // 加工方式
                    "煮", // 使用方式
                    "500g", // 用量
                    1, // 添加顺序
                    null, // 加工完成后图片
                    true, // 关键食材
                    "选用嫩豆腐，口感更好", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb07"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa05"), // 蒜ID
                    "调料", // 角色类型
                    "切末", // 加工方式
                    "爆香", // 使用方式
                    "适量", // 用量
                    0, // 添加顺序
                    null, // 加工完成后图片
                    false, // 关键食材
                    "蒜末增香提味", // 备注
                    _seedTime,
                    _seedTime
                ),
                new RecipeIngredient(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bb08"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66aa07"), // 盐ID
                    "调料", // 角色类型
                    "原样", // 加工方式
                    "调味", // 使用方式
                    "少许", // 用量
                    3, // 添加顺序
                    null, // 加工完成后图片
                    false, // 关键食材
                    "根据个人口味添加", // 备注
                    _seedTime,
                    _seedTime
                )
            );
        }
        
        /// <summary>
        /// 种子数据：菜式烹饪步骤
        /// </summary>
        /// <param name="modelBuilder">模型构建器</param>
        private static void SeedRecipeCookingSteps(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCookingStep>().HasData(
                // 鸡丝炒木耳的烹饪步骤
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc01"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    1, // 步骤序号
                    "准备食材", // 标题
                    "鸡胸肉切成细丝，木耳泡发后撕成小块，青椒切丝，姜切末。", // 描述
                    null, // 图片
                    null, // 视频
                    "[1,2,3,4]", // 使用食材ID列表
                    "切配", // 操作类型
                    300, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "注意鸡胸肉要顺着纹理切丝，更嫩滑。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc02"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    2, // 步骤序号
                    "鸡肉入味", // 标题
                    "鸡胸肉加入少许盐、料酒和淀粉抓匀，腌制5分钟。", // 描述
                    null, // 图片
                    null, // 视频
                    "[1]", // 使用食材ID列表
                    "腌制", // 操作类型
                    60, // 操作时长(秒)
                    "室温", // 温度提示
                    300, // 等待时间(秒)
                    false, // 是否可选
                    "这一步可以让鸡肉更加鲜嫩多汁。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc03"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    3, // 步骤序号
                    "爆香姜末", // 标题
                    "锅中倒油烧热，加入姜末爆香。", // 描述
                    null, // 图片
                    null, // 视频
                    "[4]", // 使用食材ID列表
                    "爆香", // 操作类型
                    30, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "油温七成热时下姜末，香气更浓郁。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc04"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    4, // 步骤序号
                    "炒鸡丝", // 标题
                    "放入腌制好的鸡丝，快速翻炒至变色。", // 描述
                    null, // 图片
                    null, // 视频
                    "[1]", // 使用食材ID列表
                    "翻炒", // 操作类型
                    90, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "鸡丝变色即可，不要过度炒制以免老柴。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc05"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    5, // 步骤序号
                    "加入木耳", // 标题
                    "放入泡发好的木耳，翻炒均匀。", // 描述
                    null, // 图片
                    null, // 视频
                    "[2]", // 使用食材ID列表
                    "翻炒", // 操作类型
                    120, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "木耳炒至有光泽即可，不要过久，保持脆嫩口感。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc06"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    6, // 步骤序号
                    "加入青椒", // 标题
                    "放入青椒丝，快速翻炒均匀。", // 描述
                    null, // 图片
                    null, // 视频
                    "[3]", // 使用食材ID列表
                    "翻炒", // 操作类型
                    60, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "青椒炒至断生即可，保持色泽翠绿。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc07"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    7, // 步骤序号
                    "调味", // 标题
                    "加入酱油和少许盐，翻炒均匀。", // 描述
                    null, // 图片
                    null, // 视频
                    "[5]", // 使用食材ID列表
                    "调味", // 操作类型
                    30, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "根据个人口味调整咸淡，木耳本身有味道，注意少放盐。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc08"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba01"), // 鸡丝炒木耳ID
                    8, // 步骤序号
                    "出锅", // 标题
                    "装盘即可食用。", // 描述
                    null, // 图片
                    null, // 视频
                    "[]", // 使用食材ID列表
                    "装盘", // 操作类型
                    30, // 操作时长(秒)
                    null, // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "可以撒上少许香葱提香增色。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                
                // 麻婆豆腐的烹饪步骤
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc09"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    1, // 步骤序号
                    "准备食材", // 标题
                    "豆腐切成小方块，蒜切末。", // 描述
                    null, // 图片
                    null, // 视频
                    "[6,7]", // 使用食材ID列表
                    "切配", // 操作类型
                    300, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "豆腐切成约2厘米见方的小块，方便入味。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                
                // 清蒸鱼的烹饪步骤
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc20"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    1, // 步骤序号
                    "鱼的处理", // 标题
                    "将鱼清洗干净，去除内脏和鳞片，在鱼身两侧划几刀，便于入味。", // 描述
                    null, // 图片
                    null, // 视频
                    "[14]", // 使用食材ID列表 - 鱼肉
                    "清洗处理", // 操作类型
                    300, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "刀口不要太深，以免破坏鱼的整体性。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc21"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    2, // 步骤序号
                    "腌制鱼", // 标题
                    "将鱼均匀抹上盐和料酒，腌制10分钟去腥增鲜。", // 描述
                    null, // 图片
                    null, // 视频
                    "[14,7]", // 使用食材ID列表 - 鱼肉、盐
                    "腌制", // 操作类型
                    60, // 操作时长(秒)
                    "室温", // 温度提示
                    600, // 等待时间(秒)
                    false, // 是否可选
                    "料酒可以有效去除鱼的腥味，使鱼肉更加鲜美。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc22"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    3, // 步骤序号
                    "准备配料", // 标题
                    "姜切丝，葱切段，部分葱切成葱花。", // 描述
                    null, // 图片
                    null, // 视频
                    "[4,24]", // 使用食材ID列表 - 姜、葱
                    "切配", // 操作类型
                    180, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "姜丝最好切细一些，葱段和葱花分开备用。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc23"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    4, // 步骤序号
                    "摆盘准备", // 标题
                    "将鱼放在蒸盘上，鱼身上铺上姜丝和一半的葱段。", // 描述
                    null, // 图片
                    null, // 视频
                    "[14,4,24]", // 使用食材ID列表 - 鱼肉、姜、葱
                    "摆盘", // 操作类型
                    120, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "姜丝和葱段均匀分布在鱼身上，有助于去腥增香。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc24"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    5, // 步骤序号
                    "蒸鱼", // 标题
                    "将鱼放入蒸锅中，水烧开后蒸8-10分钟。", // 描述
                    null, // 图片
                    null, // 视频
                    "[14]", // 使用食材ID列表 - 鱼肉
                    "蒸", // 操作类型
                    600, // 操作时长(秒)
                    "高温蒸汽", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "蒸鱼时间不宜过长，以免鱼肉老化失去鲜嫩口感。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc25"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    6, // 步骤序号
                    "制作调味汁", // 标题
                    "锅中倒入少许油烧热，加入酱油和少许白糖调味。", // 描述
                    null, // 图片
                    null, // 视频
                    "[6]", // 使用食材ID列表 - 酱油
                    "调味", // 操作类型
                    60, // 操作时长(秒)
                    "中火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "油温不要太高，防止酱油糊化。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc26"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba03"), // 清蒸鱼ID
                    7, // 步骤序号
                    "最终处理", // 标题
                    "鱼蒸好后，去除姜丝和葱段，撒上葱花，浇上热油和调味汁。", // 描述
                    null, // 图片
                    null, // 视频
                    "[14,24,6]", // 使用食材ID列表 - 鱼肉、葱、酱油
                    "浇汁", // 操作类型
                    60, // 操作时长(秒)
                    "热油", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "热油浇在葱花上可以激发出葱的香气，增添菜品风味。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                
                // 红烧牛肉的烹饪步骤
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc30"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    1, // 步骤序号
                    "准备食材", // 标题
                    "牛肉切成2-3厘米的方块，姜切片，蒜切末，葱切段。", // 描述
                    null, // 图片
                    null, // 视频
                    "[9,4,5,24]", // 使用食材ID列表 - 牛肉、姜、蒜、葱
                    "切配", // 操作类型
                    300, // 操作时长(秒)
                    "室温", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "牛肉要切成大小均匀的块，便于均匀入味和烹饪。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc31"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    2, // 步骤序号
                    "焯水", // 标题
                    "锅中加水烧开，放入牛肉块焯水3分钟，去除血水和杂质。", // 描述
                    null, // 图片
                    null, // 视频
                    "[9]", // 使用食材ID列表 - 牛肉
                    "焯水", // 操作类型
                    180, // 操作时长(秒)
                    "沸水", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "焯水可以去除牛肉中的血水和异味，使最终成菜更加鲜美。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc32"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    3, // 步骤序号
                    "爆香料头", // 标题
                    "锅中倒油烧热，放入姜片、蒜末、葱段爆香。", // 描述
                    null, // 图片
                    null, // 视频
                    "[4,5,24]", // 使用食材ID列表 - 姜、蒜、葱
                    "爆香", // 操作类型
                    90, // 操作时长(秒)
                    "中火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "爆香料头是红烧菜品的关键步骤，可以激发出香料的风味。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc33"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    4, // 步骤序号
                    "煸炒牛肉", // 标题
                    "放入焯好水的牛肉块，翻炒至表面微微变色。", // 描述
                    null, // 图片
                    null, // 视频
                    "[9]", // 使用食材ID列表 - 牛肉
                    "煸炒", // 操作类型
                    180, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "煸炒牛肉可以封住肉汁，使牛肉更加鲜嫩。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc34"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    5, // 步骤序号
                    "加入调料", // 标题
                    "加入酱油、白糖、料酒和适量清水，没过牛肉。", // 描述
                    null, // 图片
                    null, // 视频
                    "[6]", // 使用食材ID列表 - 酱油
                    "调味", // 操作类型
                    60, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "酱油提供咸味和色泽，白糖可以中和酱油的咸味并增加光泽。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc35"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    6, // 步骤序号
                    "炖煮", // 标题
                    "大火烧开后转小火，盖上锅盖慢炖1.5-2小时，直至牛肉酥烂。", // 描述
                    null, // 图片
                    null, // 视频
                    "[9]", // 使用食材ID列表 - 牛肉
                    "炖煮", // 操作类型
                    7200, // 操作时长(秒)
                    "小火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "耐心炖煮是红烧牛肉的关键，时间足够长才能使牛肉变得酥烂入味。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc36"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba05"), // 红烧牛肉ID
                    7, // 步骤序号
                    "收汁", // 标题
                    "牛肉炖烂后，开大火收汁至浓稠。", // 描述
                    null, // 图片
                    null, // 视频
                    "[9]", // 使用食材ID列表 - 牛肉
                    "收汁", // 操作类型
                    300, // 操作时长(秒)
                    "大火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "收汁时要注意控制火候，避免炒糊。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc10"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    2, // 步骤序号
                    "焯水豆腐", // 标题
                    "锅中加水烧开，放入豆腐焯水30秒，捞出沥干水分。", // 描述
                    null, // 图片
                    null, // 视频
                    "[6]", // 使用食材ID列表
                    "焯水", // 操作类型
                    60, // 操作时长(秒)
                    "沸水", // 温度提示
                    null, // 等待时间
                    true, // 是否可选
                    "焯水可以去除豆腐的生腥味，使豆腐更容易吸收调料的味道。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc11"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    3, // 步骤序号
                    "炒香调料", // 标题
                    "锅中倒油烧热，加入蒜末爆香。", // 描述
                    null, // 图片
                    null, // 视频
                    "[7]", // 使用食材ID列表
                    "爆香", // 操作类型
                    60, // 操作时长(秒)
                    "中火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "油温不要太高，避免蒜末炒糊。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc12"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    4, // 步骤序号
                    "炒豆瓣酱", // 标题
                    "加入豆瓣酱炒出红油。", // 描述
                    null, // 图片
                    null, // 视频
                    "[]", // 使用食材ID列表
                    "炒制", // 操作类型
                    90, // 操作时长(秒)
                    "小火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "慢火炒豆瓣酱，让香味充分释放出来。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc13"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    5, // 步骤序号
                    "加入豆腐", // 标题
                    "倒入适量清水，然后放入豆腐块，小心翻动均匀。", // 描述
                    null, // 图片
                    null, // 视频
                    "[6]", // 使用食材ID列表
                    "焖煮", // 操作类型
                    180, // 操作时长(秒)
                    "中小火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "动作要轻，避免把豆腐弄碎。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc14"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    6, // 步骤序号
                    "勾芡调味", // 标题
                    "加入少许盐调味，用水淀粉勾芡。", // 描述
                    null, // 图片
                    null, // 视频
                    "[8]", // 使用食材ID列表
                    "勾芡", // 操作类型
                    60, // 操作时长(秒)
                    "小火", // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "水淀粉要边倒边搅拌，避免结块。", // AI教学提示
                    _seedTime,
                    _seedTime
                ),
                new RecipeCookingStep(
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66bc15"),
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66ba02"), // 麻婆豆腐ID
                    7, // 步骤序号
                    "出锅装盘", // 标题
                    "撒上花椒粉和葱花，装盘即可。", // 描述
                    null, // 图片
                    null, // 视频
                    "[]", // 使用食材ID列表
                    "装盘", // 操作类型
                    30, // 操作时长(秒)
                    null, // 温度提示
                    null, // 等待时间
                    false, // 是否可选
                    "花椒粉增添麻味，是麻婆豆腐的灵魂。", // AI教学提示
                    _seedTime,
                    _seedTime
                )
            );
        }
    }
}