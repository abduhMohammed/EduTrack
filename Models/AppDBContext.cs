using Microsoft.EntityFrameworkCore;

namespace MVC02.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base()
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<crsResult> crsResult { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=HP;Initial Catalog=MVC_Day02_Task;" +
                "Integrated Security=True;Encrypt=False;" +
                "Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
