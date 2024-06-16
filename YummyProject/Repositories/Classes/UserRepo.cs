using YummyProject.Contexts;
using YummyProject.Repositories.Interfaces;

namespace YummyProject.Repositories.Classes
{
    public class UserRepo : IUserRepo
    {
        private readonly YummyContext _context;

        public UserRepo(YummyContext context) 
        {
            _context = context;
        }
        public bool EmailExist(string email)
        {
            return _context.AppUsers.Any(u => u.Email == email);
        }

        public bool UsernameExist(string username)
        {
            return _context.AppUsers.Any(u => u.UserName == username);
        }
    }
}
