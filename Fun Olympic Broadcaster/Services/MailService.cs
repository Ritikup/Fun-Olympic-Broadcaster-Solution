using Fun_Olympic_Broadcaster.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Fun_Olympic_Broadcaster.Services
{
    public class MailService
    {
        private readonly SMTPConfigModel _smtpConfigModel;
        public MailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfigModel = smtpConfig.Value;
        }

        private async Task SendEmail(string body,string to,string subject)
        {
            MailMessage message = new MailMessage()
            {
                Body = body,
                Subject = subject,
                From = new MailAddress("sahritik73@gmail.com", "Fun Olympic")

            };
            message.To.Add(to);

            NetworkCredential credential = new NetworkCredential(_smtpConfigModel.UserName, _smtpConfigModel.Password);

            SmtpClient smtpClient = new SmtpClient()
            {

                Host = _smtpConfigModel.Host,
                Port = _smtpConfigModel.Port
            };

           await smtpClient.SendMailAsync(message);
        
        
        }
    }
}
