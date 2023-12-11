using DemoHttp.Models.ReqRes;

namespace DemoHttp.Services.ReqRes;

public class ReqResService
{
    private readonly HttpClient httpClient = new();
    private string baseUrl = "https://reqres.in/api/users/";
    public async Task<ReqResResponse?> GetReqResData()
    {
        var response = await httpClient.GetAsync(baseUrl);
        if(response.IsSuccessStatusCode == true)
        {
            return null;
        } else
        {
            return null;
        }
    }
}
