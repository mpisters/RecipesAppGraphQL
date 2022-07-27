using System.Collections.Specialized;

namespace RecipesApp.Domain;

public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<RecipeStep> Steps { get; set; }
}