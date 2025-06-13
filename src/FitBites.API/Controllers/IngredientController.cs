using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Ingredient;
using FitBites.Application.Services.Interfaces;
using FitBites.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 食材管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ingredientService">食材服务</param>
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        
        /// <summary>
        /// 分页查询食材列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <returns>分页食材列表</returns>
        [HttpGet("paged")]
        public async Task<ApiResult<PaginationResponseDto<IngredientDto>>> GetPagedIngredients([FromQuery] IngredientQueryDto query)
        {
            try
            {
                var pagedIngredients = await _ingredientService.GetPagedIngredientsAsync(query);
                return ApiResult<PaginationResponseDto<IngredientDto>>.Success(pagedIngredients);
            }
            catch (Exception ex)
            {
                return ApiResult<PaginationResponseDto<IngredientDto>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有食材
        /// </summary>
        /// <returns>食材列表</returns>
        [HttpGet]
        public async Task<ApiResult<List<IngredientDto>>> GetIngredients()
        {
            try
            {
                var ingredients = await _ingredientService.GetIngredientsAsync();
                return ApiResult<List<IngredientDto>>.Success(ingredients);
            }
            catch (Exception ex)
            {
                return ApiResult<List<IngredientDto>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有食材类别
        /// </summary>
        /// <returns>食材类别列表</returns>
        [HttpGet("categories")]
        public async Task<ApiResult<List<EnumValueDto>>> GetIngredientCategories()
        {
            try
            {
                var categories = await _ingredientService.GetIngredientCategoriesAsync();
                return ApiResult<List<EnumValueDto>>.Success(categories);
            }
            catch (Exception ex)
            {
                return ApiResult<List<EnumValueDto>>.Fail(ex.Message);
            }
        }
        
        /// <summary>
        /// 根据分类获取食材
        /// </summary>
        /// <param name="category">食材分类</param>
        /// <returns>食材列表</returns>
        [HttpGet("category/{category}")]
        public async Task<ApiResult<List<IngredientDto>>> GetIngredientsByCategory(IngredientCategory category)
        {
            try
            {
                var ingredients = await _ingredientService.GetIngredientsByCategoryAsync(category);
                return ApiResult<List<IngredientDto>>.Success(ingredients);
            }
            catch (Exception ex)
            {
                return ApiResult<List<IngredientDto>>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 获取食材详情
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>食材详情</returns>
        [HttpGet("{id}")]
        public async Task<ApiResult<IngredientDto>> GetIngredient(Guid id)
        {
            try
            {
                var ingredient = await _ingredientService.GetIngredientAsync(id);
                return ApiResult<IngredientDto>.Success(ingredient);
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 创建食材
        /// </summary>
        /// <param name="dto">创建食材DTO</param>
        /// <returns>创建结果</returns>
        [HttpPost]
        [Authorize]
        public async Task<ApiResult<IngredientDto>> CreateIngredient(CreateIngredientDto dto)
        {
            try
            {
                var ingredient = await _ingredientService.CreateIngredientAsync(dto);
                return ApiResult<IngredientDto>.Success(ingredient, "食材创建成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材
        /// </summary>
        /// <param name="dto">更新食材DTO</param>
        /// <returns>更新结果</returns>
        [HttpPut]
        [Authorize]
        public async Task<ApiResult<IngredientDto>> UpdateIngredient(UpdateIngredientDto dto)
        {
            try
            {
                var ingredient = await _ingredientService.UpdateIngredientAsync(dto);
                return ApiResult<IngredientDto>.Success(ingredient, "食材更新成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材
        /// </summary>
        /// <param name="id">食材ID</param>
        /// <returns>删除结果</returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ApiResult> DeleteIngredient(Guid id)
        {
            try
            {
                await _ingredientService.DeleteIngredientAsync(id);
                return ApiResult.Success("食材删除成功");
            }
            catch (Exception ex)
            {
                return ApiResult.Fail(ex.Message);
            }
        }

        #region 营养成分相关操作

        /// <summary>
        /// 添加食材营养成分
        /// </summary>
        /// <param name="dto">添加营养成分DTO</param>
        /// <returns>添加结果</returns>
        [HttpPost("nutrition")]
        [Authorize]
        public async Task<ApiResult<IngredientNutritionDto>> AddNutrition(AddIngredientNutritionDto dto)
        {
            try
            {
                var nutrition = await _ingredientService.AddNutritionAsync(dto);
                return ApiResult<IngredientNutritionDto>.Success(nutrition, "营养成分添加成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientNutritionDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材营养成分
        /// </summary>
        /// <param name="dto">更新营养成分DTO</param>
        /// <returns>更新结果</returns>
        [HttpPut("nutrition")]
        [Authorize]
        public async Task<ApiResult<IngredientNutritionDto>> UpdateNutrition(UpdateIngredientNutritionDto dto)
        {
            try
            {
                var nutrition = await _ingredientService.UpdateNutritionAsync(dto);
                return ApiResult<IngredientNutritionDto>.Success(nutrition, "营养成分更新成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientNutritionDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材营养成分
        /// </summary>
        /// <param name="id">营养成分ID</param>
        /// <returns>删除结果</returns>
        [HttpDelete("nutrition/{id}")]
        [Authorize]
        public async Task<ApiResult> DeleteNutrition(Guid id)
        {
            try
            {
                await _ingredientService.DeleteNutritionAsync(id);
                return ApiResult.Success("营养成分删除成功");
            }
            catch (Exception ex)
            {
                return ApiResult.Fail(ex.Message);
            }
        }

        #endregion

        #region 人群适宜/忌用相关操作

        /// <summary>
        /// 添加食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">添加人群映射DTO</param>
        /// <returns>添加结果</returns>
        [HttpPost("humangroup")]
        [Authorize]
        public async Task<ApiResult<IngredientHumanGroupDto>> AddHumanGroup(AddIngredientHumanGroupDto dto)
        {
            try
            {
                var humanGroup = await _ingredientService.AddHumanGroupAsync(dto);
                return ApiResult<IngredientHumanGroupDto>.Success(humanGroup, "人群适宜/忌用映射添加成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientHumanGroupDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材人群适宜/忌用映射
        /// </summary>
        /// <param name="dto">更新人群映射DTO</param>
        /// <returns>更新结果</returns>
        [HttpPut("humangroup")]
        [Authorize]
        public async Task<ApiResult<IngredientHumanGroupDto>> UpdateHumanGroup(UpdateIngredientHumanGroupDto dto)
        {
            try
            {
                var humanGroup = await _ingredientService.UpdateHumanGroupAsync(dto);
                return ApiResult<IngredientHumanGroupDto>.Success(humanGroup, "人群适宜/忌用映射更新成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientHumanGroupDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材人群适宜/忌用映射
        /// </summary>
        /// <param name="id">人群映射ID</param>
        /// <returns>删除结果</returns>
        [HttpDelete("humangroup/{id}")]
        [Authorize]
        public async Task<ApiResult> DeleteHumanGroup(Guid id)
        {
            try
            {
                await _ingredientService.DeleteHumanGroupAsync(id);
                return ApiResult.Success("人群适宜/忌用映射删除成功");
            }
            catch (Exception ex)
            {
                return ApiResult.Fail(ex.Message);
            }
        }

        #endregion

        #region 预处理方法相关操作

        /// <summary>
        /// 添加食材预处理方法
        /// </summary>
        /// <param name="dto">添加预处理方法DTO</param>
        /// <returns>添加结果</returns>
        [HttpPost("preprocess")]
        [Authorize]
        public async Task<ApiResult<IngredientPreprocessDto>> AddPreprocess(AddIngredientPreprocessDto dto)
        {
            try
            {
                var preprocess = await _ingredientService.AddPreprocessAsync(dto);
                return ApiResult<IngredientPreprocessDto>.Success(preprocess, "预处理方法添加成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientPreprocessDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 更新食材预处理方法
        /// </summary>
        /// <param name="dto">更新预处理方法DTO</param>
        /// <returns>更新结果</returns>
        [HttpPut("preprocess")]
        [Authorize]
        public async Task<ApiResult<IngredientPreprocessDto>> UpdatePreprocess(UpdateIngredientPreprocessDto dto)
        {
            try
            {
                var preprocess = await _ingredientService.UpdatePreprocessAsync(dto);
                return ApiResult<IngredientPreprocessDto>.Success(preprocess, "预处理方法更新成功");
            }
            catch (Exception ex)
            {
                return ApiResult<IngredientPreprocessDto>.Fail(ex.Message);
            }
        }

        /// <summary>
        /// 删除食材预处理方法
        /// </summary>
        /// <param name="id">预处理方法ID</param>
        /// <returns>删除结果</returns>
        [HttpDelete("preprocess/{id}")]
        [Authorize]
        public async Task<ApiResult> DeletePreprocess(Guid id)
        {
            try
            {
                await _ingredientService.DeletePreprocessAsync(id);
                return ApiResult.Success("预处理方法删除成功");
            }
            catch (Exception ex)
            {
                return ApiResult.Fail(ex.Message);
            }
        }

        #endregion
    }
} 