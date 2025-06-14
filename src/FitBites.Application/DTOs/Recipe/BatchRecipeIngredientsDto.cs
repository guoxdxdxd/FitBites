namespace FitBites.Application.DTOs.Recipe;

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