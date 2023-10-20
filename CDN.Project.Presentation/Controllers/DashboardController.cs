using BusinessLayer.Abstract;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Presentation.Controllers
{

    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {
     
        private readonly IAppUserService _appUserService;

        public DashboardController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var value= _appUserService.TGetList();
            return View(value);
        }
    }
}
