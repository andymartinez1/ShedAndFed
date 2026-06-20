using System.ComponentModel.DataAnnotations;
using ShedAndFed.ServiceContracts.Enums;

namespace ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

public class UpdateReptileRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int ReptileId { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;

    [MaxLength(100)] public string Species { get; set; } = string.Empty;

    [MaxLength(100)] public string? Morph { get; set; }

    public Sex Sex { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime AcquiredDate { get; set; }

    public bool IsAlive { get; set; } = true;

    [MaxLength(1000)] public string? Notes { get; set; }
}