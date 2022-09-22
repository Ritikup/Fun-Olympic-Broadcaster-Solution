using System.Net.Mail;

namespace Fun_Olympic_Broadcaster.Services
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}