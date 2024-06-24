namespace YummyProject.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string strIngredient { get; set; }
        public ICollection<MealIngredient> Ingredients { get; set; } //Navigational Property
    }
}