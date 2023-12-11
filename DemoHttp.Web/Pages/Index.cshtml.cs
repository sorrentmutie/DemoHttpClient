using DemoHttp.Models.ReqRes;
using DemoHttp.Services.ReqRes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoHttp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IReqResService? _service; 

        public List<Person>? People { get; set; } = new();
        public string? Message { get; set; }

        public IndexModel(IReqResService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            Message = "";
            if(_service is null)
            {
                return;
            }
            try
            {
                People = await _service.GetReqResPeopleAsync();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                
            }

            
        }
    }
}
