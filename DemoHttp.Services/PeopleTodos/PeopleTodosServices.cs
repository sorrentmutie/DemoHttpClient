using System.Net.Http.Json;
using DemoHttp.Models.PeopleTodos;

namespace DemoHttp.Services.PeopleTodos;

public class PeopleTodosServices(IHttpClientFactory httpClientFactory) : IPeopleTodosServices
{
    public async Task<List<Person>?> GetPeopleAsync()
    {
        var httpClient = httpClientFactory.CreateClient("json-placeholder");
        var response = await httpClient.GetAsync("users");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Person>?>();
        }

        return null;
    }

    public async Task<List<Todos>?> GetTodosAsync(int? userId)
    {
        var httpClient = httpClientFactory.CreateClient("json-placeholder");
        var response = await httpClient.GetAsync("todos");
        if (!response.IsSuccessStatusCode) return null;

        var todos = await response.Content.ReadFromJsonAsync<List<Todos>?>();
        return todos?
            .Where(t => t.UserId == userId)
            .ToList();
    }
}