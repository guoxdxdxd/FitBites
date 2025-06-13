using FitBites.Application.DTOs;
using FitBites.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitBites.API.Controllers
{
    /// <summary>
    /// 人群标签管理控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HumanGroupDictController : ControllerBase
    {
        private readonly IHumanGroupDictService _humanGroupDictService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="humanGroupDictService">人群标签服务</param>
        public HumanGroupDictController(IHumanGroupDictService humanGroupDictService)
        {
            _humanGroupDictService = humanGroupDictService;
        }

        /// <summary>
        /// 获取所有人群标签
        /// </summary>
        /// <returns>人群标签列表</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult<List<HumanGroupDictDto>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var humanGroups = await _humanGroupDictService.GetAllAsync();
                return Ok(ApiResult<List<HumanGroupDictDto>>.Success(humanGroups));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<List<HumanGroupDictDto>>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 根据ID获取人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>人群标签</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<HumanGroupDictDto>), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var humanGroup = await _humanGroupDictService.GetByIdAsync(id);
                if (humanGroup == null)
                {
                    return NotFound(ApiResult<HumanGroupDictDto>.Fail($"ID为 '{id}' 的人群标签不存在"));
                }
                return Ok(ApiResult<HumanGroupDictDto>.Success(humanGroup));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<HumanGroupDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 创建人群标签
        /// </summary>
        /// <param name="dto">创建人群标签DTO</param>
        /// <returns>创建后的人群标签</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<HumanGroupDictDto>), 200)]
        public async Task<IActionResult> Create([FromBody] CreateHumanGroupDictDto dto)
        {
            try
            {
                var humanGroup = await _humanGroupDictService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = humanGroup.Id }, ApiResult<HumanGroupDictDto>.Success(humanGroup));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<HumanGroupDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 更新人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <param name="dto">更新人群标签DTO</param>
        /// <returns>更新后的人群标签</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult<HumanGroupDictDto>), 200)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHumanGroupDictDto dto)
        {
            try
            {
                var humanGroup = await _humanGroupDictService.UpdateAsync(id, dto);
                return Ok(ApiResult<HumanGroupDictDto>.Success(humanGroup));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult<HumanGroupDictDto>.Fail(ex.Message));
            }
        }

        /// <summary>
        /// 删除人群标签
        /// </summary>
        /// <param name="id">标签ID</param>
        /// <returns>操作结果</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _humanGroupDictService.DeleteAsync(id);
                return Ok(ApiResult.Success("删除成功"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResult.Fail(ex.Message));
            }
        }
    }
} 