using System.ComponentModel.DataAnnotations;

namespace ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

public class CreateShedLogRequest
{
    [Required] public DateTime Date { get; set; }

    [MaxLength(1000)] public string Notes { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A valid ReptileId is required.")]
    public int ReptileId { get; set; }

    public bool CompleteShed { get; set; }
}