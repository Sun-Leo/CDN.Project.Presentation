using CDN.Project.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CDN.Project.Presentation.Controllers
{
    [Authorize(Roles = "User")]
    public class FolderUploadController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var client = new HttpClient();
            var responsmessage = await client.PostAsync("https://localhost:44355/UploadFile", multipartFormDataContent);
            if (responsmessage.IsSuccessStatusCode)
            {
                return View("Index","UserDashboard");

            }
            return View();

        }
    }
}
