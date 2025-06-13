using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Ingredient;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Enums;
using FitBites.Core.Interfaces;
using FitBites.Core.Utils;
using FitBites.Domain.Entities;
using FitBites.Domain.IRepositories;

namespace FitBites.Application.Services
{
    /// <summary>
    /// 食材应用服务实现
    /// </summary>
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ingredientRepository">食材仓储</param>
        /// <param name="unitOfWork">工作单元</param>
        public IngredientService(
            IIngredientRepository ingredientRepository,
            IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 获取所有食材类别
        /// </summary>
        /// <returns>食材类别列表</returns>
        public Task<List<EnumValueDto>> GetIngredientCategoriesAsync()
        {
            var categories = EnumExtensions.GetAllValuesAndDescriptions<IngredientCategory>();
            
            var result = categories.Select(c => new EnumValueDto
            {
                Value = c.Value,
                Name = c.Name,
                Description = c.Description
            }).ToList();
            
            return Task.FromResult(result);
        }

        /// <summary>
        /// 分页查询食材列表
        /// </summary>
        /// <param name="queryDto">查询条件</param>
        /// <returns>分页食材列表</returns>
        public async Task<PaginationResponseDto<IngredientDto>> GetPagedIngredientsAsync(IngredientQueryDto queryDto)
        {
            // 查询食材及总数
            var (ingredients, totalCount) = await _ingredientRepository.GetPagedIngredientsAsync(
                queryDto.PageIndex,
                queryDto.PageSize,
                queryDto.Category,
                queryDto.Keyword
            );
            
            // 转换为DTO
            var ingredientDtos = ingredients.Select(i => new IngredientDto(i)).ToList();
            
            // 构建分页响应
            var response = new PaginationResponseDto<IngredientDto>
            {
                PageIndex = queryDto.PageIndex,
                PageSize = queryDto.PageSize,
                TotalCount = totalCount,
                Items = ingredientDtos
            };
            
            return response;
        }

        /// <summary>
        /// 获取食材列表
        /// </summary>
        /// <returns>食材列表</returns>
        public async Task<List<IngredientDto>> GetIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return ingredients.Select(i => new IngredientDto(i)).ToList();
        }

        /// <summary>
        /// 根据分类获取食材列表
        /// </summary>
        /// <param name="category">食材分类</param>
        /// <returns>食材列表</returns>
        public async Task<List<IngredientDto>> GetIngredientsByCategoryAsync(IngredientCategory category)
        {
            var ingredients = await _ingredientRepository.GetByCategoryAsync(category);
            return ingredients.Select(i => new IngredientDto(i)).ToList();
        }

        /// <summary>
        /// 获取食材详情（包含关联数据）
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>食材详情</returns>
        public async Task<IngredientDto> GetIngredientAsync(Guid id)
        {
            // 获取包含所有关联数据的食材
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(id, true, true, true);
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{id}");

            return new IngredientDto(ingredient);
        }

