namespace AuditApp.Emp.Service.Services
{
    using AuditApp.DataAccess.DataContext;
    using AuditApp.DataAccess.Entities;
    using AuditApp.Emp.Service.IServices;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService(EmpAuditPgsqlDbContext dbContext) : IEmployeeService
    {
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await dbContext.Employees
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            return dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(employee => employee.Id == id);
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            var existingEmployee = await dbContext.Employees
                .FirstOrDefaultAsync(existing => existing.Id == employee.Id);

            if (existingEmployee is null)
            {
                return false;
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Gender = employee.Gender;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await dbContext.Employees
            .FirstOrDefaultAsync(existing => existing.Id == id);

            if (employee is null)
            {
                return false;
            }

            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}