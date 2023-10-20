using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [AllowAnonymous]
	public class UserLoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

        public UserLoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            
            if(ModelState.IsValid)
            {
                var result= await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password,false,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","UserDashboard");
                }
                else
                {
                    return RedirectToAction("Index", "UserLogin");
                }
            }
            return View();
        }
    }
}
