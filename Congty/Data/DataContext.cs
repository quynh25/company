using Congty.Models;
using Microsoft.EntityFrameworkCore;

namespace Congty.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Center> Centers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff>Staffs { get; set; } 
    }
}
