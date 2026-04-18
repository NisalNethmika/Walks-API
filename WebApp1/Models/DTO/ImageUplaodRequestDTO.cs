using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.DTO
{
    public class ImageUplaodRequestDTO
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
