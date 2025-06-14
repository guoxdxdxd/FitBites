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
    /// 菜式烹饪步骤管理
    /// </summary>
    [Route("api/recipes/{recipeId}/cooking-steps")]
    [ApiController]
    public class RecipeCookingStepController : ControllerBase
    {
        private readonly IRecipeApplicationService _recipeService;
        public RecipeCookingStepController(IRecipeApplicationService recipeService)
        {
            _recipeService = recipeService;
        }

        /// <summary>
        /// 批量提交烹饪步骤（会先清空已有步骤）
        /// </summary>
        [HttpPost("batch")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BatchAddRecipeCookingSteps(Guid recipeId, BatchRecipeCookingStepsDto dto)
        {
            try
            {
                var recipe = await _recipeService.ReplaceCookingStepsAsync(recipeId, dto.CookingSteps);
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
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ApiResult<RecipeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddRecipeCookingStep(Guid recipeId, CreateRecipeCookingStepDto dto)
        {
            try
            {
                var recipe = await _recipeService.AddRecipeCookingStepAsync(recipeId, dto);
                return Ok(ApiResult<RecipeDto>.Success(recipe));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<RecipeDto>.Fail(ex.Message));
            }
        }
    }
} 