namespace ShedAndFed.Entities;

public class WasteLog
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;

    public Guid ReptileId { get; set; }

    public Reptile Reptile { get; set; } = null!;
}
