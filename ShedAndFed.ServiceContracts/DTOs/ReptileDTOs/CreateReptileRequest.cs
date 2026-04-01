using System.ComponentModel.DataAnnotations;
using ShedAndFed.ServiceContracts.Enums;

namespace ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

public class CreateReptileRequest
{
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;

    [MaxLength(100)] public string Species { get; set; } = string.Empty;

    [MaxLength(100)] public string? Morph { get; set; }

    public Sex Sex { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime AcquiredDate { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Weight must be between 0.00 and 999.99 grams")]
    public double? WeightGrams { get; set; }

    [Range(0.0, 999.99, ErrorMessage = "Length must be between 0.00 and 999.99 centimeters")]
    public double? LengthCm { get; set; }

    public bool IsAlive { get; set; } = true;

    [MaxLength(1000)] public string? Notes { get; set; }
}