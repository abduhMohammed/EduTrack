using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MVC02.Models
{
    public class Course
    {
        public int id { get; set; }
        [Display(Name = "Course Name")]
        [DataType(DataType.Text)]
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        [UniqueName]
        public string? Name { get; set; }

        [Required]
        [Range(minimum:50, maximum:100)]
        public int Degree { get; set; }

        [Required]
        [Remote(action:"Check", controller:"Course"
            , AdditionalFields = "Degree"
            , ErrorMessage = "Must less than Degree")]
        public int minDegree { get; set; }


        List<Instructor> instructors = new List<Instructor>();

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        List<crsResult> crsResults = new List<crsResult>();
    }
}
