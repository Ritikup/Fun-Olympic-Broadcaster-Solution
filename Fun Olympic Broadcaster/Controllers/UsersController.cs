using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.AspNetCore.Identity;

namespace Fun_Olympic_Broadcaster.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> userManager;
        // private UserManager<ApplicationUser> _usermanager;

        public UsersController(ApplicationDbContext context, IConfiguration configuration,
         UserManager<IdentityUser> UserManager/*,UserManager<ApplicationUser> userManager*/)
        {
            _config = configuration;
            this.userManager = UserManager;
            _context = context;
         //   _usermanager = userManager;
        }

        // GET: VideoUpoads
        public async Task<IActionResult> Index()
        {
              return View(await _context.ApplicationUsers.ToListAsync());
        }

        // GET: VideoUpoads/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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
        public async Task<IActionResult> Create([Bind("Id,FirsName,LastName,Email,PhoneNumber,Country,City,DOB")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }









        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            //ApplicationUser user = await userManager.FindByIdAsync(id);
            //if (user != null)
            //    return View(user);
            //else
            //    return RedirectToAction("Index");

            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var User = await _context.ApplicationUsers.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string FirsName, string LastName, string Country, string City, string PhoneNumber, DateTime DOB)
        {

          //  ApplicationUser user = await userManager.FindByIdAsync(id);

           ApplicationUser user = await _context.ApplicationUsers.FindAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(FirsName))
                    user.FirsName = FirsName;
                else
                    ModelState.AddModelError("", "FirstName cannot be empty");



                if (!string.IsNullOrEmpty(LastName))
                    user.LastName = LastName;
                else
                    ModelState.AddModelError("", "Last Name cannot be empty");



                if (!string.IsNullOrEmpty(Country))
                    user.Country = Country;
                else
                    ModelState.AddModelError("", "Country cannot be empty");



                if (!string.IsNullOrEmpty(City))
                    user.City = City;
                else
                    ModelState.AddModelError("", "City cannot be empty");

                if (!string.IsNullOrEmpty(PhoneNumber))
                    user.PhoneNumber = PhoneNumber;
                else
                    ModelState.AddModelError("", "Phone Number cannot be empty");


                user.DOB = DOB;




                if (ModelState.IsValid)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }

                //IdentityResult result = await userManager.UpdateAsync(user);
                //if (result.Succeeded)
                //    return RedirectToAction("Index");
                //else
                //    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);


        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }















        // GET: VideoUpoads/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var User = await _context.ApplicationUsers.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }

        // POST: VideoUpoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        //[HttpPost]
        //public async Task<IActionResult> Edit(string id, string email,string FirsName,string Lastname, string Country,string City,string PhoneNumber, DateTime DOB)
        //{
        //    ApplicationUser user = await _userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        if (!string.IsNullOrEmpty(email))
        //            user.Email = email;
        //        else
        //            ModelState.AddModelError("", "Email cannot be empty");

        //        if (!string.IsNullOrEmpty(password))
        //            user.PasswordHash = passwordHasher.HashPassword(user, password);
        //        else
        //            ModelState.AddModelError("", "Password cannot be empty");

        //        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        //        {
        //            IdentityResult result = await userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //                return RedirectToAction("Index");
        //            else
        //                Errors(result);
        //        }
        //    }
        //    else
        //        ModelState.AddModelError("", "User Not Found");
        //    return View(user);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirsName,LastName,Email,PhoneNumber,Country,City,DOB")] ApplicationUser applicationUser)
        {

            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    IdentityResult result=await userManager.UpdateAsync(applicationUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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
            return View(applicationUser);
        }

        // GET: VideoUpoads/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.ApplicationUsers == null)
            {
                return NotFound();
            }

            var videoUpoad = await _context.ApplicationUsers
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ApplicationUsers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VideoUpoads'  is null.");
            }
            var videoUpoad = await _context.ApplicationUsers.FindAsync(id);
            if (videoUpoad != null)
            {
                _context.ApplicationUsers.Remove(videoUpoad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
          return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
