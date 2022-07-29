using RecipesApp.Db;
using RecipesApp.Domain;

namespace RecipesApp.Queries;

public class QueryRecipe
{
    public Recipe GetRecipe([Service(ServiceKind.Synchronized)] RecipesContext recipesContext)
    {
        return recipesContext.Recipes.FirstOrDefault();
    }
}