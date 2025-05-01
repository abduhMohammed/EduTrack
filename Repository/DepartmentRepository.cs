using MVC02.Models;

namespace MVC02.Repository
{
    public class DepartmentRepository
    {
        AppDBContext context;
        DepartmentRepository()
        {
            context = new AppDBContext();
        }
        //CRUD
        public void Add(Department Dept)
        {
            //context.Department.Add(Dept);
            context.Add(Dept);
        }
        public void Update(Department Dept)
        {
            context.Update(Dept);
        }
        public void Delete(int id)
        {
            Department Dept = GetByID(id);
            context.Remove(Dept);
        }
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetByID(int id)
        {
            return context.Department.FirstOrDefault(i => i.id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
