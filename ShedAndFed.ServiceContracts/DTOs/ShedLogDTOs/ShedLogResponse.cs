namespace ShedAndFed.ServiceContracts.DTOs.ShedLogDTOs;

public class ShedLogResponse
{
    public int LogId { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ReptileId { get; set; }

    public bool CompleteShed { get; set; }
}