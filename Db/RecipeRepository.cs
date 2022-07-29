using Microsoft.EntityFrameworkCore;
using RecipesApp.Domain;

namespace RecipesApp.Db;

public class RecipeRepository
{
    private readonly RecipesContext _recipesContext;

    public RecipeRepository(RecipesContext recipesContext)
    {
        _recipesContext = recipesContext;
    }

    public List<Recipe> GetRecipes()
    {
        return _recipesContext.Recipes.ToList();
    }

    public Recipe GetRecipeById(int id)
    {
        var recipe = _recipesContext.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Steps)
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