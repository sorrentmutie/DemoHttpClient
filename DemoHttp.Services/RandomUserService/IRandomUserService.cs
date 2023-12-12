using DemoHttp.Models.RandomUser;
using DemoHttp.Models.ReqRes;

namespace DemoHttp.Services.RandomUserService
{
    public interface IRandomUserService
    {
        Task<RandomUserData?> GetData();
        Task<List<Result>?> GetPeopleAsync();

        Task<List<Result>?> GetPeopleByGenderAsync(string? gender);
    }
}