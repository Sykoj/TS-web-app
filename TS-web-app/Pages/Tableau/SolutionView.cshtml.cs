using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {

    public enum SolutionViewType { Text, Svg };

    public class SolutionViewModel : PageModel {
        
        public SolutionViewType ViewType { get; set; } 

        public AppSolutionEventRequest AppSolutionEventRequest { get; set; }
        
        public EventService EventService { get; }

        public SolutionViewModel(EventService eventService) {
            EventService = eventService;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong requestId, SolutionViewType solutionViewType) {

            ViewType = solutionViewType;
            AppSolutionEventRequest = EventService.LoadAppSolutionEventById((int) requestId);
        }
    }
}
