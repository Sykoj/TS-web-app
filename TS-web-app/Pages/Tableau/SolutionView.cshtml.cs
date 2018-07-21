using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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
        public void OnGet(ulong requestId, SolutionViewType solutionViewType, bool isSession = false) {
            ViewType = solutionViewType;
            AppSolutionEventRequest = isSession ? LoadRequestFromSession() : EventService.LoadAppSolutionEventById((int) requestId);
        }

        private AppSolutionEventRequest LoadRequestFromSession() {

            AppSolutionEventRequest =
                JsonConvert.DeserializeObject<AppSolutionEventRequest>(HttpContext.Session.GetString(TableauSolutionModel.RequestName));
            AppSolutionEventRequest.TableauSolution =
                JsonConvert.DeserializeObject<TableauSolution>(HttpContext.Session.GetString(TableauSolutionModel.SolutionName));

            return AppSolutionEventRequest;
        }
    }
}
