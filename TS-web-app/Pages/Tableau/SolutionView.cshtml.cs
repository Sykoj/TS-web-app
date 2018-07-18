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

        public TableauSolutionEvent TableauSolutionEvent { get; set; }
        
        public EventService EventService { get; }

        public TableauSolver TableauSolver { get; }

        public SolutionViewModel(EventService eventService, TableauSolver tableauSolver) {
            EventService = eventService;
            TableauSolver = tableauSolver;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong id, string session, SolutionViewType solutionViewType) {

            ViewType = solutionViewType;
            TableauSolutionEvent = EventService.LoadTableauSolutionEventById(id);
            
            if (session != null) {

                var solutionJson = HttpContext.Session.GetString(session);
                var result = JsonConvert.DeserializeObject<TableauOutput>(solutionJson);
                TableauSolutionEvent.Solution = result.SolutionNode;
            }
            else {
                TableauSolutionEvent.Solution = TableauSolver.GetTableauInput(
                    (long) TableauSolutionEvent.SolverRequestId).SolutionNode;
            }
        }
    }
}
