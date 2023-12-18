namespace DemoHttp.Models.DTO;

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

public class ConcertArtistDetailDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public ArtistDtoEssential Artist { get; set; } = null!;
}