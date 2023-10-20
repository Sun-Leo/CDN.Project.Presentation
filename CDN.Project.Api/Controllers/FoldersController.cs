using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDN.Project.Api.Controllers
{
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost]
        [Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        {
            var result = await WriteFile(file);
            return Ok(result);
        }

        private async Task<IActionResult> WriteFile(IFormFile file)
        {
            string fileName = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks.ToString() + extension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {

            }
            return Ok(fileName);
        }
    }
}
