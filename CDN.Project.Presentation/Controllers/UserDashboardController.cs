using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{
    [Authorize(Roles = "User")]
    public class UserDashboardController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
    }
}
