using Microsoft.EntityFrameworkCore;
using AuditApp.DataAccess.Entities;

namespace AuditApp.DataAccess.DataContext
{
    public class EmpAuditDbContext : DbContext
    {
        public EmpAuditDbContext(DbContextOptions<EmpAuditDbContext> options)
         : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}