using System;

namespace FitBites.Application.DTOs
{
    /// <summary>
    /// 餐次字典DTO
    /// </summary>
    public class MealTimeDictDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// 创建餐次字典DTO
    /// </summary>
    public class CreateMealTimeDictDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// 更新餐次字典DTO
    /// </summary>
    public class UpdateMealTimeDictDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
} 