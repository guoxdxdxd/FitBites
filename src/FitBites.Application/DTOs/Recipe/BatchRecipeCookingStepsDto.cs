namespace FitBites.Application.DTOs.Recipe;

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