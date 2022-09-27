using Microsoft.AspNetCore.Identity.UI.Services;

namespace Fun_Olympic_Broadcaster.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;        }
    }
}
