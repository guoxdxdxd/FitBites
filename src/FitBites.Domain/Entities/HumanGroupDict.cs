using FitBites.Domain.Entities.Base;
using FitBites.Domain.Events;

namespace FitBites.Domain.Entities
{
    /// <summary>
    /// 人群标签字典实体
    /// </summary>
    public class HumanGroupDict : AggregateRoot
    {
        /// <summary>
        /// 构造函数，初始化集合
        /// </summary>
        public HumanGroupDict()
        {
            UserHumanGroups = new HashSet<UserHumanGroup>();
            IngredientHumanGroups = new HashSet<IngredientHumanGroup>();
        }

        /// <summary>
        /// 种子数据构造函数
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">标签名称</param>
        /// <param name="description">描述说明</param>
        /// <param name="createdAt">创建时间</param>
        /// <param name="updatedAt">更新时间</param>
        public HumanGroupDict(Guid id, string name, string description, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            UserHumanGroups = new HashSet<UserHumanGroup>();
            IngredientHumanGroups = new HashSet<IngredientHumanGroup>();
        }

        /// <summary>
        /// 标签（如：孕妇、糖尿病人）
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 用户人群标签集合
        /// </summary>
        public virtual ICollection<UserHumanGroup> UserHumanGroups { get; private set; }

        /// <summary>
        /// 食材人群集合
        /// </summary>
        public virtual ICollection<IngredientHumanGroup> IngredientHumanGroups { get; private set; }

        /// <summary>
        /// 创建一个新的人群标签
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <param name="description">描述说明</param>
        /// <returns>新创建的人群标签</returns>
        public static HumanGroupDict Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("人群标签名称不能为空", nameof(name));

            var instance = new HumanGroupDict
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            
            // 添加领域事件
            instance.AddDomainEvent(new HumanGroupChangedEvent(instance.Id));
            
            return instance;
        }

        /// <summary>
        /// 更新人群标签信息
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <param name="description">描述说明</param>
        public void Update(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("人群标签名称不能为空", nameof(name));

            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
            
            // 添加领域事件
            AddDomainEvent(new HumanGroupChangedEvent(Id));
        }
    }
} 