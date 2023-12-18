namespace DemoHttp.Models.Music;

public class Concert
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
    public int ArtistId { get; set; }
}