using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Model.DTOs;

namespace ParcelDistributionCenter.Report.Controllers
{
    [ApiController]
    [Route("reports/[controller]")]
    public class UsersController : ControllerBase
    {
        // TODO: To be changed
        [HttpPost]
        public IActionResult CreateTransfer(PackageAddingDurationDto packageAddingDurationDto)
        {
            packageAddingDurationDto.Duration.ToString();
            return Ok();
        }

        // TODO: To be changed
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}