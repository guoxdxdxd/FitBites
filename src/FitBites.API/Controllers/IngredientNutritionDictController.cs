using FitBites.Application.DTOs;
using FitBites.Application.DTOs.Ingredient;
using FitBites.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 营养成分字典管理控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientNutritionDictController : ControllerBase
    {
        private readonly IIngredientNutritionDictService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">营养成分字典服务</param>
        public IngredientNutritionDictController(IIngredientNutritionDictService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取所有营养成分字典
        /// </summary>
        /// <returns>营养成分字典列表</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<List<IngredientNutritionDictDto>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _service.GetAllAsync();
                return Ok(ApiResult<List<IngredientNutritionDictDto>>.Success(items));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<List<IngredientNutritionDictDto>>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 根据ID获取营养成分字典
        /// </summary>
        /// <param name="id">成分ID</param>
        /// <returns>营养成分字典</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<IngredientNutritionDictDto>), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var item = await _service.GetByIdAsync(id);
                if (item == null)
                {
                    return NotFound(ApiResult<IngredientNutritionDictDto>.Fail($"ID为 '{id}' 的营养成分不存在"));
                }
                return Ok(ApiResult<IngredientNutritionDictDto>.Success(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<IngredientNutritionDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 创建营养成分字典
        /// </summary>
        /// <param name="dto">创建DTO</param>
        /// <returns>创建后的营养成分字典</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<IngredientNutritionDictDto>), 201)]
        public async Task<IActionResult> Create([FromBody] CreateIngredientNutritionDictDto dto)
        {
            try
            {
                var item = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = item.Id }, ApiResult<IngredientNutritionDictDto>.Success(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<IngredientNutritionDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 更新营养成分字典
        /// </summary>
        /// <param name="id">成分ID</param>
        /// <param name="dto">更新DTO</param>
        /// <returns>更新后的营养成分字典</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult<IngredientNutritionDictDto>), 200)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateIngredientNutritionDictDto dto)
        {
            try
            {
                var item = await _service.UpdateAsync(id, dto);
                return Ok(ApiResult<IngredientNutritionDictDto>.Success(item));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<IngredientNutritionDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 删除营养成分字典
        /// </summary>
        /// <param name="id">成分ID</param>
        /// <returns>操作结果</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(ApiResult.Success("删除成功"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult.Fail(ex.Message));
            }
        }
    }
} 