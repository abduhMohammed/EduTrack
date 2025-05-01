using MVC02.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC02.ViewModel
{
    public class InstDeptCourseViewModel
    {
        public int id { get; set; }

        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public int DeptartmentID { get; set; }
        public List<Department>? DeptList { get; set; }
        public int CourseID { get; set; }
        public List<Course>? CourseList { get; set; }
    }
}
