namespace ShedAndFed.Entities;

public abstract class ReptileLogBase
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public Guid ReptileId { get; set; }

    public Reptile Reptile { get; set; } = null!;
}
