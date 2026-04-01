using System.ComponentModel.DataAnnotations;

namespace ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

public class UpdateFeedingLogRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int LogId { get; set; }

    [Required] public DateTime Date { get; set; }

    [MaxLength(1000)] public string Notes { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int ReptileId { get; set; }

    [Required] [MaxLength(100)] public string FoodType { get; set; } = string.Empty;

    [Required] [MaxLength(50)] public string Size { get; set; } = string.Empty;

    public bool WasEaten { get; set; }
}