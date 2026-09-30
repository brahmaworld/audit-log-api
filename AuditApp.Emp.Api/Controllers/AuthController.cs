using AuditApp.DataAccess.Models;
using AuditApp.Emp.Service.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuditApp.Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest);
            return Ok(new { data = result });
        }

        [HttpPost("register")]  
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            return Ok(new { message = "Registration successful" });
        }
    }
}
