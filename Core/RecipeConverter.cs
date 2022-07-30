using RecipesApp.Controllers.Dtos;
using RecipesApp.Domain;

namespace RecipesApp.Core;

public class RecipeHelper
{
    public static Recipe CreateRecipeFromDto(CreateRecipeDto createRecipeDto)
    {
        var ingredients = createRecipeDto.Ingredients.Select(x =>
            new Ingredient()
            {
                Amount = x.Amount,
                Product = new Product()
                {
                    Name = x.Product.Name,
                },
                UnitOfMeasurement = x.UnitOfMeasurement,
            }).ToList();

        var steps = createRecipeDto.Steps.Select(x => new RecipeStep()
        {
            Description = x.Description,
        }).ToList();

        var recipe = new Recipe()
        {
            Ingredients = ingredients,
            Steps = steps,
            Name = createRecipeDto.Name
        };

        return recipe;
    }
}