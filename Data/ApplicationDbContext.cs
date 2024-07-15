using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;
namespace EmployeeManager.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         public DbSet<Employee> Employeetbl { get; set; }
    }
}
