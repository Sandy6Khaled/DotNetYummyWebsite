using Microsoft.EntityFrameworkCore;
using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class MealRepo : IMealRepo
    {
        private readonly YummyContext _context;

        public MealRepo(YummyContext context)
        {
            _context = context;
        }
        public Meal GetMealById(int id)
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(MI => MI.MealIngredients).FirstOrDefault(MI => MI.Id == id);
        }

        public Meal GetMealByName(string name)
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(MI => MI.MealIngredients).FirstOrDefault(M => M.strMeal == name);
        }

        public List<Meal> GetMeals()
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(MI => MI.MealIngredients).ToList();
        }

        public List<Meal> GetMealsByFirstLetter(char firstChar)
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(M => M.MealIngredients).Where(m => m.strMeal.StartsWith(firstChar.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Meal> GetMealsOnArea(string areaName)
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(M => M.MealIngredients).Where(m => m.Area.strArea == areaName).ToList();
        }

        public List<Meal> GetMealsOnCategory(int CategoryId)
        {
            return _context.Meals.Include(m => m.Category).Include(M => M.Area).Include(M => M.MealIngredients).Where(m => m.Category.Id == CategoryId).ToList();
        }
    }
}
