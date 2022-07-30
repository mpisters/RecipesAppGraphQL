using Microsoft.EntityFrameworkCore;
using RecipesApp.Db;
using RecipesApp.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RecipesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection") ?? string.Empty));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");
app.Run();