using DepoCompApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DepoCompApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase 
    {
        
        private readonly EmployeeContext _employee;
        public EmployeeController( EmployeeContext employee)
        {
            _employee = employee;

        }
        [HttpPost("Add")]
        public async Task<ActionResult<List<Employee>>> Add(Employee employee)
        {


            _employee.Employee.Add(_employee);
            await _employee.SaveChangesAsync();

            return Ok(await _employee.Employee.ToListAsync());
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            var employeeContext = await _employee.Employee.FindAsync(employee.id);
            if (employeeContext == null)
                return BadRequest("Employee not found");


            employeeContext.name = employee.name;



            await _employee.SaveChangesAsync();

            return Ok(await _employee.Employee.ToListAsync());
        }




        [HttpDelete("Delete")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmployees = await _employee.Employee.FindAsync(id);
            if (dbEmployees == null)
                return BadRequest("Employee not found");

      
            _employee.Employee.Remove(dbEmployees);
            await _employee.SaveChangesAsync();

            return Ok(await _employee.Employee.ToListAsync());
        }
    }
}
