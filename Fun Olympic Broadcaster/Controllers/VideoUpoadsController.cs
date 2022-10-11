using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;

namespace Fun_Olympic_Broadcaster.Controllers
{
    public class VideoUpoadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoUpoadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VideoUpoads
        public async Task<IActionResult> Index()
        {
              return View(await _context.VideoUpoads.ToListAsync());
        }

        // GET: VideoUpoads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoUpoads == null)
            {
                return NotFound();
            }

            var videoUpoad = await _context.VideoUpoads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoUpoad == null)
            {
                return NotFound();
            }

            return View(videoUpoad);
        }

        // GET: VideoUpoads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoUpoads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,thumbnail,description,category,rivals,videolink")] VideoUpoad videoUpoad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoUpoad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoUpoad);
        }

        // GET: VideoUpoads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null || _context.VideoUpoads == null)
            {
                return NotFound();
            }

            var videoUpoad = await _context.VideoUpoads.FindAsync(id);
            if (videoUpoad == null)
            {
                return NotFound();
            }
            return View(videoUpoad);
        }

        // POST: VideoUpoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,thumbnail,description,category,rivals,videolink")] VideoUpoad videoUpoad)
        {
            if (id != videoUpoad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoUpoad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoUpoadExists(videoUpoad.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(videoUpoad);
        }

        // GET: VideoUpoads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoUpoads == null)
            {
                return NotFound();
            }

            var videoUpoad = await _context.VideoUpoads
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoUpoad == null)
            {
                return NotFound();
            }

            return View(videoUpoad);
        }

        // POST: VideoUpoads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoUpoads == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VideoUpoads'  is null.");
            }
            var videoUpoad = await _context.VideoUpoads.FindAsync(id);
            if (videoUpoad != null)
            {
                _context.VideoUpoads.Remove(videoUpoad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoUpoadExists(int id)
        {
          return _context.VideoUpoads.Any(e => e.Id == id);
        }


    }
}
