using System.ComponentModel.DataAnnotations;

namespace DemoHttp.Models.Music;

public class Concert
{
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}

public class Artist
{
    [Key] public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int BirthYear { get; set; } 
}