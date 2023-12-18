using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;

namespace DemoHttp.Services.Music.ServicesDTO;

public static class ConcertExtensionMethods
{
    public static List<ConcertArtistDetailDto> ConvertConcertsToDto(this List<Concert> concerts)
    {
        return concerts.Select(concert => new ConcertArtistDetailDto()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            Artist = new ArtistDtoEssential()
            {
                Name = concert.Artist.Name,
                Surname = concert.Artist.Surname,
                BirthYear = concert.Artist.BirthYear
            }
        }).ToList();
    }

    public static ConcertArtistDetailDto ConvertConcertToDto(this Concert concert)
    {
        return new ConcertArtistDetailDto()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            Artist = new ArtistDtoEssential()
            {
                Name = concert.Artist.Name,
                Surname = concert.Artist.Surname,
                BirthYear = concert.Artist.BirthYear
            }
        };
    }

    public static ConcertDto ConvertConcertSpecialToDto(this Concert concert)
    {
        return new ConcertDto()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId,
            Artist = new ArtistDtoWithId
            {
                BirthYear = concert.Artist.BirthYear,
                Id = concert.Artist.Id,
                Name = concert.Artist.Name,
                Surname = concert.Artist.Surname
            }
        };
    }

    public static Concert ConvertDtoToConcert(this ConcertDtoBase concert)
    {
        return new Concert
        {
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId
        };
    }
}