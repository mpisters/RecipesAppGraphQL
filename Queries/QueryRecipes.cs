using RecipesApp.Db;
using RecipesApp.Domain;

namespace RecipesApp.Queries;

public class QueryRecipes
{
    public List<Recipe> GetRecipes([Service] IRecipeRepository recipeRepository)
    {
        return recipeRepository.GetRecipes();
    }

    public Recipe GetRecipeById([Service] IRecipeRepository recipeRepository, int id)
    {
        return recipeRepository.GetRecipeById(id);
    }


}