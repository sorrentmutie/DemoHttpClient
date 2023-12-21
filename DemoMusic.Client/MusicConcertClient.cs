using System.Net.Http.Json;
using DemoHttp.Client.Models;

namespace DemoHttp.Client;

public class MusicConcertClient : IMusicConcertClient
{
    private readonly HttpClient _httpClient;

    public MusicConcertClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5253");
    }
    public async Task<List<Concert>?> GetConcertsAsync()
    {
        //var httpClient = httpClientFactory.CreateClient("client");
        var response = await _httpClient.GetAsync("/concerts");

        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<List<Concert>?>();
    }

    public async Task<Concert?> GetConcertAsync(int id)
    {
        var response = await _httpClient.GetAsync($"concerts/{id}");
        
        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<Concert?>();
    }
}