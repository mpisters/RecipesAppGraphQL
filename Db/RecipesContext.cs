using Microsoft.EntityFrameworkCore;
using RecipesApp.Domain;

namespace RecipesApp.Db;

public class RecipesContext : DbContext
{
    private IConfiguration Configuration { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Product> Products { get; set; }

    public RecipesContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DbConnection") ?? throw new InvalidOperationException());
}