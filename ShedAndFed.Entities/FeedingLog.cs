namespace ShedAndFed.Entities;

public class FeedingLog : ReptileLogBase
{
    public string FoodType { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public bool WasEaten { get; set; }
}
