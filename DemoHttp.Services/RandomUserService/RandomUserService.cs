using System.Net.Http.Json;
using DemoHttp.Models.RandomUser;
using DemoHttp.Models.ReqRes;

namespace DemoHttp.Services.RandomUserService;

public class RandomUserService : IRandomUserService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RandomUserService(IHttpClientFactory httpClientFactory)
    {
        this._httpClientFactory = httpClientFactory;
    }

    public async Task<RandomUserData?> GetData()
    {
        var httpClient = _httpClientFactory.CreateClient("randomUser");
        var response = await httpClient.GetAsync("");
        if (response.IsSuccessStatusCode == true)
        {
            return await response.Content.ReadFromJsonAsync<RandomUserData>();
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Result>?> GetPeopleAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("randomUser");
        var response = await httpClient.GetAsync("");
        if (response.IsSuccessStatusCode == true)
        {
            var data = await response.Content.ReadFromJsonAsync<RandomUserData>();
            return data?.Results;
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Result>?> GetPeopleByGenderAsync(string? gender)
    {
        var httpClient = _httpClientFactory.CreateClient("randomUser");
        var response = await httpClient.GetAsync("");
        if (response.IsSuccessStatusCode == true)
        {
            var data = await response.Content.ReadFromJsonAsync<RandomUserData>();
            var femalePeople = data?.Results?
                .Where(person => person.Gender == gender)
                .ToList();

            return femalePeople;
        }
        else
        {
            return null;
        }
    }
}