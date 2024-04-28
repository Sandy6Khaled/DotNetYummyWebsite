using Microsoft.EntityFrameworkCore;
using YummyProject.Models;

namespace YummyProject.Contexts
{
    public class YummyContext : DbContext
    {
        /**
         * public YummyContext()
        {
            
        }
        */
        public YummyContext(DbContextOptions options):base(options)
        {
            
        }

        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set;}
        public virtual DbSet<MealIngredient> MealIngredients { get; set; }
    }
}
