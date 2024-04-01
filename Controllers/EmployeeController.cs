using DepoCompApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
