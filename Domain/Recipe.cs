#nullable enable

namespace RecipesApp.Domain;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CookingTime { get; set; }
    public int TotalPersons { get; set; }
    public List<Ingredient>? Ingredients { get; set; }
    public List<RecipeStep>? Steps { get; set; }
}