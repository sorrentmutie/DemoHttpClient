using System.Text.Json.Serialization;

namespace DemoHttp.Models.PeopleTodos;

public class Todos
{
    [JsonPropertyName("userId")] public int UserId { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("completed")] public bool? Completed { get; set; }
}