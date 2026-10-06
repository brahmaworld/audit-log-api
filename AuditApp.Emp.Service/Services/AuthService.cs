using AuditApp.DataAccess.DataContext;
using AuditApp.DataAccess.Models;
using AuditApp.Emp.Service.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AuditApp.Emp.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly EmpAuditPgsqlDbContext _EmpAuditDbContext;
        public AuthService(EmpAuditPgsqlDbContext empAuditDbContext)
        {
            _EmpAuditDbContext = empAuditDbContext;
        }
        public async Task<string> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _EmpAuditDbContext.Employees.FirstOrDefaultAsync(u => u.Email == loginRequest.Username && u.Password == loginRequest.Password);
            if (user == null)
            {
                return "Invalid username or password";
            }
            var userDto = new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Email = user.Email
            };
            return JsonSerializer.Serialize(userDto);
        }

        public async Task<bool> RegisterAsync(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
