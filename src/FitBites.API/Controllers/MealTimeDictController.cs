using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitBites.Application.Services.Interfaces;
using FitBites.Application.DTOs;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 餐次字典管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MealTimeDictController : ControllerBase
    {
        private readonly IMealTimeDictService _service;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">餐次字典应用服务</param>
        public MealTimeDictController(IMealTimeDictService service)
        {
            _service = service;
        }

        /// <summary>
        /// 获取所有餐次字典
        /// </summary>
        /// <returns>餐次字典列表</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<IEnumerable<MealTimeDictDto>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(ApiResult<IEnumerable<MealTimeDictDto>>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<IEnumerable<MealTimeDictDto>>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 根据ID获取餐次字典
        /// </summary>
        /// <param name="id">餐次ID</param>
        /// <returns>餐次字典</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<MealTimeDictDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null) return NotFound(ApiResult<MealTimeDictDto>.Fail("餐次不存在"));
                return Ok(ApiResult<MealTimeDictDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<MealTimeDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 根据编码获取餐次字典
        /// </summary>
        /// <param name="code">餐次编码</param>
        /// <returns>餐次字典</returns>
        [HttpGet("by-code/{code}")]
        [ProducesResponseType(typeof(ApiResult<MealTimeDictDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var result = await _service.GetByCodeAsync(code);
                if (result == null) return NotFound(ApiResult<MealTimeDictDto>.Fail("餐次不存在"));
                return Ok(ApiResult<MealTimeDictDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<MealTimeDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 创建餐次字典
        /// </summary>
        /// <param name="dto">创建DTO</param>
        /// <returns>创建后的餐次字典</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<MealTimeDictDto>), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateMealTimeDictDto dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResult<MealTimeDictDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<MealTimeDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 更新餐次字典
        /// </summary>
        /// <param name="dto">更新DTO</param>
        /// <returns>更新后的餐次字典</returns>
        [HttpPut]
        [ProducesResponseType(typeof(ApiResult<MealTimeDictDto>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update([FromBody] UpdateMealTimeDictDto dto)
        {
            try
            {
                var result = await _service.UpdateAsync(dto);
                return Ok(ApiResult<MealTimeDictDto>.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<MealTimeDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 删除餐次字典（软删除）
        /// </summary>
        /// <param name="id">餐次ID</param>
        /// <returns>操作结果</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult), 204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult.Fail(ex.Message));
            }
        }
    }
} 