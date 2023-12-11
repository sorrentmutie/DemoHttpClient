using DemoHttp.Models.RandomUser;
using DemoHttp.Models.ReqRes;

namespace DemoHttp.Services.RandomUserService
{
    public interface IRandomUserService
    {
        Task<RandomUserData?> GetReqResData();
        Task<List<Result>?> GetReqResPeopleAsync();

        Task<List<Result>?> GetReqResPepoleByGenderAsync(string? gender);
    }
}