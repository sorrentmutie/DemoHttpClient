using DemoHttp.Models.RandomUser;
using DemoHttp.Services.RandomUserService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoHttp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRandomUserService? _service;
        public List<Result>? People { get; set; } = new();
        public string? Message { get; set; }
        public string? Gender { get; set; } = "female";

        public IndexModel(IRandomUserService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            Message = "";
            if (_service is null)
            {
                return;
            }

            try
            {
                People = await _service.GetReqResPepoleByGenderAsync(Gender);
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }
    }
}