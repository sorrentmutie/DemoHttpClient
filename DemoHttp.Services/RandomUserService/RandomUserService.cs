using System.Net.Http.Json;
using DemoHttp.Models.RandomUser;

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
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<RandomUserData>();
        }

        return null;
    }

    public async Task<List<Result>?> GetPeopleAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("randomUser");
        var response = await httpClient.GetAsync("");
        if (!response.IsSuccessStatusCode) return null;
        var data = await response.Content.ReadFromJsonAsync<RandomUserData>();
        return data?.Results;
    }

    public async Task<List<Result>?> GetPeopleByGenderAsync(string? gender)
    {
        var httpClient = _httpClientFactory.CreateClient("randomUser");
        var response = await httpClient.GetAsync("");
        if (!response.IsSuccessStatusCode) return null;
        var data = await response.Content.ReadFromJsonAsync<RandomUserData>();
        var femalePeople = data?.Results?
            .Where(person => person.Gender == gender)
            .ToList();

        return femalePeople;
    }

    public Task<RandomUserData?> GetReqResData()
    {
        throw new NotImplementedException();
    }

    public Task<List<Result>?> GetReqResPeopleAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Result>?> GetReqResPepoleByGenderAsync(string? gender)
    {
        throw new NotImplementedException();
    }
}