using System.ComponentModel.DataAnnotations;

namespace ShedAndFed.ServiceContracts.DTOs.GrowthLogDTOs;

public class UpdateGrowthLogRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int LogId { get; set; }

    [Required] public DateTime Date { get; set; }

    [MaxLength(1000)] public string Notes { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int ReptileId { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Weight must be between 0.00 and 999.99 grams")]
    public double? WeightGrams { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Length must be between 0.00 and 999.99 centimeters")]
    public double? LengthCm { get; set; }
}