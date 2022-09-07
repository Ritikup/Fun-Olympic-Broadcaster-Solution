using Microsoft.AspNetCore.Identity;

namespace Fun_Olympic_Broadcaster.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
    }
}
