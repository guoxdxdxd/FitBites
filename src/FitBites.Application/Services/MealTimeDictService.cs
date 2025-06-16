using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;
using FitBites.Core.Interfaces;

namespace FitBites.Application.Services
{
    public class MealTimeDictService : IMealTimeDictService
    {
        private readonly IMealTimeDictRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MealTimeDictService(IMealTimeDictRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MealTimeDictDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : ToDto(entity);
        }

        public async Task<MealTimeDictDto> GetByCodeAsync(string code)
        {
            var entity = await _repository.GetByCodeAsync(code);
            return entity == null ? null : ToDto(entity);
        }

        public async Task<IEnumerable<MealTimeDictDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllActiveAsync();
            return entities.Select(ToDto);
        }

        public async Task<MealTimeDictDto> CreateAsync(CreateMealTimeDictDto dto)
        {
            // 可加唯一性校验
            var entity = new MealTimeDict(Guid.NewGuid(), dto.Code, dto.Name, dto.Description, DateTime.UtcNow, DateTime.UtcNow);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task<MealTimeDictDto> UpdateAsync(UpdateMealTimeDictDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) throw new Exception("餐次不存在");
            entity.Update(dto.Name, dto.Description);
            await _unitOfWork.SaveChangesAsync();
            return ToDto(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("餐次不存在");
            entity.Disable();
            await _unitOfWork.SaveChangesAsync();
        }

        private static MealTimeDictDto ToDto(MealTimeDict entity)
        {
            return new MealTimeDictDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description,
                IsDeleted = entity.IsDeleted,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
} 