using RealMongoRecipeStore.Models;
using RealMongoRecipeStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		policy =>
		{
			policy.WithOrigins("http://localhost:3000", "http://localhost:19006", "http://localhost:19002");
		});
});

builder.Services.Configure<RecipeDatabaseSettings>(
	builder.Configuration.GetSection("RecipeDatabase"));

builder.Services.AddSingleton<RecipeService>();

builder.Services.AddControllers().AddJsonOptions(
	options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();