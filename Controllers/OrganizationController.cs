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
        private readonly DataContext _context;
        public OrganizationController(OrganizationContext organization, DataContext context)
        {
            _organization = organization;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Organization>>> Get()
        {

            return Ok(await _organization.Organization.ToListAsync());
        }



        
    }
}
