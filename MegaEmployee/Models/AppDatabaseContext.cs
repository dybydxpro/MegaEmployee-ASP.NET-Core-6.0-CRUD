using Microsoft.EntityFrameworkCore;

namespace MegaEmployee.Models
{
    public class AppDatabaseContext: DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
