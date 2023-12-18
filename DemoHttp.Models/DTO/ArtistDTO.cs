namespace DemoHttp.Models.DTO;

public class ArtistDtoEssential
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
}

public class ArtistDtoWithId
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
}

public class ArtistConcertsDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDtoEssential> Concerts { get; set; } = new();
}

public class ArtistDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDto> Concerts { get; set; } = new();
}