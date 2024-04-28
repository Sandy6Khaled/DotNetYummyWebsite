using Microsoft.EntityFrameworkCore;
using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class MealIngredientRepo : IMealIngredientRepo
    {
        private readonly YummyContext _context;

        public MealIngredientRepo(YummyContext context)
        {
            _context = context;
        }
        public List<MealIngredient> GetMealIngredients(int id)
        {
            return _context.MealIngredients.Include(mi => mi.Ingredient).Where(m => m.MealId == id).ToList();
        }
        //public List<MealIngredient> GetMealPerIngredient(List<Ingredient> ingredients)
        //{
        //    foreach (var ing in ingredients)
        //    {

        //        return _context.MealIngredients.Include(m => m.Ingredient).Where(mi => mi.IngredientId == ing.Id).ToList();
        //    }
        //    return
        //}
        public List<Meal> GetMealsWithIngredients(List<Ingredient> ingredients)
        {
            // Initialize a list to store meal IDs
            List<int> mealIds = null;

            foreach (var ing in ingredients)
            {
                // Retrieve meal IDs containing the current ingredient
                var mealIdsWithIngredient = _context.MealIngredients
                    .Where(mi => mi.IngredientId == ing.Id)
                    .Select(mi => mi.MealId)
                    .ToList();

                // If it's the first ingredient, initialize the list with meal IDs
                if (mealIds == null)
                {
                    mealIds = mealIdsWithIngredient;
                }
                else
                {
                    // Take the intersection of current meal IDs and meal IDs with current ingredient
                    mealIds = mealIds.Intersect(mealIdsWithIngredient).ToList();
                }

                // If no meals found for any ingredient, return empty list
                if (mealIds.Count == 0)
                {
                    return new List<Meal>();
                }
            }

            // Retrieve meals with meal IDs found
            var meals = _context.Meals
                .Where(m => mealIds.Contains(m.Id))
                .ToList();

            return meals;
        }
    }
}
