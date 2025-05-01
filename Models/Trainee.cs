using System.ComponentModel.DataAnnotations.Schema;

namespace MVC02.Models
{
    public class Trainee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        List<crsResult> crsResults = new List<crsResult>();
    }
}
