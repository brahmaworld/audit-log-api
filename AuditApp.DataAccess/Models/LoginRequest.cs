using System;
using System.Collections.Generic;
using System.Text;

namespace AuditApp.DataAccess.Models
{
    public class LoginRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
