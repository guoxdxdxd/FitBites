using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FitBites.Core.Enums;
using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 用户聚合根
    /// </summary>
    public partial class User : AggregateRoot
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserPreferences = new HashSet<UserPreference>();
            UserHumanGroups = new HashSet<UserHumanGroup>();
            OwnedFamilies = new HashSet<Family>();
            FamilyMemberships = new HashSet<FamilyMember>();
            MealPlanOrders = new HashSet<MealPlanOrder>();
            PersonalMealPlans = new HashSet<WeeklyMealPlan>();
            CreatedMealPlans = new HashSet<WeeklyMealPlan>();
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        public User(string username, string phone, UserStatus status)
        {
            Id = Guid.NewGuid();
            UserCode = GenerateUserCode();
            Username = username;
            Phone = phone;
            Nickname = GenerateRandomNickname();
            Avatar = string.Empty;
            Status = status;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            
            UserRoles = new HashSet<UserRole>();
            UserPreferences = new HashSet<UserPreference>();
            UserHumanGroups = new HashSet<UserHumanGroup>();
            OwnedFamilies = new HashSet<Family>();
            FamilyMemberships = new HashSet<FamilyMember>();
            MealPlanOrders = new HashSet<MealPlanOrder>();
            PersonalMealPlans = new HashSet<WeeklyMealPlan>();
            CreatedMealPlans = new HashSet<WeeklyMealPlan>();
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="userCode">用户编码</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="phone">手机号</param>
        /// <param name="nickname">昵称</param>
        /// <param name="avatar">头像</param>
        /// <param name="status">状态</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public User(Guid id, string userCode, string username, string password, string phone, 
            string nickname, string avatar, UserStatus status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            UserCode = userCode;
            Username = username;
            Password = password;
            Phone = phone;
            Nickname = nickname;
            Avatar = avatar;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            
            // 初始化集合
            UserRoles = new HashSet<UserRole>();
            UserPreferences = new HashSet<UserPreference>();
            UserHumanGroups = new HashSet<UserHumanGroup>();
            OwnedFamilies = new HashSet<Family>();
            FamilyMemberships = new HashSet<FamilyMember>();
            MealPlanOrders = new HashSet<MealPlanOrder>();
            PersonalMealPlans = new HashSet<WeeklyMealPlan>();
            CreatedMealPlans = new HashSet<WeeklyMealPlan>();
            PermissionMappings = new HashSet<PermissionMapping>();
        }

        /// <summary>
        /// 用户编码，唯一
        /// </summary>
        public string UserCode { get; private set; }

        /// <summary>
        /// 用户登录名
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// 用户密码（加密存储）
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; private set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; private set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// 用户状态（启用/禁用）
        /// </summary>
        public UserStatus Status { get; private set; }
        
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string? RefreshToken { get; private set; }
        
        /// <summary>
        /// 刷新令牌过期时间
        /// </summary>
        public DateTime? RefreshTokenExpireTime { get; private set; }

        // 导航属性
        /// <summary>
        /// 用户角色关系集合
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; private set; }

        /// <summary>
        /// 用户偏好集合
        /// </summary>
        public virtual ICollection<UserPreference> UserPreferences { get; private set; }

        /// <summary>
        /// 用户人群标签集合
        /// </summary>
        public virtual ICollection<UserHumanGroup> UserHumanGroups { get; private set; }

        /// <summary>
        /// 拥有的家庭集合
        /// </summary>
        public virtual ICollection<Family> OwnedFamilies { get; private set; }

        /// <summary>
        /// 加入的家庭成员关系集合
        /// </summary>
        public virtual ICollection<FamilyMember> FamilyMemberships { get; private set; }

        /// <summary>
        /// 点菜记录集合
        /// </summary>
        public virtual ICollection<MealPlanOrder> MealPlanOrders { get; private set; }

        /// <summary>
        /// 个人菜谱集合
        /// </summary>
        public virtual ICollection<WeeklyMealPlan> PersonalMealPlans { get; private set; }

        /// <summary>
        /// 创建的菜谱集合
        /// </summary>
        public virtual ICollection<WeeklyMealPlan> CreatedMealPlans { get; private set; }

        /// <summary>
        /// 用户直接关联的权限映射集合
        /// </summary>
        public virtual ICollection<PermissionMapping> PermissionMappings { get; private set; }



        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="nickname">昵称</param>
        /// <param name="avatar">头像</param>
        public void UpdateBasicInfo(string nickname, string avatar)
        {
            Nickname = nickname;
            Avatar = avatar;
            UpdatedAt = DateTime.Now;
        }



        /// <summary>
        /// 创建用户并触发用户创建事件
        /// </summary>
        public void Create()
        {
            AddDomainEvent(new UserCreatedEvent(Id, Username, Phone));
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        public void Disable()
        {
            if (Status != UserStatus.Disabled)
            {
                Status = UserStatus.Disabled;
                UpdatedAt = DateTime.Now;
            }
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        public void Enable()
        {
            if (Status != UserStatus.Enabled)
            {
                Status = UserStatus.Enabled;
                UpdatedAt = DateTime.Now;
            }
        }

        /// <summary>
        /// 是否可以登录
        /// </summary>
        /// <returns>是否可以登录</returns>
        public bool CanLogin()
        {
            return Status == UserStatus.Enabled;
        }

        /// <summary>
        /// 加密密码（MD5）
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <returns>加密后的密码</returns>
        private static string EncryptPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }


        
        /// <summary>
        /// 生成随机用户编码
        /// </summary>
        /// <returns>用户编码</returns>
        private string GenerateUserCode()
        {
            var random = new Random();
            return $"U{DateTime.Now:yyyyMMdd}{random.Next(1000, 9999)}";
        }
        
        /// <summary>
        /// 生成随机昵称
        /// </summary>
        /// <returns>随机昵称</returns>
        private string GenerateRandomNickname()
        {
            var random = new Random();
            string[] prefixes = { "快乐的", "开心的", "阳光的", "健康的", "活力的", "美味的", "营养的" };
            string[] nouns = { "厨师", "美食家", "营养师", "吃货", "厨神", "美食达人", "健身达人" };
            
            var prefix = prefixes[random.Next(prefixes.Length)];
            var noun = nouns[random.Next(nouns.Length)];
            
            return $"{prefix}{noun}{random.Next(10, 100)}";
        }
        
    }
}