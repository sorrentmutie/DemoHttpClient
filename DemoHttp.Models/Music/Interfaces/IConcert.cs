using DemoHttp.Models.DTO;

namespace DemoHttp.Models.Music.Interfaces;

public interface IConcert
{
    Task<List<ConcertArtistDetailDto>?> GetConcertsAsync();
    Task<ConcertDto?> GetConcertDtoAsync(int id);
    Task<ConcertArtistDetailDto?> GetConcertAsync(int id);
    Task<int> AddConcertAsync(ConcertDtoBase concert);
    Task DeleteConcertAsync(int id);
    Task UpdateConcertAsync(ConcertDto updatedConcert);
}