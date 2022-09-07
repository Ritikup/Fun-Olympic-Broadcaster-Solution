using Fun_Olympic_Broadcaster.Models;
using Fun_Olympic_Broadcaster.Settings;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Fun_Olympic_Broadcaster.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptions<SMTPConfigModel> smtpConfig;
        public EmailService(IOptions<SMTPConfigModel> smtpSetting)
        {
            this.smtpConfig = smtpSetting;

        }
       
         
        public async Task SendAsync(string from, string to, string subject, string body)
        {
            var message = new MailMessage(from,
               to,
               subject,
               body
                );


            using (var emailClient = new SmtpClient(smtpConfig.Value.Host, smtpConfig.Value.Port))
            {
                emailClient.Credentials = new NetworkCredential(
                    smtpConfig.Value.UserName,
                    smtpConfig.Value.Password);

                await emailClient.SendMailAsync(message);

            }
        }
    }
}
