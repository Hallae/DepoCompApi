using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using DepoCompApi.Data;


namespace DepoCompApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationContext _organization;
        private readonly EmployeeContext _employee;
        public OrganizationController(OrganizationContext organization, EmployeeContext employee)
        {
            _organization = organization;
            _employee = employee;
        }


        [HttpGet]
        public async Task<ActionResult<List<Organization>>> Get()
        {

            return Ok(await _organization.Organization.ToListAsync());
        }



        
    }
}
