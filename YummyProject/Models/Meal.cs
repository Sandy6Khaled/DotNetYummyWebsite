using System.ComponentModel.DataAnnotations.Schema;

namespace YummyProject.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string? strMeal { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }//Foriegn Key
        public Category? Category { get; set; }//Navigational property
        [ForeignKey(nameof(Area))]
        public int? AreaId { get; set; }//Foriegn Key
        public Area? Area { get; set; }//Navigational property
        public string? strInstructions { get; set; }
        public string? strMealThumb { get; set; }
        public string? strTags { get; set; }
        public string? strYoutube { get; set; }
        public string? strSource { get; set; }
        public virtual ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();//Navigational property
    }
}