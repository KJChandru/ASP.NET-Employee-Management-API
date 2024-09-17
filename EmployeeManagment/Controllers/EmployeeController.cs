using EmployeeManagment.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagment.Repositories;

namespace EmployeeManagment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
        {
            var allemployee = await _employeeRepository.GetAllAsync();
            return Ok(allemployee);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            await _employeeRepository.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult>DeleteEmployeeById(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeById(int id,Employee employee)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest();
            }

            if(id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id },employee);
        }
        
    }
}
