namespace DemoHttp.Models.Music;

public class Concert
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public string Artist { get; set; } = null!;
}
