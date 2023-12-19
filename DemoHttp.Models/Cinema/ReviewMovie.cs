namespace DemoHttp.Models.Cinema;

public class ReviewMovie
{
    public int Id { get; set; }
    public string ReviewerName { get; set; } = null!;
    public int ReviewId { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = new Movie();
    public Review Review { get; set; } = new Review();
}