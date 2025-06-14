using System;
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
    /// 菜式食材管理
    /// </summary>
    [Route("api/recipes/{recipeId}/ingredients")]
    [ApiController]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly IRecipeApplicationService _recipeService;
        public RecipeIngredientController(IRecipeApplicationService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// 批量提交菜式食材
        /// </summary>
        [HttpPost("batch")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BatchAddRecipeIngredients(Guid recipeId, BatchRecipeIngredientsDto dto)
        {
            try
            {
                var recipe = await _recipeService.BatchAddRecipeIngredientsAsync(recipeId, dto.Ingredients);
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
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRecipeIngredient(Guid recipeId, CreateRecipeIngredientDto dto)
        {
            try
            {
                var recipe = await _recipeService.AddRecipeIngredientAsync(recipeId, dto);
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
        [HttpDelete("{ingredientId}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRecipeIngredient(Guid recipeId, Guid ingredientId)
        {
            try
            {
                var recipe = await _recipeService.RemoveRecipeIngredientAsync(recipeId, ingredientId);
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
        [HttpPut("{ingredientId}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRecipeIngredient(Guid recipeId, Guid ingredientId, UpdateRecipeIngredientDto dto)
        {
            try
            {
                var recipe = await _recipeService.UpdateRecipeIngredientAsync(recipeId, ingredientId, dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
    }
} 