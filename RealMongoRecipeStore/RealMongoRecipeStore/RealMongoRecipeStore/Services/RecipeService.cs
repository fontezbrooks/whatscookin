using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RealMongoRecipeStore.Models;

namespace RealMongoRecipeStore.Services;

public class RecipeService
{
	private readonly IMongoCollection<Recipe> _recipeCollection;

	public RecipeService(IOptions<RecipeDatabaseSettings> recipeDatabaseSettings)
	{
		var mongoClient = new MongoClient(
			recipeDatabaseSettings.Value.ConnectionString);

		var mongoDatabase = mongoClient.GetDatabase(
			recipeDatabaseSettings.Value.DatabaseName);

		_recipeCollection = mongoDatabase.GetCollection<Recipe>(
			recipeDatabaseSettings.Value.RecipeCollectionName);

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

	public async Task CreateAsync(Recipe newRecipe) => 
		await _recipeCollection.InsertOneAsync(newRecipe);

	public async Task UpdateAsync(string id, Recipe updatedBook) =>
		await _recipeCollection.ReplaceOneAsync(x => x._id == id, updatedBook);
	
	public async Task RemoveAsync(string id) =>
		await _recipeCollection.DeleteOneAsync(x => x._id == id);
}