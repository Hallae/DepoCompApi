using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DepoCompApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationDbContext _organization;
        private readonly EmployeeDbContext _employee;
        public OrganizationController(OrganizationDbContext _organization, EmployeeDbContext _employee)
        {
            EmployeeDbContext = _employee;
            OrganizationDbContext = _organization;
        }

    }
}
