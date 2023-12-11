using System.Text.Json.Serialization;

namespace DemoHttp.Models.ReqRes;

public class ReqResResponse
{
    [JsonPropertyName("page")] public int Page { get; set; }
    [JsonPropertyName("per_page")] public int PerPage { get; set; }
    [JsonPropertyName("total")] public int Total { get; set; }
    [JsonPropertyName("total_pages")] public int TotalPages { get; set; }
    [JsonPropertyName("data")] public Person[]? People { get; set; }
    [JsonPropertyName("support")] public Support Support { get; set; } = new();
}

public class Support
{
    public string url { get; set; } = null!;
    public string text { get; set; } = null!;
}

public class Person
{
    public int Id { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; } = null!;
    [JsonPropertyName("first_name")] public string FirstName { get; set; } = null!;
    [JsonPropertyName("last_name")] public string LastName { get; set; } = null!;
    public string Avatar { get; set; } = null!;
}