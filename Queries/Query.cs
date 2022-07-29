using RecipesApp.Db;
using RecipesApp.Domain;

namespace RecipesApp.Queries;

public class Query
{
    public List<Recipe> GetRecipes([Service] RecipeRepository recipeRepository)
    {
        return recipeRepository.GetRecipes();
    }

}