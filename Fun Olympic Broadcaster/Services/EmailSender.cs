using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.Extensions.Options;

namespace Fun_Olympic_Broadcaster.Services
{
    public class EmailSender : IEmailSender
    {
        //private readonly IOptions<SMTPConfigModel> smtpConfig;
        //public EmailSender(IOptions<SMTPConfigModel> smtpSetting)
        //{
        //    this.smtpConfig = smtpSetting;

        //}
        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{

        //    MailMessage message = new MailMessage()
        //    {
        //        Body = htmlMessage,
        //        Subject = subject,
        //        From = new MailAddress("sahritik73@gmail.com", "Fun Olympic"),



        //    };
        //    message.To.Add(email);
        //    //------------With no Display Name in Email-------------/////
        //    //var message = new MailMessage(from,
        //    //   to,
        //    //   subject,
        //    //   body);





        //    using (var emailClient = new SmtpClient(smtpConfig.Value.Host, smtpConfig.Value.Port))
        //    {
        //        emailClient.Credentials = new NetworkCredential(
        //            smtpConfig.Value.UserName,
        //            smtpConfig.Value.Password);

        //        await emailClient.SendMailAsync(message);

        //    }
        //}
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
