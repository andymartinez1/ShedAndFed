using ShedAndFed.ServiceContracts.DTOs.GrowthLogDTOs;

namespace ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

public class ReptileResponse
{
    public int ReptileId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Species { get; set; } = string.Empty;

    public string? Morph { get; set; } = string.Empty;

    public string? Sex { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public DateTime AcquiredDate { get; set; }

    public bool IsAlive { get; set; } = true;

    public string? Notes { get; set; } = string.Empty;

    public GrowthLogResponse? LatestGrowth { get; set; }
}