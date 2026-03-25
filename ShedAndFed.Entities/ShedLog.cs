namespace ShedAndFed.Entities;

public class ShedLog
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public bool CompleteShed { get; set; }

    public string Notes { get; set; } = string.Empty;

    public Guid ReptileId { get; set; }

    public Reptile Reptile { get; set; } = null!;
}
