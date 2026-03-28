namespace ShedAndFed.Entities;

public abstract class ReptileLogBase
{
    public int LogId { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; } = string.Empty;

    public int ReptileId { get; set; }

    public Reptile Reptile { get; set; } = null!;
}