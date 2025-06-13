using System;
using FitBites.Core.Enums;
using FitBites.Domain.Entities;

namespace FitBites.Application.Dtos
{
    /// <summary>
    /// 用户人群标签DTO
    /// </summary>
    public class UserHumanGroupDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// 人群标签名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 人群标签描述
        /// </summary>
        public string GroupDescription { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource? Source { get; set; }

        /// <summary>
        /// 来源名称
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 置信度
        /// </summary>
        public decimal? Confidence { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserHumanGroupDto()
        {
        }

        /// <summary>
        /// 从实体创建DTO
        /// </summary>
        /// <param name="entity">用户人群标签实体</param>
        public UserHumanGroupDto(UserHumanGroup entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            UserId = entity.UserId;
            GroupId = entity.GroupId;
            GroupName = entity.HumanGroup?.Name;
            GroupDescription = entity.HumanGroup?.Description;
            Source = entity.Source;
            SourceName = entity.Source.HasValue ? entity.Source.Value.ToString() : null;
            Confidence = entity.Confidence;
            CreatedAt = entity.CreatedAt;
        }
    }

    /// <summary>
    /// 添加用户人群标签请求DTO
    /// </summary>
    public class AddUserHumanGroupDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource Source { get; set; }

        /// <summary>
        /// 置信度
        /// </summary>
        public decimal? Confidence { get; set; }
    }

    /// <summary>
    /// 更新用户人群标签请求DTO
    /// </summary>
    public class UpdateUserHumanGroupDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 人群标签ID
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public HumanGroupSource Source { get; set; }

        /// <summary>
        /// 置信度
        /// </summary>
        public decimal? Confidence { get; set; }
    }
} 