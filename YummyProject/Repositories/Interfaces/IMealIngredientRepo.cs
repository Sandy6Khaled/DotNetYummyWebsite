using YummyProject.Models;

namespace YummyProject.Repositories.Interfaces
{
    public interface IMealIngredientRepo
    {
        public List<MealIngredient> GetMealIngredients(int id);
        public List<Meal> GetMealsWithIngredients(List<Ingredient> ingredients);
    }
}
