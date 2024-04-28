using YummyProject.Models;

namespace YummyProject.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        public List<Category> GetCategories();
    }
}
