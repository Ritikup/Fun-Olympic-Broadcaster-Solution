using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Fun_Olympic_Broadcaster.Pages
{
    public class VideoPlayerModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly ApplicationDbContext _context;
        [BindProperty]
        public string MyUser { get; set; }  
        
        [BindProperty]
        public List<SelectListItem> Users { get; set; }
        public VideoPlayerModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public string link { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var videoUpoad = await _context.VideoUpoads
                .FirstOrDefaultAsync(m => m.Id == id);
             link = videoUpoad.videolink;
            Users = _userManager.Users.ToList().Select(a => new SelectListItem { Text = a.UserName, Value = a.UserName })
                   .OrderBy(s => s.Text).ToList();
            MyUser = User.Identity.Name;
            return Page();

        }
    }
}
