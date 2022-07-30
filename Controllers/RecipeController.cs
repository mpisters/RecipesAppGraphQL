using Microsoft.AspNetCore.Mvc;
using RecipesApp.Controllers.Dtos;
using RecipesApp.Core;
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

        var recipe = RecipeHelper.CreateRecipeFromDto(recipeDto);
        var savedRecipe = await _recipeRepository.CreateRecipe(recipe);
        return Ok(recipe);
    }

}