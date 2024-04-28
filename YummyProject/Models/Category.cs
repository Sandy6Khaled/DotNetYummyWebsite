using System.ComponentModel.DataAnnotations;

namespace YummyProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? strCategory { get; set; }
        public string? strCategoryThumb { get; set; }
        public string? strCategoryDescription { get; set; }
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();

    }
}
/*{
      "idCategory": "1",
      "strCategory": "Beef",
      "strCategoryThumb": "https://www.themealdb.com/images/category/beef.png",
      "strCategoryDescription": "Beef is the culinary name for meat from cattle, particularly skeletal muscle. Humans have been eating beef since prehistoric times.[1] Beef is a source of high-quality protein and essential nutrients.[2]"
    }*/