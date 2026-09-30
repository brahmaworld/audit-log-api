using Microsoft.AspNetCore.Mvc;
using AuditApp.DataAccess.Entities;
using AuditApp.Emp.Service.IServices;

namespace AuditApp.Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeResponse>>> GetAll()
        {
            var employees = await employeeService.GetAllAsync();
            return Ok(employees.Select(ToResponse).ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeResponse>> GetById(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);
            return employee is null ? NotFound() : Ok(ToResponse(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> Create(
            [FromBody] CreateEmployeeRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                Email = request.Email,
                Password = request.Password
            };

            var createdEmployee = await employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, ToResponse(createdEmployee));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateEmployeeRequest request)
        {
            var employee = await employeeService.GetByIdAsync(id);
            if (employee is null)
            {
                return NotFound();
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Gender = request.Gender;

            if (!await employeeService.UpdateAsync(employee))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await employeeService.DeleteAsync(id)
                ? NoContent()
                : NotFound();
        }

        private static EmployeeResponse ToResponse(Employee employee) =>
            new(employee.Id, employee.FirstName, employee.LastName, employee.Gender, employee.Email);
    }

    public sealed record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string Gender,
        string Email,
        string Password);

    public sealed record UpdateEmployeeRequest(string FirstName, string LastName, string Gender);

    public sealed record EmployeeResponse(int Id, string FirstName, string LastName, string Gender, string Email);
}
