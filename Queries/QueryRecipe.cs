using RecipesApp.Domain;

namespace RecipesApp.Queries;

public class QueryRecipes
{
    public Recipe GetRecipe() => new Recipe
    {
        Name = "Test",
        Ingredients = new List<Ingredient>()
        {
            new Ingredient()
            {
                Amount = 5,
                Product = new Product() { Name = "Tomaat" },
                UnitOfMeasurement = UnitOfMeasurement.unit,
            }
        },
        Steps = new List<RecipeStep>()
        {
            new RecipeStep()
            {
                StepNumber = 1,
                Description = "Snij de tomaten."
            }

        }
    };
}