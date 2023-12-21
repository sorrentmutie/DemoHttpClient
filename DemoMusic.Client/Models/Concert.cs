namespace DemoHttp.Client.Models;

public class Concert
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;
    public string Location { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}