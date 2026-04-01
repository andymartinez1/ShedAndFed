namespace ShedAndFed.ServiceContracts.DTOs.WasteLogDTOs;

public class WasteLogResponse
{
    public int LogId { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ReptileId { get; set; }

    public string Type { get; set; } = string.Empty;
}