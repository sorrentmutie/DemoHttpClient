namespace DemoHttp.Models.DTO;

public class ArtistDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDto> Concerts { get; set; } = new();
}