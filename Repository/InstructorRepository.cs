using MVC02.Models;

namespace MVC02.Repository
{
    //Write PL Here in this Repository
    public class InstructorRepository
    {
        AppDBContext context;
        public InstructorRepository()
        {
            context = new AppDBContext();
        }
        //CRUD ==> Create - Read - Update - Delete --> Main Method Structure
        public void Add(Instructor inst)
        {
            //context.Instructor.Add(inst);
            context.Add(inst);
        }
        public void Update(Instructor inst)
        {
            context.Update(inst);
        } 
        public void Delete(int id)
        {
            Instructor inst = GetByID(id);
            context.Remove(inst);
        }
        public List<Instructor> GetAll()
        {
            return context.Instructor.ToList();
        }
        public Instructor GetByID(int id)
        {
            return context.Instructor.FirstOrDefault(i => i.id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}