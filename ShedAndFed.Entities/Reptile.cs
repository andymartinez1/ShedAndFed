namespace ShedAndFed.Entities;

public class Reptile
{
    public int ReptileId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Species { get; set; } = string.Empty;

    public string? Morph { get; set; } = string.Empty;

    public string? Sex { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public DateTime AcquiredDate { get; set; }

    public double? WeightGrams { get; set; }

    public double? LengthCm { get; set; }

    public bool IsAlive { get; set; } = true;

    public string? Notes { get; set; } = string.Empty;

    public DateTime? LastFed { get; set; }

    public DateTime? LastShed { get; set; }

    public DateTime? LastPooped { get; set; }

    public List<FeedingLog> Feedings { get; set; } = [];

    public List<ShedLog> Sheds { get; set; } = [];

    public List<WasteLog> Wastes { get; set; } = [];
}