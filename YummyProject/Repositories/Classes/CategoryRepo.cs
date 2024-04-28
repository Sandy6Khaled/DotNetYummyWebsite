using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly YummyContext _context;

        public CategoryRepo(YummyContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
