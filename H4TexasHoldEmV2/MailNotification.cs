using System.Net;
using System.Net.Mail;

namespace H4TexasHoldEmV2
{
    public class MailNotification
    {
        private string Message { get; set; } = "";

        public void SendMail()
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("jokkesdummymail@gmail.com");
                    mail.To.Add("jokkesdummymail@gmail.com");
                    mail.Subject = "Sending Mail, Blazor Test";
                    mail.Body = "<h1> This is a mail body <h1>";
                    mail.IsBodyHtml= true;

                    using (SmtpClient smtp = new SmtpClient ("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("jokkesdummymail@gmail.com", "annkmqtqqxvalncn");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        Message = "Mail Sent";
                        Console.WriteLine(Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
