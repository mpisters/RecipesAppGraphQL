using RecipesApp.Core.Dtos;
using RecipesApp.Domain;

namespace RecipesApp.Core;

public class RecipeConverter
{
    public static Recipe CreateRecipeFromDto(CreateRecipeDto createRecipeDto)
    {
        var ingredients = new List<Ingredient>();

        if (createRecipeDto.Ingredients != null)
        {
            ingredients = createRecipeDto.Ingredients.Select(x =>
                new Ingredient()
                {
                    Amount = x.Amount,
                    Product = new Product()
                    {
                        Name = x.Product.Name,
                    },
                    UnitOfMeasurement = x.UnitOfMeasurement,
                }).ToList();
        }

        var steps = new List<RecipeStep>();

        if (createRecipeDto.Steps != null)
        {
            steps = createRecipeDto.Steps.Select(x => new RecipeStep()
            {
                Description = x.Description,
            }).ToList();
        }

        var recipe = new Recipe()
        {
            Ingredients = ingredients,
            Steps = steps,
            Name = createRecipeDto.Name
        };

        return recipe;
    }
}