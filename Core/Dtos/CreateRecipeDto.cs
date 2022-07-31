#nullable enable
using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Core.Dtos;

public class CreateRecipeDto
{
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; }
    public List<CreateIngredientDto>? Ingredients { get; set; }
    public List<CreateRecipeStepDto>? Steps { get; set; }
}