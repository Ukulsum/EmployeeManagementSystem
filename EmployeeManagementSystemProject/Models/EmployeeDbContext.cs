using EmployeeManagementSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemProject.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Religion> Religions { get; set; }
    }
}
