using Microsoft.AspNetCore.Mvc;
using AuditApp.DataAccess.Entities;
using AuditApp.Emp.Service.IServices;
using AuditApp.DataAccess.Models;

namespace AuditApp.Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var employees = await employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var employee = await employeeService.GetByIdAsync(id);
            return employee is null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] EmployeeRequest request)
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
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] EmployeeRequest request)
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

    }

}
