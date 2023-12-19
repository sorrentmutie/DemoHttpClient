using DemoHttp.Models.DTO;

namespace DemoHttp.Models.Music;

public class ConcertsGetResponse
{
    public int Total { get; set; }
    public int Page { get; set; }
    public List<ConcertArtistDetailDto> Concerts { get; set; } = null!;
}