using System.ComponentModel.DataAnnotations;

namespace YummyProject.Models
{
    public class Client:AppUser
    {
        [DataType(DataType.Date)]
        public DateOnly? DOB { get; set; }
    }
}
