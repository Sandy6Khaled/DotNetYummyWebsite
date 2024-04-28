using YummyProject.Models;

namespace YummyProject.Repositories.Interfaces
{
    public interface IIngredientRepo
    {
        public List<Ingredient> GetIngredients(int id);
        public List<Ingredient> GetAll();
        public Ingredient GetIngredient(int id);
    }
}
