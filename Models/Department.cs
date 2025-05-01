namespace MVC02.Models
{
    public class Department
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }

        List<Instructor> Instructors = new List<Instructor>();
        List<Course> Courses = new List<Course>();
        List<Trainee> Trainees = new List<Trainee>();
    }
}
