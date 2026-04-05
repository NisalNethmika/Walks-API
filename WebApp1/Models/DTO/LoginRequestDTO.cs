using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string usename { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
