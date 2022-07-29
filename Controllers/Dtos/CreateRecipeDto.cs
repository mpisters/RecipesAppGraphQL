using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Controllers.Dtos;

public class CreateRecipeDto
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }
    [MinLength(1)]
    public List<CreateIngredientDto> Ingredients { get; set; }
    [MinLength(1)]
    public List<CreateRecipeStepDto> Steps { get; set; }
}