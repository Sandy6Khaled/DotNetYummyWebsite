using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMealRepo _mealRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMealIngredientRepo _mealIngredientRepo;
        private readonly IIngredientRepo _ingredientRepo;

        public HomeController(ILogger<HomeController> logger,IMealRepo mealRepo,ICategoryRepo categoryRepo, IMealIngredientRepo mealIngredientRepo,IIngredientRepo ingredientRepo)
        {
            _logger = logger;
            _mealRepo = mealRepo;
            _categoryRepo = categoryRepo;
            _mealIngredientRepo = mealIngredientRepo;
            _ingredientRepo = ingredientRepo;
        }
        
        public IActionResult Index()
        {
            var Meals = _mealRepo.GetMeals();
            return View(Meals);
        }

        public IActionResult Privacy()
        {
            var Categories =_categoryRepo.GetCategories();
            return View(Categories);
        }

        public IActionResult IngFrm()
        {
            List<Ingredient> ing = _ingredientRepo.GetAll();
            return View(ing);
        }
        public IActionResult Ingredients(List<int> ingfrm)
        {
            List<Ingredient> ing = new List<Ingredient> ();
            foreach(var item in ingfrm)
            {
                var ingList = _ingredientRepo.GetIngredient(item);
                ing.Add(ingList);
            }
            
            var meals = _mealIngredientRepo.GetMealsWithIngredients(ing);
            return View(meals);
        }
        public IActionResult Details(int id)
        {
            var Meal = _mealRepo.GetMealById(id);
            ViewBag.Ing = _mealIngredientRepo.GetMealIngredients(id);
            return View(Meal);
        }
        public IActionResult GetMealsInCategories(int id)
        {
            var Meals = _mealRepo.GetMealsOnCategory(id);
            return View(Meals);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
