using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fun_Olympic_Broadcaster.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirsName { get; set; }
        public string LastName { get; set; }
        [MaxLength(90, ErrorMessage = "Length cannot be longer than 90 characters.")]

        public string City{ get; set; }
        [MaxLength(90, ErrorMessage = "Length cannot be longer than 90 characters.")]

        public string Country { get; set; }

        public DateTime DOB { get; set; }
    }
}
