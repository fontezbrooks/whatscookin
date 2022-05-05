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

	[HttpPost]
	public async Task<IActionResult> UpdateUserDb(string id)
	{
		await _recipeService.AddRecipeToUserDbAsync(id);

		return CreatedAtAction(nameof(Get), id);
	}

	[HttpDelete("{id:length(24)}")]
	public async Task<IActionResult> Delete(string id)
	{
		await _recipeService.GetUserRecipeAsync(id);

		await _recipeService.RemoveAsync(id);

		return NoContent();
	}
	
	[HttpGet("random")]
	public async Task<ActionResult<Recipe>> GetRandomRecipe() => 
		await _recipeService.GetRandomRecipeAsync();
}