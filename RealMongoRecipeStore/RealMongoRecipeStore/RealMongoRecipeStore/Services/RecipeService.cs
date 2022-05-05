using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RealMongoRecipeStore.Models;

namespace RealMongoRecipeStore.Services;

public class RecipeService
{
	private readonly IMongoCollection<Recipe> _recipeCollection;

	private readonly IMongoCollection<Recipe> _userRecipeCollection;

	public RecipeService(IOptions<RecipeDatabaseSettings> recipeDatabaseSettings)
	{
		var mongoClient = new MongoClient(
			recipeDatabaseSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(
			recipeDatabaseSettings.Value.DatabaseName);

		_recipeCollection = mongoDatabase.GetCollection<Recipe>(
			recipeDatabaseSettings.Value.RecipeCollectionName);

		_userRecipeCollection =
			mongoDatabase.GetCollection<Recipe>(recipeDatabaseSettings.Value.UserRecipeCollectionName);
	}

	public async Task<List<Recipe>> GetAsync() =>
		await _recipeCollection.Find(_ => true).ToListAsync();

	public async Task<Recipe> GetRandomRecipeAsync()
	{
		var collections = await GetAsync();
		var random = new Random();
		var randomNumber = random.Next(0, collections.Count);
		return collections[randomNumber];
	}

	public async Task<Recipe?> GetAsync(string id) =>
		
		await _recipeCollection.Find(x => x._id == id).FirstOrDefaultAsync();

	public async Task<Recipe> GetUserRecipeAsync(string id) =>
		await _userRecipeCollection.Find(x => x._id == id).FirstOrDefaultAsync();

	public async Task AddRecipeToUserDbAsync(string id)
	{
		var thisRecipe = await _recipeCollection.Find(x => x._id == id).FirstOrDefaultAsync();
		await _userRecipeCollection.InsertOneAsync(thisRecipe);
	}

	public async Task CreateAsync(Recipe newRecipe) => 
		await _userRecipeCollection.InsertOneAsync(newRecipe);

	public async Task UpdateAsync(string id, Recipe recipe) =>
		await _recipeCollection.ReplaceOneAsync(x => x._id == id, recipe);
	
	public async Task RemoveAsync(string id) =>
		await _userRecipeCollection.DeleteOneAsync(x => x._id == id);
}