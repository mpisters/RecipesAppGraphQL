using RecipesApp.Core;
using RecipesApp.Core.Dtos;
using RecipesApp.Db;
using RecipesApp.Domain;

namespace RecipesApp.Mutations;

public class MutateRecipe
{
    public async Task<Recipe> CreateRecipe([Service] IRecipeRepository recipeRepository,
        CreateRecipeDto createRecipeDto)
    {
        var recipe = RecipeConverter.CreateRecipeFromDto(createRecipeDto);
        return await recipeRepository.CreateRecipe(recipe);
    }

    public async Task<Ingredient> CreateIngredientForRecipeId([Service] IRecipeRepository recipeRepository,
        int recipeId, CreateIngredientDto ingredientDto)
    {

        return await recipeRepository.CreateIngredientForRecipeId(recipeId, ingredientDto);
    }
}