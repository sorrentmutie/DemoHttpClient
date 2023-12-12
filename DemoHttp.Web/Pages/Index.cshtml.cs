using DemoHttp.Models.PeopleTodos;
using DemoHttp.Services.PeopleTodos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoHttp.Web.Pages
{
    public class IndexModel(IPeopleTodosServices service) : PageModel
    {
        private readonly IPeopleTodosServices? _service = service;
        public List<Person>? People { get; set; } = [];
        public List<Todos>? Todos { get; set; } = [];
        public string? Message { get; set; }

        public async Task OnGet()
        {
            Message = "";
            if (_service is null)
            {
                return;
            }

            try
            {
                People = await _service.GetPeopleAsync();
                Todos = await _service.GetTodosAsync(2);
            }
            catch (Exception e)
            {
                Message = e.Message;
            }
        }
    }
}