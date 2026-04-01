namespace ShedAndFed.ServiceContracts.DTOs.FeedingLogDTOs;

public class FeedingLogResponse
{
    public int LogId { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ReptileId { get; set; }

    public string FoodType { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public bool WasEaten { get; set; }
}