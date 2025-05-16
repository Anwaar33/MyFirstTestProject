using Microsoft.EntityFrameworkCore;
using MyFirstTestProject.Classes;
namespace MyFirstTestProject
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<PersonData> People { get; set; }






    }
}
