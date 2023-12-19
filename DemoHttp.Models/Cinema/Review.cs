namespace DemoHttp.Models.Cinema;

public class Review
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Mark { get; set; } = null!;
}