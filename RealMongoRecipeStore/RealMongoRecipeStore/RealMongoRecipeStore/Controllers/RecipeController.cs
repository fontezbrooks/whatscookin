using Microsoft.AspNetCore.Mvc;
using RealMongoRecipeStore.Models;
using RealMongoRecipeStore.Services;

namespace RealMongoRecipeStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
	private readonly RecipeService _recipeService;

	public RecipeController(RecipeService recipeService) => 
		_recipeService = recipeService;

	[HttpGet]
	public async Task<List<Recipe>> Get() => 
		await _recipeService.GetAsync();

	[HttpGet("{id:length(24)}")]
	public async Task<ActionResult<Recipe>> Get(string id)
	{
		var recipe = await _recipeService.GetAsync(id);

		if (recipe is null)
		{
			return NotFound();
		}

		return recipe;
	}
}