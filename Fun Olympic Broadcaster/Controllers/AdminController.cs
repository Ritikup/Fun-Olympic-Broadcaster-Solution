using Fun_Olympic_Broadcaster.Data;
using Fun_Olympic_Broadcaster.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fun_Olympic_Broadcaster.Controllers
{

    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this._context = context;
        }

       
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
        public async Task<IActionResult> Update(string id, string email, string FirsName, string LastName, string Country, string City, string PhoneNumber,DateTime DOB)
        {

            ApplicationUser user = await userManager.FindByIdAsync(id);
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
                    user.LastName =  LastName;
                else
                    ModelState.AddModelError("", "Last Name cannot be empty");



                if (!string.IsNullOrEmpty(Country))
                    user.Country = Country;
                else
                    ModelState.AddModelError("", "Country cannot be empty");



                if (!string.IsNullOrEmpty(City))
                    user.PasswordHash = City;
                else
                    ModelState.AddModelError("", "City cannot be empty");

                if (!string.IsNullOrEmpty(PhoneNumber))
                    user.PhoneNumber = PhoneNumber;
                else
                    ModelState.AddModelError("", "City cannot be empty");
                            
                
                    user.DOB = DOB;
                

               

                //if (ModelState.IsValid)
                //{
                //    IdentityResult result = await userManager.UpdateAsync(user);
                //    if (result.Succeeded)
                //        return RedirectToAction("Index");
                //    else
                //        Errors(result);
                //}

                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
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






    }
}
