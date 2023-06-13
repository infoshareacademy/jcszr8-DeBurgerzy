using Microsoft.AspNetCore.Mvc;
using ParcelDistributionCenter.Logic.Services.IServices;

namespace ParcelDistributionCenter.Report.Controllers
{
    [Route("reports/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            _emailService.SendEmail(body);
            return Ok();
        }
    }
}