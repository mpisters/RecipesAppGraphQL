namespace RecipesApp.Domain;

public class Ingredient
{
    public Product Product { get; set; }
    public float Amount { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}