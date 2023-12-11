using DemoHttp.Models.ReqRes;
using System.Net.Http.Json;

namespace DemoHttp.Services.ReqRes;

public class ReqResDatabaseService : IReqResService
{
    public Task<ReqResResponse?> GetReqResData()
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>?> GetReqResPeopleAsync()
    {
        throw new NotImplementedException();
    }
}

public class ReqResService : IReqResService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReqResService(IHttpClientFactory httpClientFactory)
    {
        this._httpClientFactory = httpClientFactory;
    }

    public async Task<ReqResResponse?> GetReqResData()
    {
        var httpClient = _httpClientFactory.CreateClient("reqres");
        var response = await httpClient.GetAsync("");
        if (response.IsSuccessStatusCode == true)
        {
            return await response.Content.ReadFromJsonAsync<ReqResResponse>();
        }
        else
        {
            return null;
        }
    }

    public async Task<List<Person>?> GetReqResPeopleAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("reqres");
        var response = await httpClient.GetAsync("");
        if (response.IsSuccessStatusCode == true)
        {
            var data = await response.Content.ReadFromJsonAsync<ReqResResponse>();
            return data?.People?.ToList();
        }
        else
        {
            return null;
        }
    }
}