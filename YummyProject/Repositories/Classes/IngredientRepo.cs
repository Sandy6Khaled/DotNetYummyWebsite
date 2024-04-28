using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly YummyContext _context;

        public IngredientRepo(YummyContext context)
        {
            _context = context;
        }

        public List<Ingredient> GetAll()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetIngredient(int id)
        {
            return _context.Ingredients.Find(id);
        }

        public List<Ingredient> GetIngredients(int id)
        {
            return _context.Ingredients.Where(I => I.Id == id).ToList();
        }
    }
}
