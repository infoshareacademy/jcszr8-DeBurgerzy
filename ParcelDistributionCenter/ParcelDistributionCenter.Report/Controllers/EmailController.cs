using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace ParcelDistributionCenter.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("eula.cummings85@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("eula.cummings85@ethereal.email"));
            email.Subject = $"Report email{DateTime.Now}";
            email.Body = new TextPart(TextFormat.Html ) { Text = body};

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("eula.cummings85@ethereal.email", "Yv5XzEjNutBr12avm4");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
