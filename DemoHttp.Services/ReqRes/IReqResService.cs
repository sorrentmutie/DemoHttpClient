using DemoHttp.Models.ReqRes;

namespace DemoHttp.Services.ReqRes
{
    public interface IReqResService
    {
        Task<ReqResResponse?> GetReqResData();
        Task<List<Person>?> GetReqResPeopleAsync();
    }
}