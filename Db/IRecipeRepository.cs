using RecipesApp.Controllers.Dtos;
using RecipesApp.Domain;

namespace RecipesApp.Db;

public interface IRecipeRepository
{
    public List<Recipe> GetRecipes();
    public Recipe GetRecipeById(int id);
    public Task<Recipe> CreateRecipe(Recipe recipe);
    public Task<Ingredient> CreateIngredientForRecipeId(int recipeId, CreateIngredientDto createIngredientDto);
}