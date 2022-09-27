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
    public class LiveVideosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LiveVideosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LiveVideos
        public async Task<IActionResult> Index()
        {
              return View(await _context.LiveVideos.ToListAsync());
        }

        // GET: LiveVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LiveVideos == null)
            {
                return NotFound();
            }

            var liveVideo = await _context.LiveVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liveVideo == null)
            {
                return NotFound();
            }

            return View(liveVideo);
        }

        // GET: LiveVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LiveVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,thumbnail,description,category,rivals,videolink")] LiveVideo liveVideo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liveVideo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liveVideo);
        }

        // GET: LiveVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LiveVideos == null)
            {
                return NotFound();
            }

            var liveVideo = await _context.LiveVideos.FindAsync(id);
            if (liveVideo == null)
            {
                return NotFound();
            }
            return View(liveVideo);
        }

        // POST: LiveVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,thumbnail,description,category,rivals,videolink")] LiveVideo liveVideo)
        {
            if (id != liveVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liveVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiveVideoExists(liveVideo.Id))
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
            return View(liveVideo);
        }

        // GET: LiveVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LiveVideos == null)
            {
                return NotFound();
            }

            var liveVideo = await _context.LiveVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liveVideo == null)
            {
                return NotFound();
            }

            return View(liveVideo);
        }

        // POST: LiveVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LiveVideos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LiveVideos'  is null.");
            }
            var liveVideo = await _context.LiveVideos.FindAsync(id);
            if (liveVideo != null)
            {
                _context.LiveVideos.Remove(liveVideo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiveVideoExists(int id)
        {
          return _context.LiveVideos.Any(e => e.Id == id);
        }
    }
}