        /// <summary>
        /// 创建食材
        /// </summary>
        /// <param name="dto">创建食材DTO</param>
        /// <returns>创建的食材</returns>
        public async Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto dto)
        {
            // 检查是否存在同名食材
            var existingIngredient = await _ingredientRepository.GetByNameAsync(dto.Name);
            if (existingIngredient != null)
                throw new ApplicationException($"已存在同名食材：{dto.Name}");

            // 创建食材
            var ingredient = Ingredient.Create(
                dto.Name,
                dto.Category,
                dto.WaterContent,
                dto.FlavorProfile,
                dto.MainFunctions,
                dto.CookingBehavior,
                dto.PreferredUsage,
                dto.Volatile,
                dto.Notes
            );

            // 处理关联数据
            if (dto.Nutritions != null && dto.Nutritions.Count > 0)
            {
                foreach (var nutrition in dto.Nutritions)
                {
                    ingredient.AddNutrition(nutrition.NutrientId, nutrition.Amount, nutrition.PerUnit);
                }
            }

            if (dto.HumanGroups != null && dto.HumanGroups.Count > 0)
            {
                foreach (var humanGroup in dto.HumanGroups)
                {
                    ingredient.AddHumanGroup(humanGroup.GroupId, humanGroup.Effect, humanGroup.Notes);
                }
            }

            if (dto.Preprocesses != null && dto.Preprocesses.Count > 0)
            {
                foreach (var preprocess in dto.Preprocesses)
                {
                    ingredient.AddPreprocess(
                        preprocess.Method,
                        preprocess.Description,
                        preprocess.DurationSec,
                        preprocess.TemperatureDesc,
                        preprocess.ImageUrl
                    );
                }
            }

            // 保存到数据库
            await _ingredientRepository.AddAsync(ingredient);
            await _unitOfWork.SaveChangesAsync();

            // 返回创建的食材
            return new IngredientDto(ingredient);
        }

        /// <summary>
        /// 更新食材
        /// </summary>
        /// <param name="dto">更新食材DTO</param>
        /// <returns>更新后的食材</returns>
        public async Task<IngredientDto> UpdateIngredientAsync(UpdateIngredientDto dto)
        {
            // 检查食材是否存在
            var ingredient = await _ingredientRepository.GetByIdAsync(dto.Id);
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.Id}");

            // 检查是否存在同名但不同ID的食材
            var existingIngredient = await _ingredientRepository.GetByNameAsync(dto.Name);
            if (existingIngredient != null && existingIngredient.Id != dto.Id)
                throw new ApplicationException($"已存在同名食材：{dto.Name}");

            // 更新食材
            ingredient.Update(
                dto.Name,
                dto.Category,
                dto.WaterContent,
                dto.FlavorProfile,
                dto.MainFunctions,
                dto.CookingBehavior,
                dto.PreferredUsage,
                dto.Volatile,
                dto.Notes
            );

            // 保存到数据库
            await _ingredientRepository.UpdateAsync(ingredient);
            await _unitOfWork.SaveChangesAsync();

            // 返回更新后的食材
            return new IngredientDto(ingredient);
        }

        /// <summary>
        /// 删除食材
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>任务</returns>
        public async Task DeleteIngredientAsync(Guid id)
        {
            // 检查食材是否存在
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{id}");

            // 检查是否被菜谱使用
            if (await _ingredientRepository.IsUsedByRecipesAsync(id))
                throw new ApplicationException($"该食材已被菜谱使用，无法删除");

            // 删除食材
            await _ingredientRepository.RemoveAsync(ingredient);
            await _unitOfWork.SaveChangesAsync();
        }

        #region 营养成分相关操作

        /// <summary>
        /// 添加食材营养成分
        /// </summary>
        /// <param name="dto">添加营养成分DTO</param>
        /// <returns>添加的营养成分</returns>
        public async Task<IngredientNutritionDto> AddNutritionAsync(AddIngredientNutritionDto dto)
        {
            // 检查食材是否存在，只加载营养成分相关数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: true, includeHumanGroups: false, includePreprocesses: false);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 添加营养成分
                var nutrition = ingredient.AddNutrition(dto.NutrientId, dto.Amount, dto.PerUnit);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 返回添加的营养成分
                return new IngredientNutritionDto(nutrition);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材营养成分
        /// </summary>
        /// <param name="dto">更新营养成分DTO</param>
        /// <returns>更新后的营养成分</returns>
        public async Task<IngredientNutritionDto> UpdateNutritionAsync(UpdateIngredientNutritionDto dto)
        {
            // 检查食材是否存在，只加载营养成分相关数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: true, includeHumanGroups: false, includePreprocesses: false);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 更新营养成分
                ingredient.UpdateNutrition(dto.Id, dto.Amount, dto.PerUnit);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 获取更新后的营养成分
                var nutrition = ingredient.Nutritions.FirstOrDefault(n => n.Id == dto.Id);
                return new IngredientNutritionDto(nutrition);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材营养成分
        /// </summary>
        /// <param name="nutritionId">营养成分ID</param>
        /// <returns>任务</returns>
        public async Task DeleteNutritionAsync(Guid nutritionId)
        {
            // 获取包含该营养成分的食材
            var ingredients = await _ingredientRepository.GetAllAsync();
            var ingredient = ingredients
                .FirstOrDefault(i => i.Nutritions.Any(n => n.Id == nutritionId));

            if (ingredient == null)
                throw new ApplicationException($"营养成分不存在：{nutritionId}");

            try
            {
                // 删除营养成分
                ingredient.RemoveNutrition(nutritionId);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        #endregion

        #region 人群适宜/忌用相关操作

        /// <summary>
        /// 添加食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">添加人群映射DTO</param>
        /// <returns>添加的人群映射</returns>
        public async Task<IngredientHumanGroupDto> AddHumanGroupAsync(AddIngredientHumanGroupDto dto)
        {
            // 检查食材是否存在，只加载人群关联数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: false, includeHumanGroups: true, includePreprocesses: false);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 添加人群映射
                var humanGroup = ingredient.AddHumanGroup(dto.GroupId, dto.Effect, dto.Notes);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 返回添加的人群映射
                return new IngredientHumanGroupDto(humanGroup);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">更新人群映射DTO</param>
        /// <returns>更新后的人群映射</returns>
        public async Task<IngredientHumanGroupDto> UpdateHumanGroupAsync(UpdateIngredientHumanGroupDto dto)
        {
            // 检查食材是否存在，只加载人群关联数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: false, includeHumanGroups: true, includePreprocesses: false);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 更新人群映射
                ingredient.UpdateHumanGroup(dto.Id, dto.Effect, dto.Notes);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 获取更新后的人群映射
                var humanGroup = ingredient.HumanGroups.FirstOrDefault(h => h.Id == dto.Id);
                return new IngredientHumanGroupDto(humanGroup);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材人群适宜/忌用映射
        /// </summary>
        /// <param name="humanGroupId">人群映射ID</param>
        /// <returns>任务</returns>
        public async Task DeleteHumanGroupAsync(Guid humanGroupId)
        {
            // 使用WhereIf查询包含关联数据的食材
            var ingredients = await _ingredientRepository.FindAsync(i => i.HumanGroups.Any(h => h.Id == humanGroupId));
            var ingredient = ingredients.FirstOrDefault();

            if (ingredient == null)
                throw new ApplicationException($"人群映射不存在：{humanGroupId}");

            try
            {
                // 加载完整的人群关联数据
                ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                    ingredient.Id, includeNutritions: false, includeHumanGroups: true, includePreprocesses: false);
                
                // 删除人群映射
                ingredient.RemoveHumanGroup(humanGroupId);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        #endregion

        #region 预处理方法相关操作

        /// <summary>
        /// 添加食材预处理方法
        /// </summary>
        /// <param name="dto">添加预处理方法DTO</param>
        /// <returns>添加的预处理方法</returns>
        public async Task<IngredientPreprocessDto> AddPreprocessAsync(AddIngredientPreprocessDto dto)
        {
            // 检查食材是否存在，只加载预处理相关数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: false, includeHumanGroups: false, includePreprocesses: true);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 添加预处理方法
                var preprocess = ingredient.AddPreprocess(
                    dto.Method,
                    dto.Description,
                    dto.DurationSec,
                    dto.TemperatureDesc,
                    dto.ImageUrl
                );

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 返回添加的预处理方法
                return new IngredientPreprocessDto(preprocess);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材预处理方法
        /// </summary>
        /// <param name="dto">更新预处理方法DTO</param>
        /// <returns>更新后的预处理方法</returns>
        public async Task<IngredientPreprocessDto> UpdatePreprocessAsync(UpdateIngredientPreprocessDto dto)
        {
            // 检查食材是否存在，只加载预处理相关数据
            var ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                dto.IngredientId, includeNutritions: false, includeHumanGroups: false, includePreprocesses: true);
                
            if (ingredient == null)
                throw new ApplicationException($"食材不存在：{dto.IngredientId}");

            try
            {
                // 更新预处理方法
                ingredient.UpdatePreprocess(
                    dto.Id,
                    dto.Method,
                    dto.Description,
                    dto.DurationSec,
                    dto.TemperatureDesc,
                    dto.ImageUrl
                );

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();

                // 获取更新后的预处理方法
                var preprocess = ingredient.Preprocesses.FirstOrDefault(p => p.Id == dto.Id);
                return new IngredientPreprocessDto(preprocess);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材预处理方法
        /// </summary>
        /// <param name="preprocessId">预处理方法ID</param>
        /// <returns>任务</returns>
        public async Task DeletePreprocessAsync(Guid preprocessId)
        {
            // 使用WhereIf查询包含关联数据的食材
            var ingredients = await _ingredientRepository.FindAsync(i => i.Preprocesses.Any(p => p.Id == preprocessId));
            var ingredient = ingredients.FirstOrDefault();

            if (ingredient == null)
                throw new ApplicationException($"预处理方法不存在：{preprocessId}");

            try
            {
                // 加载完整的预处理关联数据
                ingredient = await _ingredientRepository.GetIngredientWithRelationsAsync(
                    ingredient.Id, includeNutritions: false, includeHumanGroups: false, includePreprocesses: true);
                
                // 删除预处理方法
                ingredient.RemovePreprocess(preprocessId);

                // 保存到数据库
                await _ingredientRepository.UpdateAsync(ingredient);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        #endregion
    }
} 