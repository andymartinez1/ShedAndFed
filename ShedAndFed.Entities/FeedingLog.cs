namespace ShedAndFed.Entities;

public class FeedingLog
{
    public Guid Id { get; set; }

    public Guid ReptileId { get; set; }

    public DateTime Date { get; set; }

    public string FoodType { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public bool WasEaten { get; set; }

    public string Notes { get; set; } = string.Empty;

    public Reptile Reptile { get; set; } = null!;
}
