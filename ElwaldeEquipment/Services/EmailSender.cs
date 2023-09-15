using ElwaldeEquipment.Entities;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace ElwaldeEquipment.Services
{
    public class EmailSender:IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public Task SendEmailAsync(string email, string subject,string message)
        {
            var credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);

            // Mail message
            var mail = new MailMessage()
            {
                From = new MailAddress(_emailSettings.Sender, _emailSettings.SenderName),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mail.To.Add(new MailAddress(email));
            using (var emailClient=new SmtpClient()   )
            {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                emailClient.Port = _emailSettings.MailPort;
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                emailClient.UseDefaultCredentials = false;
                emailClient.Host = _emailSettings.MailServer;
                emailClient.EnableSsl = true;
                
                emailClient.Credentials = credentials;
                emailClient.Send(mail);
            }
            return Task.CompletedTask;

        }
    }
}
