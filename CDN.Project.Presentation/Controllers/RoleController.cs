using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace CDN.Project.Presentation.Controllers
{
        [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var value= _roleManager.Roles.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleModel roleModel)
        {
            if(ModelState.IsValid)
            {
                AppRole appRole = new AppRole
                {
                    Name= roleModel.name
                };

                var result= await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(roleModel);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }


    }
}
