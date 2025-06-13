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
    public class User : AggregateRoot
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
        /// 获取用户所有有效权限（包括直接权限和角色权限）
        /// 非数据库字段
        /// </summary>
        [NotMapped]
        public IEnumerable<Permission> AllPermissions
        {
            get
            {
                var now = DateTime.Now;
                var permissionSet = new HashSet<Permission>(new PermissionEqualityComparer());

                // 添加用户直接拥有的有效权限
                foreach (var mapping in PermissionMappings.Where(pm =>
                             pm.Status && (pm.ExpireTime == null || pm.ExpireTime > now)))
                {
                    permissionSet.Add(mapping.Permission);
                }

                // 添加用户通过角色获得的有效权限
                foreach (var userRole in UserRoles)
                {
                    if (userRole.Role?.PermissionMappings != null)
                    {
                        foreach (var mapping in userRole.Role.PermissionMappings.Where(pm =>
                                     pm.Status && (pm.ExpireTime == null || pm.ExpireTime > now)))
                        {
                            permissionSet.Add(mapping.Permission);
                        }
                    }
                }

                return permissionSet;
            }
        }


        public void AddPermissionMapping(PermissionMapping permissionMapping)
        {
            PermissionMappings.Add(permissionMapping);
            AddDomainEvent(new UserPermissionGrantedEvent(Id, permissionMapping.PermissionId, permissionMapping.ExpireTime));
        }


        /// <summary>
        /// 获取用户所有角色
        /// </summary>
        /// <returns>角色列表</returns>
        public List<Role> GetRoles()
        {
            return UserRoles.Select(ur => ur.Role).ToList();
        }

        /// <summary>
        /// 检查用户是否有指定权限
        /// </summary>
        /// <param name="permissionCode">权限代码</param>
        /// <returns>是否有权限</returns>
        public bool HasPermission(string permissionCode)
        {
            return AllPermissions.Any(p => p.PermissionCode == permissionCode);
        }

        /// <summary>
        /// 检查用户是否有指定角色
        /// </summary>
        /// <param name="roleCode">角色代码</param>
        /// <returns>是否有角色</returns>
        public bool HasRole(string roleCode)
        {
            return UserRoles.Any(ur => ur.Role?.RoleCode == roleCode);
        }

        /// <summary>
        /// 验证密码是否正确
        /// </summary>
        /// <param name="password">原始密码</param>
        /// <returns>验证结果</returns>
        public bool VerifyPassword(string password)
        {
            return Password == EncryptPassword(password);
        }

        public void Login()
        {
            AddDomainEvent(new UserLoggedInEvent(Id, Username));
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        public void ChangePassword(string newPassword)
        {
            Password = EncryptPassword(newPassword);
            UpdatedAt = DateTime.Now;
        }

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
        /// 添加角色
        /// </summary>
        /// <param name="role">角色</param>
        public void AddRole(Role role)
        {
            if (!UserRoles.Any(ur => ur.RoleId == role.Id))
            {
                UserRoles.Add(new UserRole(Id, role.Id));
                
                AddDomainEvent(new UserRoleAssignedEvent(Id, role.Id));
            }
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
        /// 生成新的刷新令牌
        /// </summary>
        /// <param name="expireTime">过期时间</param>
        public void GenerateRefreshToken(DateTime expireTime)
        {
            RefreshToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");
            RefreshTokenExpireTime = expireTime;
            UpdatedAt = DateTime.Now;
            
            AddDomainEvent(new UserRefreshTokenGeneratedEvent(Id, RefreshToken, RefreshTokenExpireTime));
        }
        
        /// <summary>
        /// 验证刷新令牌是否有效
        /// </summary>
        /// <param name="refreshToken">刷新令牌</param>
        /// <returns>是否有效</returns>
        public bool ValidateRefreshToken(string refreshToken)
        {
            return RefreshToken == refreshToken && 
                   RefreshTokenExpireTime.HasValue && 
                   RefreshTokenExpireTime.Value > DateTime.UtcNow;
        }
        
        /// <summary>
        /// 撤销刷新令牌
        /// </summary>
        public void RevokeRefreshToken()
        {
            RefreshToken = null;
            RefreshTokenExpireTime = null;
            UpdatedAt = DateTime.Now;
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
        
        /// <summary>
        /// 添加用户偏好
        /// </summary>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <param name="preferenceType">偏好类型</param>
        /// <param name="remark">备注</param>
        /// <returns>添加的用户偏好</returns>
        public UserPreference AddPreference(PreferenceTargetType targetType, Guid targetId, PreferenceType preferenceType, string remark = "")
        {
            // 检查是否已存在相同偏好
            var existingPreference = UserPreferences.FirstOrDefault(p => 
                p.TargetType == targetType && 
                p.TargetId == targetId && 
                p.PreferenceType == preferenceType);
                
            if (existingPreference != null)
            {
                return existingPreference; // 已存在相同偏好，直接返回
            }
            
            // 创建新的偏好对象
            var preference = new UserPreference(Id, targetType, targetId, preferenceType, remark);
            
            // 添加到用户的偏好集合中
            UserPreferences.Add(preference);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceAddedEvent(Id, preference.Id, targetType, targetId, preferenceType));
            
            return preference;
        }
        
        /// <summary>
        /// 更新用户偏好
        /// </summary>
        /// <param name="preferenceId">偏好ID</param>
        /// <param name="preferenceType">新的偏好类型</param>
        /// <param name="remark">新的备注</param>
        /// <returns>是否更新成功</returns>
        public bool UpdatePreference(Guid preferenceId, PreferenceType preferenceType, string remark)
        {
            // 查找指定ID的偏好
            var preference = UserPreferences.FirstOrDefault(p => p.Id == preferenceId);
            
            if (preference == null)
            {
                return false; // 偏好不存在，更新失败
            }
            
            // 更新偏好
            preference.Update(preferenceType, remark);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceUpdatedEvent(Id, preference.Id, preference.TargetType, preference.TargetId, preferenceType));
            
            return true;
        }
        
        /// <summary>
        /// 删除用户偏好
        /// </summary>
        /// <param name="preferenceId">偏好ID</param>
        /// <returns>是否删除成功</returns>
        public bool RemovePreference(Guid preferenceId)
        {
            // 查找指定ID的偏好
            var preference = UserPreferences.FirstOrDefault(p => p.Id == preferenceId);
            
            if (preference == null)
            {
                return false; // 偏好不存在，删除失败
            }
            
            // 从集合中移除
            UserPreferences.Remove(preference);
            
            // 触发领域事件
            AddDomainEvent(new UserPreferenceRemovedEvent(Id, preference.Id, preference.TargetType, preference.TargetId));
            
            return true;
        }
        
        /// <summary>
        /// 按类型和目标删除用户偏好
        /// </summary>
        /// <param name="targetType">偏好对象类型</param>
        /// <param name="targetId">偏好对象ID</param>
        /// <returns>是否删除成功</returns>
        public bool RemovePreferenceByTarget(PreferenceTargetType targetType, Guid targetId)
        {
            // 查找所有匹配的偏好
            var preferences = UserPreferences.Where(p => 
                p.TargetType == targetType && 
                p.TargetId == targetId).ToList();
                
            if (!preferences.Any())
            {
                return false; // 没有找到匹配的偏好，删除失败
            }
            
            // 从集合中移除所有匹配的偏好
            foreach (var preference in preferences)
            {
                UserPreferences.Remove(preference);
                
                // 触发领域事件
                AddDomainEvent(new UserPreferenceRemovedEvent(Id, preference.Id, targetType, targetId));
            }
            
            return true;
        }

        /// <summary>
        /// 添加人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">来源</param>
        /// <param name="confidence">置信度</param>
        /// <returns>添加的用户人群标签</returns>
        public UserHumanGroup AddHumanGroup(Guid groupId, HumanGroupSource source, decimal? confidence = null)
        {
            // 检查是否已存在相同标签
            var existingGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
                
            if (existingGroup != null)
            {
                return existingGroup; // 已存在相同标签，直接返回
            }
            
            // 创建新的人群标签映射
            var userHumanGroup = new UserHumanGroup(Id, groupId, source, confidence);
            
            // 添加到用户的人群标签集合中
            UserHumanGroups.Add(userHumanGroup);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupAddedEvent(Id, groupId, source));
            
            return userHumanGroup;
        }
        
        /// <summary>
        /// 移除人群标签
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否移除成功</returns>
        public bool RemoveHumanGroup(Guid groupId)
        {
            // 查找指定标签ID的映射
            var userHumanGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
            
            if (userHumanGroup == null)
            {
                return false; // 标签不存在，移除失败
            }
            
            // 从集合中移除
            UserHumanGroups.Remove(userHumanGroup);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupRemovedEvent(Id, groupId));
            
            return true;
        }
        
        /// <summary>
        /// 更新人群标签信息
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <param name="source">新的来源</param>
        /// <param name="confidence">新的置信度</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateHumanGroup(Guid groupId, HumanGroupSource source, decimal? confidence)
        {
            // 查找指定标签ID的映射
            var userHumanGroup = UserHumanGroups.FirstOrDefault(g => g.GroupId == groupId);
            
            if (userHumanGroup == null)
            {
                return false; // 标签不存在，更新失败
            }
            
            // 更新人群标签信息
            userHumanGroup.Update(source, confidence);
            
            // 触发领域事件
            AddDomainEvent(new UserHumanGroupUpdatedEvent(Id, groupId, source, confidence));
            
            return true;
        }
        
        /// <summary>
        /// 检查用户是否属于指定人群
        /// </summary>
        /// <param name="groupId">人群标签ID</param>
        /// <returns>是否属于该人群</returns>
        public bool BelongsToHumanGroup(Guid groupId)
        {
            return UserHumanGroups.Any(g => g.GroupId == groupId);
        }
        
        /// <summary>
        /// 获取用户所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        public List<HumanGroupDict> GetHumanGroups()
        {
            return UserHumanGroups.Select(g => g.HumanGroup).ToList();
        }
    }
}