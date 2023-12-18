using DemoHttp.Models.Interfaces.Implementations;

namespace DemoHttp.Models.Music;

public class Concert : BaseEntity
{
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public Artist Artist { get; set; } = null!;

    public int ArtistId { get; set; }
}

public class Artist : BaseEntity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int BirthYear { get; set; }
    public List<Concert> Concerts { get; set; } = new();
}