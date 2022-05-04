using RealMongoRecipeStore.Models;
using RealMongoRecipeStore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", policy =>
	{
		policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();