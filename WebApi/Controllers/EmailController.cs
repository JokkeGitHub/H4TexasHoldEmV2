using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        [HttpPost]
        [Route("sendemail")]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jokkesdummymail@gmail.com"));
            email.To.Add(MailboxAddress.Parse("joac3146@zbc.dk"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("jokkesdummymail@gmail.com", "annkmqtqqxvalncn");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
