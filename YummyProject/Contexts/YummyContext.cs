using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YummyProject.Models;

namespace YummyProject.Contexts
{
    public class YummyContext : IdentityDbContext<
            AppUser,
            AppRole,
            int,
            IdentityUserClaim<int>,
            AppUserRole,
            IdentityUserLogin<int>,
            IdentityRoleClaim<int>,
            IdentityUserToken<int>

        >
    {
        /**
         * public YummyContext()
        {
            
        }
        */
        public YummyContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>()
             .HasKey(ur => new { ur.UserId, ur.RoleId });

            builder
                .Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder
                .Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set;}
        public virtual DbSet<MealIngredient> MealIngredients { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
    }
}
