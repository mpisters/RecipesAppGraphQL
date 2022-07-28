using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Domain;

public class RecipeStep
{
    [Key]
    public int StepNumber { get; set; }
    public string Description { get; set; }
}