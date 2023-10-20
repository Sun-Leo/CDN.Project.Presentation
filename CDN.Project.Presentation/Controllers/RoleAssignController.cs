using CDN.Project.Presentation.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var values= _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRole = await _userManager.GetRolesAsync(user);
            List<RoleAssignModel> roleAssignViewModels = new List<RoleAssignModel>();
            foreach (var role in roles)
            {
                RoleAssignModel model = new RoleAssignModel();
                model.RoleID = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userRole.Contains(role.Name);
                roleAssignViewModels.Add(model);

            }
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignModel> roleAssignModel)
        {
            var userId = (int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in roleAssignModel)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
