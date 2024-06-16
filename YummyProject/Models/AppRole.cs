using Microsoft.AspNetCore.Identity;

namespace YummyProject.Models
{
    public class AppRole : IdentityRole<int>
    {
        public List<AppUserRole> UserRoles { get; set; }

    }
}
