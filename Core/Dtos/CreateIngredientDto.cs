using System.ComponentModel.DataAnnotations;
using RecipesApp.Domain;

namespace RecipesApp.Core.Dtos;

public class CreateIngredientDto
{

        [Required]
        public CreateProductDto Product { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
}