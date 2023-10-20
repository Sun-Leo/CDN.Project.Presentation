using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterModel user)
        {
            var appUser = new AppUser()
            {
                Name = user.Name,
                Email = user.Email,
                Surname = user.Surname,
                UserName = user.Name,
            };

            if(user.Password == user.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            return View();
        }
    }
}
