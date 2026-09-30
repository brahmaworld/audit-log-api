using AuditApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuditApp.Emp.Service.IServices
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest loginRequest);
        Task<bool> RegisterAsync(RegisterRequest registerRequest);
    }
}
