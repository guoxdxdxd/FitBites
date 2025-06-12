using System;

namespace FitBites.Application.Dtos.Preference
{
    /// <summary>
    /// 偏好项目DTO
    /// </summary>
    public class PreferenceItemDto
    {
        public PreferenceItemDto(Guid id, string code, string name, string description)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }    
        
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
    }
}