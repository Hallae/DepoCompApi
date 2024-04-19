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
       


        [HttpGet("Organization")]
        public ActionResult<IEnumerable<Organization>> GetOrganization()
        {

            var organization = new List<Organization>
            {
               new Organization{ Name = "Orbiters", LegalAddress = "123 Main St, Anytown, USA", ActualAdress = "123 Main St, Anytown, USA" }


            };
            return organization;
        }

      


    }
}
