using System.Drawing.Drawing2D;
using YummyProject.Models;

namespace YummyProject.ViewModels
{
    public class MealViewModel
    {
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Area> Areas { get; set; } = new List<Area>();
        public List<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
    }
}
