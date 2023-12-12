namespace DemoHttp.Models.Music.Interfaces;

public interface IConcert
{
    Task<List<Concert>?> GetConcertsAsync();
    Task<Concert?> GetConcertAsync(int id);
    Task<int> AddConcertAsync(Concert concert);
    Task DeleteConcertAsync(int id);
    Task UpdateConcertAsync(Concert concert);
}
