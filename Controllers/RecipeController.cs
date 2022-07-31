using Microsoft.AspNetCore.Mvc;
using RecipesApp.Core;
using RecipesApp.Core.Dtos;
using RecipesApp.Db;

namespace RecipesApp.Controllers;

[Route("[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private IRecipeRepository _recipeRepository;
    public RecipeController(IRecipeRepository repository)
    {
        _recipeRepository = repository;
    }


    [HttpPost]
    public async Task<OkObjectResult> CreateRecipe([FromBody] CreateRecipeDto recipeDto)
    {

        var recipe = RecipeConverter.CreateRecipeFromDto(recipeDto);
        var savedRecipe = await _recipeRepository.CreateRecipe(recipe);
        return Ok(recipe);
    }

}