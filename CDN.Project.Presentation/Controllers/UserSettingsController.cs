using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [Authorize(Roles = "User")]
    public class UserSettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserSettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditModel userEditViewModel = new UserEditModel();
            userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.Surname;
            userEditViewModel.Email = user.Email;
            userEditViewModel.Username = user.UserName;

            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditModel userEditViewModel)
        {
            if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditViewModel.Name;
                user.Surname = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","UserLogin");
            }
            return View();

        }
    }
}
