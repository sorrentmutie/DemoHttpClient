using DemoHttp.Client.Models;

namespace DemoHttp.Client;

public interface IMusicConcertClient
{
    Task<List<Concert>?> GetConcertsAsync();
    Task<Concert?> GetConcertAsync(int id);
    Task<ConcertsListResult?> GetConcertsWithPaginationAsync(int? page, string orderBy, OrderingDirection direction);
}