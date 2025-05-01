using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MVC02.Models
{
    public class Instructor
    {
        public int id { get; set; }
        
        [Display(Name= "Full Name")]
        [DataType(DataType.Text)]
        [Required]
        [UniqueName(Message ="Deblicated Name not be allowed")]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 Letter")]
        [MinLength(3, ErrorMessage = "Name must be greater than 2 Letter")]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"(\w+\.(jpg|png))", ErrorMessage = "Image must be jpg or png")]
        public string? Image { get; set; }

        [Required]
        [RegularExpression(@"(Alex|Assuit)", ErrorMessage = "Address must be Alex or Assuit")]
        public string? Address { get; set; }

        [Required]
        [Range(minimum:5000, maximum:20000, ErrorMessage = "Salary must me in range between 5000 and 20000")]
        public int Salary { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department Name")]
        public int DeptartmentID { get; set; }

        public Department Department { get; set; }

        [ForeignKey("Course")]
        [Display(Name = "Course Name")]
        public int CourseID { get; set; }

        public Course Course { get; set; }
    }
}