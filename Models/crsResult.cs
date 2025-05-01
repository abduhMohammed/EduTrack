using System.ComponentModel.DataAnnotations.Schema;

namespace MVC02.Models
{
    public class crsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course = new Course();

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public Trainee Trainee = new Trainee();
    }
}
