using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ts.App.Extensions;
using Ts.App.Services;
using Ts.App.Utilities;
using Ts.IO;

namespace Ts.App.Controllers {

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
        public IActionResult SolveTableau([FromBody] TableauInput tableauInput) {

            if (tableauInput == null || HasValidFormulas(tableauInput)) {
                return BadRequest("The request could not be understood by the server due to malformed syntax.");
            }

            var tableauSolution = TableauSolutionService.ComputeTableauSolution(tableauInput);
            EventService.LogTableauSolution(tableauSolution);

            return Ok(tableauSolution);
        }

        [HttpGet("solution/{solutionId}")]
        public IActionResult GetSolution([FromRoute] int solutionId) {

            var solution = EventService.GetTableauSolution(solutionId);
            if (solution == null) {
                return NotFound($"Tableau solution with ID={solutionId} not found.");
            }

            return Ok(solution);
        }

        private bool HasValidFormulas(TableauInput tableauInput) {

            return tableauInput.GetAllNodes().All(tableauInputNode => tableauInputNode.Formula.Apply(FormulaValidator));
        }
    }
}