using Microsoft.AspNetCore.Mvc;
using Ts.IO;
using Ts.Solver;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Controllers {

    [Route("api/")]
    public class TsController : Controller {

        private EventService EventService { get; }
        private Solver TableauSolver { get; }

        public TsController(Solver tableauSolver, EventService eventService) {
            EventService = eventService;
            TableauSolver = tableauSolver;
        }

        [HttpPost("solve-tableau")]
        public TableauSolution GetSolution([FromBody] TableauInput tableauInput) {

            var solutionTableau = TableauSolver.Solve(tableauInput);

            var tableauRequest = new TableauSolution() {
                SolutionNode = solutionTableau,
                TableauInput = tableauInput
            };
            
            return EventService.LogTableauSolution(tableauRequest);
        }

        [HttpGet("solutions/{solutionId}")]
        public TableauSolution GetResponse([FromRoute] ulong solutionId) {

            return EventService.GetTableauRequest(solutionId);
        }
    }
}