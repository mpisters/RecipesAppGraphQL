using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecipesApp.Db;
using RecipesApp.Controllers.Dtos;
using RecipesApp.Domain;

namespace RecipesApp.Controllers;

[Route("[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private RecipeRepository _recipeRepository;
    public RecipeController(RecipeRepository repository)
    {
        _recipeRepository = repository;
    }
    [HttpPost]
    public async Task<OkObjectResult> CreateRecipe([FromBody] CreateRecipeDto recipeDto)
    {

        var ingredients = recipeDto.Ingredients.Select(x =>
            new Ingredient()
            {
                Amount = x.Amount,
                Product = new Product()
                {
                    Name = x.Product.Name,
                },
                UnitOfMeasurement = x.UnitOfMeasurement,
            }).ToList();

        var steps = recipeDto.Steps.Select(x => new RecipeStep()
        {
            Description = x.Description,
        }).ToList();
        var recipe = await _recipeRepository.CreateRecipe(new Recipe()
        {
            Name = recipeDto.Name,
            Ingredients = ingredients,
            Steps = steps
        });

        return Ok(recipe);
    }

}