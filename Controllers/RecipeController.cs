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
    private RecipesContext _recipeContext;
    public RecipeController(RecipesContext dbContext)
    {
        _recipeContext = dbContext;
    }
    [HttpPost]
    public async Task<OkResult> CreateRecipe([FromBody] CreateRecipeDto recipeDto)
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
        var recipe = _recipeContext.Recipes.Add(new Recipe()
        {
            Name = recipeDto.Name,
            Ingredients = ingredients,
            Steps = steps
        });
        await _recipeContext.SaveChangesAsync();
        return Ok();
    }

}