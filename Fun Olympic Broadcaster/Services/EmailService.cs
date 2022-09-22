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
       
         
        public async Task SendAsync( string to, string subject, string body)
        {


            MailMessage message = new MailMessage()
            {
                Body = body,
                Subject = subject,
                From = new MailAddress("sahritik73@gmail.com", "Fun Olympic"),

                

            };
            message.To.Add(to);
            //------------With no Display Name in Email-------------/////
            //var message = new MailMessage(from,
            //   to,
            //   subject,
            //   body);


                          


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
