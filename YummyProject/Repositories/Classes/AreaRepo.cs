using YummyProject.Contexts;
using YummyProject.Models;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class AreaRepo : IAreaRepo
    {
        private readonly YummyContext _context;

        public AreaRepo(YummyContext context)
        {
            _context = context;
        }
        public List<Area> GetAreas()
        {
            return _context.Areas.ToList();
        }
    }
}
