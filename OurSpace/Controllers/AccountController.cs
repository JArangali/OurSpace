using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OurSpace.Data;
using OurSpace.Database;
using OurSpace.Models;
using OurSpace.ViewModels;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OurSpace.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserIdentity> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<UserIdentity> _userManager;
        private readonly AppDbContext _dbData;

        public AccountController(SignInManager<UserIdentity> signInManager, Microsoft.AspNetCore.Identity.UserManager<UserIdentity> userManager, AppDbContext dbData)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbData = dbData;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginInfo)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _signInManager.PasswordSignInAsync(loginInfo.Uemail, loginInfo.UPassword, loginInfo.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //var errorstring = string.Join(" ", result..Select(p => p.Description));

                //ModelState.AddModelError("RegisterErrors", errorstring);
                ModelState.AddModelError("LoginErrors", "User Credentials Do Not Match");
            }
            return View(loginInfo);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerInfo)
        {
            if (ModelState.IsValid)
            {

              // check if admin code is in hubs table
              // var existingHub = _dbData.bookings.Where(p => p.BId == registerInfo.AdminCode).FirstOrDefault();

              //  if (existingHub == null)
              //  {
              //      ModelState.AddModelError("AdminCode", "Admin Code does not exist");
              //      return View(registerInfo);
              //  }

                UserIdentity newAdmin = new UserIdentity();
                newAdmin.UFName = registerInfo.UFname;
                newAdmin.ULName = registerInfo.ULname;
                newAdmin.AdminCode = registerInfo.AdminCode;
                newAdmin.UserName = registerInfo.Uemail;
                newAdmin.Email = registerInfo.Uemail;

                var result = await _userManager.CreateAsync(newAdmin, registerInfo.UPassword);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    var errorstring = string.Join(" ", result.Errors.Select(p=>p.Description));
            
                    ModelState.AddModelError("RegisterErrors", errorstring);
                    return View(registerInfo);
                    //return RedirectToAction("Index", "Home");
                }
            }

            return View(registerInfo);
        }
    }
}
