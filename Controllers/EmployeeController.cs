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

        private readonly DataContext _context;
        public EmployeeController(OrganizationContext organization, DataContext context)
        {
            
            _context = context;
        }

        [HttpGet("EmployeeList")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.Employee.ToListAsync());
        }

         [HttpPost("Add")]
        public async Task<ActionResult<List<Employee>>> Add(Employee context)
        {


        _context.Employee.Add(context);
        await _context.SaveChangesAsync();

            return Ok(await _context.Employee.ToListAsync());
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            var dbEmployees = await _context.Employee.FindAsync(employee.id);
            if (dbEmployees == null)
                return BadRequest("Employee not found");

            dbEmployees.id = employee.id;
            dbEmployees.name = employee.name;
            dbEmployees.PassportNumber= employee.PassportNumber;
            dbEmployees.PassportSeries= employee.PassportSeries;
            dbEmployees.DateOfBirth= DateTime.Now;



            await _context.SaveChangesAsync();

            return Ok(await _context.Employee.ToListAsync());
        }




        [HttpDelete("Delete")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmployees = await _context.Employee.FindAsync(id);
            if (dbEmployees == null)
                return BadRequest("Employee not found");

      
            _context.Employee.Remove(dbEmployees);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employee.ToListAsync());
        }
    }
   
    
}
