using MVC02.Models;

namespace MVC02.Repository
{
    public class CourseRepository
    {
        AppDBContext context;
        CourseRepository()
        {
            context = new AppDBContext();
        }
        //CRUD
        public void Add(Course obj)
        {
            //context.Course.Add(obj);
            context.Add(obj);
        }
        public void Update(Course obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Course obj = GetByID(id);
            context.Remove(obj);
        }
        public List<Course> GetAll()
        {
            return context.Course.ToList();
        }
        public Course GetByID(int id)
        {
            return context.Course.FirstOrDefault(i => i.id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
