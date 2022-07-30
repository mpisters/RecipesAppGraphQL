using RecipesApp.Controllers.Dtos;
using RecipesApp.Core;
using RecipesApp.Db;
using RecipesApp.Domain;

namespace RecipesApp.Mutations;

public class MutateRecipe
{
    public async Task<Recipe> CreateCompleteRecipe([Service] IRecipeRepository recipeRepository,
        CreateRecipeDto createRecipeDto)
    {
        var recipe = RecipeHelper.CreateRecipeFromDto(createRecipeDto);
        return await recipeRepository.CreateRecipe(recipe);
    }

    public async Task<Ingredient> CreateIngredientForRecipeId([Service] IRecipeRepository recipeRepository,
        int recipeId, CreateIngredientDto ingredientDto)
    {

        return await recipeRepository.CreateIngredientForRecipeId(recipeId, ingredientDto);
    }
}