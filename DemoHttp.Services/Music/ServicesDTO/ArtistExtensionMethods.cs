using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;

namespace DemoHttp.Services.Music.ServicesDTO;

public static class ArtistExtensionMethods
{
    public static List<ArtistConcertsDetailWithIdDto> ConvertArtistsToDto(this List<Artist> artists)
    {
        return artists.Select(artist => new ArtistConcertsDetailWithIdDto()
        {
            Id = artist.Id,
            Name = artist.Name,
            Surname = artist.Surname,
            BirthYear = artist.BirthYear,
            Concerts = artist.Concerts.Select(concert => new ConcertDtoEssential()
            {
                Location = concert.Location,
                Date = concert.Date
            }).ToList()
        }).ToList();
    }

    public static Artist ConvertDtoToArtist(this ArtistDtoEssential artist)
    {
        return new Artist()
        {
            Name = artist.Name,
            Surname = artist.Surname,
            BirthYear = artist.BirthYear
        };
    }

    public static ArtistDtoWithId ConvertArtistToDtoWithId(this Artist artist)
    {
        return new ArtistDtoWithId()
        {
            Id = artist.Id,
            Name = artist.Name,
            Surname = artist.Surname,
            BirthYear = artist.BirthYear
        };
    }
}