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

public class ArtistConcertsDetailWithIdDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDtoEssential> Concerts { get; set; } = new();
}

public class ArtistConcertsDetailDto
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int BirthYear { get; set; }
    public List<ConcertDtoEssential> Concerts { get; set; } = new();
}