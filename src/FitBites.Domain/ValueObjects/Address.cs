using System;

namespace FitBites.Domain.ValueObjects
{
    /// <summary>
    /// 地址值对象
    /// </summary>
    public class Address : IEquatable<Address>
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string District { get; private set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private Address() { }

        /// <summary>
        /// 创建地址
        /// </summary>
        public static Address Create(string province, string city, string district, string street, string zipCode = null)
        {
            if (string.IsNullOrWhiteSpace(province))
                throw new ArgumentException("省份不能为空", nameof(province));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("城市不能为空", nameof(city));

            if (string.IsNullOrWhiteSpace(district))
                throw new ArgumentException("区县不能为空", nameof(district));

            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("详细地址不能为空", nameof(street));

            return new Address
            {
                Province = province,
                City = city,
                District = district,
                Street = street,
                ZipCode = zipCode
            };
        }

        /// <summary>
        /// 获取完整地址字符串
        /// </summary>
        public string GetFullAddress()
        {
            return $"{Province}{City}{District}{Street}";
        }

        /// <summary>
        /// 判断值对象相等
        /// </summary>
        public bool Equals(Address other)
        {
            if (other == null)
                return false;

            return Province == other.Province
                && City == other.City
                && District == other.District
                && Street == other.Street
                && ZipCode == other.ZipCode;
        }

        /// <summary>
        /// 重写对象相等判断
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Address address)
                return Equals(address);

            return false;
        }

        /// <summary>
        /// 重写获取哈希码
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Province, City, District, Street, ZipCode);
        }

        /// <summary>
        /// 实现相等运算符
        /// </summary>
        public static bool operator ==(Address left, Address right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        /// <summary>
        /// 实现不等运算符
        /// </summary>
        public static bool operator !=(Address left, Address right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 转换为字符串表示
        /// </summary>
        public override string ToString()
        {
            return GetFullAddress();
        }
    }
} 