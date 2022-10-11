using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Fun_Olympic_Broadcaster.Pages
{
    public class LiveVideoPlayerModel : PageModel
    {


        private readonly ApplicationDbContext _context;

        public LiveVideoPlayerModel(ApplicationDbContext context)
        {
                _context=context;
        }



        public string link { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var videoUpoad = await _context.LiveVideos
                .FirstOrDefaultAsync(m => m.Id == id);
             link = videoUpoad.videolink;

            return Page();

        }
    }
}
