using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models.DTO
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Length in km must be a non-negative number")]
        public double LengthInKm { get; set; }
        public string? WalkImageURL { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
