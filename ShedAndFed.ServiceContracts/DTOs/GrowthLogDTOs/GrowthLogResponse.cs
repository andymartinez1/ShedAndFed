namespace ShedAndFed.ServiceContracts.DTOs.GrowthLogDTOs;

public class GrowthLogResponse
{
    public int LogId { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ReptileId { get; set; }

    public double? WeightGrams { get; set; }

    public double? LengthCm { get; set; }
}