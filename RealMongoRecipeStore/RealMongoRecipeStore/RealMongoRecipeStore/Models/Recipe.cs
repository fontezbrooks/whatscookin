using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealMongoRecipeStore.Models;

public class Recipe
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? _id { get; set; } = null!;
	[BsonElement("vegetarian")]
	public bool Vegetarian { get; set; }
	[BsonElement("vegan")]
	public bool Vegan { get; set; }
	[BsonElement("glutenFree")]
	public bool GlutenFree { get; set; }
	[BsonElement("dairyFree")]
	public bool DairyFree { get; set; }
	[BsonElement("veryHealthy")]
	public bool VeryHealthy { get; set; }
	[BsonElement("cheap")]
	public bool Cheap { get; set; }
	[BsonElement("veryPopular")]
	public bool VeryPopular { get; set; }
	[BsonElement("sustainable")]
	public bool Sustainable { get; set; }
	[BsonElement("weightWatcherSmartPoints")]
	public int WeightWatcherSmartPoints { get; set; }
	[BsonElement("gaps")]
	public string Gaps { get; set; }  = null!;
	[BsonElement("lowFodmap")]
	public bool LowFodmap { get; set; }
	[BsonElement("aggregateLikes")]
	public int AggregateLikes { get; set; }
	[BsonElement("spoonacularScore")]
	public double SpoonacularScore {get; set; }
	[BsonElement("healthScore")]
	public double HealthScore { get; set; }
	[BsonElement("pricePerServing")]
	public double PricePerServing { get; set; }
	[BsonElement("extendedIngredients")]
	public NestedElement[] ExtendedIngredients { get; set; } = null!;
	[BsonElement("id")]
	[System.Text.Json.Serialization.JsonIgnore] 
	public int id { get; set; }
	[BsonElement("title")]
	public string Title { get; set; } = null!;
	[BsonElement("readyInMinutes")]
	public int ReadyInMinutes { get; set; }
	[BsonElement("servings")]
	public int Servings { get; set; }
	[BsonElement("sourceUrl")]
	public string SourceUrl { get; set; } = null!;
	[BsonElement("image")]
	public string Image { get; set; } = null!;
	[BsonElement("imageType")]
	public string ImageType { get; set; } = null!;
	[BsonElement("summary")]
	public string Summary { get; set; } = null!;
	[BsonElement("cuisines")]
	public string[] Cuisines { get; set; } = null!;
	[BsonElement("dishTypes")]
	public string[] DishTypes { get; set; } = null!;
	[BsonElement("diets")]
	public string[] Diets { get; set; } = null!;
	[BsonElement("occasions")]
	public string[] Occasions { get; set; } = null!;
	[BsonElement("instructions")]
	public string Instructions { get; set; } = null!;
	[BsonElement("analyzedInstructions")]
	[System.Text.Json.Serialization.JsonIgnore] 
	public BsonDocument[] AnalyzedInstructions { get; set; } = null!;
	[BsonElement("sourceName")]
	public string SourceName { get; set; } = null!;
	[BsonElement("creditsText")]
	public string CreditsText { get; set; }  = null!;
	[BsonElement("originalId")]
	public string OriginalId { get; set; } = null!;
	[BsonElement("spoonacularSourceUrl")]
	public string SpoonacularSourceUrl { get; set; } = null!;
}

[BsonIgnoreExtraElements]
public class NestedElement
{
	[BsonElement("aisle")] 
	public string Aisle { get; set; } = null!;
	[DataMember]
	[BsonElement("id")] 
	public int Id { get; set; }
	[BsonElement("image")] 
	public string Image { get; set; } = null!;
	[BsonElement("consistency")] 
	public string Consistency { get; set; } = null!;
	[BsonElement("name")] 
	public string Name { get; set; } = null!;
	[BsonElement("nameClean")] 
	public string NameClean { get; set; } = null!;
	[BsonElement("original")] 
	public string Original { get; set; } = null!;
	[BsonElement("originalName")] 
	public string OriginalName { get; set; } = null!;
	[BsonElement("amount")] 
	public double Amount { get; set; }
	[BsonElement("unit")] 
	public string Unit { get; set; } = null!;
	[BsonElement("meta")] 
	[System.Text.Json.Serialization.JsonIgnore]
	public string[] Meta { get; set; } = null!;
	[BsonElement("measures")] 
	[System.Text.Json.Serialization.JsonIgnore]
	public BsonDocument Measures { get; set; } = null!;
}