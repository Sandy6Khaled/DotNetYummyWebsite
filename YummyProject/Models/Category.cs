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
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();//Navigational Property

    }
}