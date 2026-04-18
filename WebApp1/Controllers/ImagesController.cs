using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp1.Models.DTO;

namespace WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        //POST: api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUplaodRequestDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                //repository logic to upload the file
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUplaodRequestDTO request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Only .jpg, .jpeg, and .png files are allowed.");
            }

            if (request.File.Length > 10 * 1024 * 1024)
            {
                ModelState.AddModelError("file", "File size must be less than 10MB.");
            }
        }
    }
}
