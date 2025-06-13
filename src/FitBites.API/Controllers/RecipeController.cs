using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Recipe;
using FitBites.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 菜式控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeApplicationService _recipeService;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public RecipeController(IRecipeApplicationService recipeService)
        {
            _recipeService = recipeService;
        }
        
        /// <summary>
        /// 获取菜式详情
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <returns>菜式详情</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            try
            {
                var recipe = await _recipeService.GetRecipeAsync(id);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return NotFound(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 创建菜式基础信息
        /// </summary>
        /// <param name="dto">创建菜式基础信息DTO</param>
        /// <returns>创建后的菜式</returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateRecipe(CreateRecipeBaseDto dto)
        {
            try
            {
                var recipe = await _recipeService.CreateRecipeBaseInfoAsync(dto);
                return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 批量提交菜式食材
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="dto">食材列表DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPost("{id}/ingredients/batch")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BatchAddRecipeIngredients(Guid id, BatchRecipeIngredientsDto dto)
        {
            try
            {
                var recipe = await _recipeService.BatchAddRecipeIngredientsAsync(id, dto.Ingredients);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 删除菜式食材
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="ingredientId">食材关联ID</param>
        /// <returns>更新后的菜式</returns>
        [HttpDelete("{id}/ingredients/{ingredientId}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRecipeIngredient(Guid id, Guid ingredientId)
        {
            try
            {
                var recipe = await _recipeService.RemoveRecipeIngredientAsync(id, ingredientId);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 修改菜式食材
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="ingredientId">食材关联ID</param>
        /// <param name="dto">更新食材DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/ingredients/{ingredientId}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRecipeIngredient(Guid id, Guid ingredientId, UpdateRecipeIngredientDto dto)
        {
            try
            {
                var recipe = await _recipeService.UpdateRecipeIngredientAsync(id, ingredientId, dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 批量提交烹饪步骤（会先清空已有步骤）
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="dto">烹饪步骤列表DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPost("{id}/cooking-steps/batch")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BatchAddRecipeCookingSteps(Guid id, BatchRecipeCookingStepsDto dto)
        {
            try
            {
                var recipe = await _recipeService.ReplaceCookingStepsAsync(id, dto.CookingSteps);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 更新菜式基本信息
        /// </summary>
        /// <param name="dto">更新菜式DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRecipeBasicInfo(UpdateRecipeDto dto)
        {
            try
            {
                var recipe = await _recipeService.UpdateRecipeBasicInfoAsync(dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 设置菜式图片
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="imageUrl">图片URL</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/image")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetRecipeImage(Guid id, [FromBody] string imageUrl)
        {
            try
            {
                var recipe = await _recipeService.SetRecipeImageAsync(id, imageUrl);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 设置菜式时间信息
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="dto">时间信息DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/time-info")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetRecipeTimeInfo(Guid id, [FromBody] RecipeTimeInfoDto dto)
        {
            try
            {
                var recipe = await _recipeService.SetRecipeTimeInfoAsync(id, dto.PrepTime, dto.CookTime, dto.Servings);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 添加菜式食材
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="dto">食材DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPost("{id}/ingredients")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRecipeIngredient(Guid id, CreateRecipeIngredientDto dto)
        {
            try
            {
                var recipe = await _recipeService.AddRecipeIngredientAsync(id, dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 添加菜式烹饪步骤
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="dto">烹饪步骤DTO</param>
        /// <returns>更新后的菜式</returns>
        [HttpPost("{id}/cooking-steps")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRecipeCookingStep(Guid id, CreateRecipeCookingStepDto dto)
        {
            try
            {
                var recipe = await _recipeService.AddRecipeCookingStepAsync(id, dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 设置菜式推荐状态
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <param name="isRecommended">是否推荐</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/recommendation")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetRecipeRecommendation(Guid id, [FromBody] bool isRecommended)
        {
            try
            {
                var recipe = await _recipeService.SetRecipeRecommendationAsync(id, isRecommended);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 启用菜式
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/enable")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EnableRecipe(Guid id)
        {
            try
            {
                var recipe = await _recipeService.EnableRecipeAsync(id);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 禁用菜式
        /// </summary>
        /// <param name="id">菜式ID</param>
        /// <returns>更新后的菜式</returns>
        [HttpPut("{id}/disable")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DisableRecipe(Guid id)
        {
            try
            {
                var recipe = await _recipeService.DisableRecipeAsync(id);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 获取推荐菜式列表
        /// </summary>
        /// <param name="count">数量</param>
        /// <returns>推荐菜式列表</returns>
        [HttpGet("recommended")]
        [ProducesResponseType(typeof(ApiResult<List<RecipeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecommendedRecipes([FromQuery] int count = 10)
        {
            try
            {
                var recipes = await _recipeService.GetRecommendedRecipesAsync(count);
                return Ok(ApiResult<List<RecipeDto>>.Success(recipes));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<List<RecipeDto>>.Fail(ex.Message));
            }
        }
        
        /// <summary>
        /// 分页获取菜式列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="keyword">关键词</param>
        /// <returns>菜式分页列表</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<PaginationResponseDto<RecipeDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipeList(
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 10,
            [FromQuery] string keyword = null)
        {
            try
            {
                var recipes = await _recipeService.GetRecipeListAsync(page, pageSize, keyword);
                return Ok(ApiResult<PaginationResponseDto<RecipeDto>>.Success(recipes));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<PaginationResponseDto<RecipeDto>>.Fail(ex.Message));
            }
        }
    }
    
    /// <summary>
    /// 菜式时间信息DTO
    /// </summary>
    public class RecipeTimeInfoDto
    {
        /// <summary>
        /// 准备时间（分钟）
        /// </summary>
        public int? PrepTime { get; set; }
        
        /// <summary>
        /// 烹饪时间（分钟）
        /// </summary>
        public int? CookTime { get; set; }
        
        /// <summary>
        /// 几人份
        /// </summary>
        public int? Servings { get; set; }
    }
    
    /// <summary>
    /// 批量提交菜式食材DTO
    /// </summary>
    public class BatchRecipeIngredientsDto
    {
        /// <summary>
        /// 食材列表
        /// </summary>
        public List<CreateRecipeIngredientDto> Ingredients { get; set; } = new List<CreateRecipeIngredientDto>();
    }
    
    /// <summary>
    /// 批量提交烹饪步骤DTO
    /// </summary>
    public class BatchRecipeCookingStepsDto
    {
        /// <summary>
        /// 烹饪步骤列表
        /// </summary>
        public List<CreateRecipeCookingStepDto> CookingSteps { get; set; } = new List<CreateRecipeCookingStepDto>();
    }
}