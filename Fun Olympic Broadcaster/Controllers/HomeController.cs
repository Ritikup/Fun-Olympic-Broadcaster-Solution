using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fun_Olympic_Broadcaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<VideoUpoad> videoList = _context.VideoUpoads.ToList();
            return View(videoList);
        }

        public IActionResult VideoGrid()
        {
            IEnumerable<VideoUpoad> videoGridList = _context.VideoUpoads.ToList();
            return View(videoGridList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult VideoPlay(string? videolink)
        {
            var videolik = videolink;
            ViewData ["link"] = videolik;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}