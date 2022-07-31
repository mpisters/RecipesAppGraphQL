using Microsoft.EntityFrameworkCore;
using RecipesApp.Core.Dtos;
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
        return _recipesContext.Recipes.Include(r => r.Ingredients)
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

    public async Task<Ingredient> CreateIngredientForRecipeId(int recipeId, CreateIngredientDto createIngredientDto)
    {
        var recipe = await _recipesContext.Recipes
            .Include(r => r.Ingredients)
            .ThenInclude((ingredient) => ingredient.Product)
            .FirstOrDefaultAsync(x => x.Id == recipeId);

        if (recipe == null)
        {
            return null;
        }

        var ingredient = new Ingredient()
        {
            Product = new Product()
            {
                Name = createIngredientDto.Product.Name,
            },
            Amount = createIngredientDto.Amount,
            UnitOfMeasurement = createIngredientDto.UnitOfMeasurement,
        };

        if (recipe.Ingredients != null)
        {
            recipe.Ingredients.Add(ingredient);

        }
        else
        {
            recipe.Ingredients = new List<Ingredient>() { ingredient };
        }
        _recipesContext.Recipes.Update(recipe);
        await _recipesContext.SaveChangesAsync();
        return ingredient;
    }
}