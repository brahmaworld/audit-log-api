using AuditApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditApp.DataAccess.DataContext
{
    public class EmpAuditPgsqlDbContext : DbContext
    {
        public EmpAuditPgsqlDbContext(DbContextOptions<EmpAuditPgsqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
