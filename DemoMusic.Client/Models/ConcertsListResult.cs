namespace DemoHttp.Client.Models;

public class ConcertsListResult
{
    public int Total { get; set; }
    public int Page { get; set; }
    public List<Concert> Concerts { get; set; } = null!;
}

public enum OrderingDirection
{
    Ascending,
    Descending
}