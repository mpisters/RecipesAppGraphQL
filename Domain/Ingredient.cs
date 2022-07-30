using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApp.Domain;

public class Ingredient
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public float Amount { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}