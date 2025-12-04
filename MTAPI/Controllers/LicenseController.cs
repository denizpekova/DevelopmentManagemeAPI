using BusinessLayer.Abstrack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseServices licenseServices;
        public LicenseController(ILicenseServices licenseServices)
        {
            this.licenseServices = licenseServices;
        }

        [HttpGet]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = licenseServices.GetAllLicenses();
            return Ok(result);

        }
    }
}
