using System;
using System.Collections.Generic;
using System.Text;

namespace AuditApp.DataAccess.Models
{
    public class EmployeeResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
