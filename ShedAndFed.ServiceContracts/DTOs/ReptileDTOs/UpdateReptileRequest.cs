namespace ShedAndFed.ServiceContracts.DTOs.ReptileDTOs;

public class UpdateReptileRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Species { get; set; } = string.Empty;

    public string? Morph { get; set; }

    public string? Sex { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime AcquiredDate { get; set; }

    public double? WeightGrams { get; set; }

    public double? LengthCm { get; set; }

    public bool IsAlive { get; set; } = true;

    public string? Notes { get; set; }
}
