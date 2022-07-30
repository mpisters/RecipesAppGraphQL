using Microsoft.EntityFrameworkCore;
using RecipesApp.Domain;

namespace RecipesApp.Db;

public class RecipeRepository : IRecipeRepository
{
    private readonly RecipesContext _recipesContext;

    public RecipeRepository(RecipesContext recipesContext)
    {
        _recipesContext = recipesContext;
    }

    public List<Recipe> GetRecipes()
    {
        return _recipesContext.Recipes.
            Include(r => r.Ingredients)
            .ThenInclude((ingredient) => ingredient.Product)
            .Include(r => r.Steps).ToList();

    }

    public Recipe GetRecipeById(int id)
    {
        var recipe = GetRecipes()
            .FirstOrDefault(x => x.Id == id);

        if (recipe != null)
        {
            return recipe;
        }

        return null;
    }

    public async Task<Recipe> CreateRecipe(Recipe recipe)
    {
        await _recipesContext.Recipes.AddAsync(recipe);
        await _recipesContext.SaveChangesAsync();
        return recipe;
    }
}