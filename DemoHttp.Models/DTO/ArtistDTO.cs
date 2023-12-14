namespace DemoHttp.Models.DTO;

public class ArtistDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDto> Concerts { get; set; } = new();
}

public class ConcertDto : ConcertDtoBase
{
    public int Id { get; set; }
}

public class ConcertDtoBase
{
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public int ArtistId { get; set; }
    public ArtistDto Artist { get; set; } = null!;
}

public class ConcertDtoForVisualization
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public int ArtistId { get; set; }
}