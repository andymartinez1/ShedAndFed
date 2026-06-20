using System.ComponentModel.DataAnnotations;
using ShedAndFed.ServiceContracts.Enums;

namespace ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

public class UpdateWasteLogRequest
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int LogId { get; set; }

    [Required] public DateTime Date { get; set; }

    [MaxLength(1000)] public string Notes { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ID is required.")]
    public int ReptileId { get; set; }

    public WasteType Type { get; set; }
}