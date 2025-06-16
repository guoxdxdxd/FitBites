using FitBites.Application.DTOs.Ingredient;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 营养成分字典应用服务实现
    /// </summary>
    public class IngredientNutritionDictService : IIngredientNutritionDictService
    {
        private readonly IIngredientNutritionDictRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数
        /// </summary>
        public IngredientNutritionDictService(
            IIngredientNutritionDictRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有营养成分字典
        /// </summary>
        public async Task<List<IngredientNutritionDictDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 根据ID获取营养成分字典
        /// </summary>
        public async Task<IngredientNutritionDictDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDto(entity);
        }

        /// <summary>
        /// 创建营养成分字典
        /// </summary>
        public async Task<IngredientNutritionDictDto> CreateAsync(CreateIngredientNutritionDictDto dto)
        {
            if (await _repository.ExistsByNameAsync(dto.Name))
                throw new ApplicationException($"营养成分名称 '{dto.Name}' 已存在");
            var entity = IngredientNutritionDict.Create(dto.Name, dto.Unit, dto.Description);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        /// <summary>
        /// 更新营养成分字典
        /// </summary>
        public async Task<IngredientNutritionDictDto> UpdateAsync(Guid id, UpdateIngredientNutritionDictDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new ApplicationException($"ID为 '{id}' 的营养成分不存在");
            if (await _repository.ExistsByNameAsync(dto.Name, id))
                throw new ApplicationException($"营养成分名称 '{dto.Name}' 已存在");
            entity.Update(dto.Name, dto.Unit, dto.Description);
            await _repository.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        /// <summary>
        /// 删除营养成分字典
        /// </summary>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new ApplicationException($"ID为 '{id}' 的营养成分不存在");
            // 可扩展：检查是否被引用
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 实体转DTO
        /// </summary>
        private static IngredientNutritionDictDto ToDto(IngredientNutritionDict entity)
        {
            return new IngredientNutritionDictDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Unit = entity.Unit,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
} 