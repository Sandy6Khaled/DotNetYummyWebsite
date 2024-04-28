using YummyProject.Models;

namespace YummyProject.Repositories.Interfaces
{
    public interface IMealRepo
    {
        public List<Meal> GetMeals();
        public Meal GetMealById(int id);
        public Meal GetMealByName(string name);
        public List<Meal> GetMealsByFirstLetter(char firstChar);
        public List<Meal> GetMealsOnArea(string areaName);
        public List<Meal> GetMealsOnCategory(int CategoryId);
    }
}
