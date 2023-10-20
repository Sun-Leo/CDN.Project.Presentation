using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public LoginController(SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
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
                RoleModel role = new RoleModel();
                var result= await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password,false,true);
                if (result.Succeeded)
                {
                   
                        return RedirectToAction("Index","Dashboard");

                   
                }
            }
            return View();
        }
    }
}
