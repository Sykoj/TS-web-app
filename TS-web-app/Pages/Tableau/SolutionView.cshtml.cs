using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Ts.App.Model;
using Ts.App.Services;

namespace Ts.App.Pages.Tableau {

    public enum SolutionViewType { Text, Svg };

    /// <summary>
    /// Displays tableau solution
    /// </summary>
    public class SolutionViewModel : PageModel {
        
        public SolutionViewType ViewType { get; set; } 

        public AppSolutionRequest AppSolutionRequest { get; set; }
        
        public EventService EventService { get; }

        public SolutionViewModel(EventService eventService) {
            EventService = eventService;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong requestId, SolutionViewType solutionViewType, bool isSession = false) {
            ViewType = solutionViewType;
            AppSolutionRequest = isSession ? LoadRequestFromSession() : EventService.LoadAppSolutionEventById((int) requestId);
        }

        private AppSolutionRequest LoadRequestFromSession() {

            AppSolutionRequest =
                JsonConvert.DeserializeObject<AppSolutionRequest>(HttpContext.Session.GetString(TableauSolutionModel.RequestName));
            AppSolutionRequest.TableauSolution =
                JsonConvert.DeserializeObject<TableauSolution>(HttpContext.Session.GetString(TableauSolutionModel.SolutionName));

            return AppSolutionRequest;
        }
    }
}
