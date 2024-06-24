using System.ComponentModel.DataAnnotations;

namespace YummyProject.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }
        public string strArea { get; set; }
        public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();//Navigational Property
    }
}
