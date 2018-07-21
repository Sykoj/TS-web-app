using Microsoft.AspNetCore.Mvc;
using Ts.IO;
using TsWebApp.Services;
using TsWebApp.Extensions;
using TsWebApp.Utilities;

namespace TsWebApp.Controllers {

    [Route("api/")]
    public class TsController : Controller {

        private EventService EventService { get; }
        private TableauSolutionService TableauSolutionService { get; } 
        private FormulaValidator FormulaValidator { get; }

        public TsController(
            TableauSolutionService tableauSolutionService,
            EventService eventService,
            FormulaValidator formulaValidator) {
            EventService = eventService;
            TableauSolutionService = tableauSolutionService;
            FormulaValidator = formulaValidator;
        }

        [HttpPost("solve-tableau")]
        public IActionResult GetSolution([FromBody] TableauInput tableauInput) {

            if (tableauInput == null || !tableauInput.Root.Formula.Apply(FormulaValidator)) {
                return BadRequest("The request could not be understood by the server due to malformed syntax.");
            }

            var tableauSolution = TableauSolutionService.ComputeTableauSolution(tableauInput);
            EventService.LogTableauSolution(tableauSolution);

            return Ok(tableauSolution);
        }

        [HttpGet("solutions/{solutionId}")]
        public IActionResult GetResponse([FromRoute] int solutionId) {

            var solution = EventService.GetTableauRequest(solutionId);
            if (solution == null) {
                return NotFound($"Tableau solution with ID={solutionId} not found.");
            }

            return Ok(solution);
        }
    }
}