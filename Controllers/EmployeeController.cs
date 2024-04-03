using DepoCompApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using CsvHelper;
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
        [HttpGet("Export CSV")]
        public async Task<IActionResult> ExportApplications()
        {
            var applications = await _context.Employee.ToListAsync();

            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(applications);
                await streamWriter.FlushAsync();
                memoryStream.Position = 0;

                return File(memoryStream.ToArray(), "text/csv", "applications.csv");
            }
        }
        [HttpPost("Import CSV")]
        public async Task<IActionResult> ImportCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not selected");



            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Employee>();
                    foreach (var record in records)
                    {
                        // Process each record here
                        // For example, add to the database or perform other operations
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // Return a generic error message to the client
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the file.");
            }

            return Ok(await _context.Employee.ToListAsync());
        }

    }


}
