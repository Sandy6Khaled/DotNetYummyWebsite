using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YummyProject.Models
{
    public class MealIngredient
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Meal))]
        public int MealId { get; set; }
        public virtual Meal? Meal { get; set; } //Navigational Property

        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; } //Navigational Property

        public string Measure { get; set; }
    }
}
