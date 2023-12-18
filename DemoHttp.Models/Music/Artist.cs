namespace DemoHttp.Models.Music;

public class Artist
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int BirthYear { get; set; }
    public List<Concert> Concerts { get; set; } = new();
}