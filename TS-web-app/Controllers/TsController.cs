using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
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

        /// <summary>
        /// Solves tableau from provided tableau input
        /// </summary>
        /// <response code="200">Returns tableau solution</response>
        /// <response code="400">The request could not be understood by the server due to malformed syntax</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("solve-tableau")]
        public IActionResult SolveTableau([FromBody] TableauInput tableauInput) {

            if (tableauInput == null || !HasValidFormulas(tableauInput)) {
                return BadRequest("The request could not be understood by the server due to malformed syntax.");
            }

            var tableauSolution = TableauSolutionService.ComputeTableauSolution(tableauInput);
            EventService.LogTableauSolution(tableauSolution);

            return Ok(tableauSolution);
        }

        /// <summary>
        /// Returns tableau solution for provided solution ID
        /// </summary>
        /// <remarks>valid solutionID can be generated from /solve-tableau</remarks>
        /// <response code="200">Returns tableau solution for provided solution ID</response>
        /// <response code="404">Tableau solution for provided solution ID not found</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Produces("application/json")]
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

    public class TsControllerSwaggerSchema : ISchemaFilter {

        public void Apply(Schema schema, SchemaFilterContext context) {

            if (context.SystemType == typeof(TableauInput)) {

                schema.Example = new TableauInput() {
                      
                    TableauRoot = new TableauInputNode() {
                        Formula = new ImplicationFormula(new VariableFormula('p'), new VariableFormula('q')),
                        TruthLabel = TruthLabel.False
                    },
                    TheoryAxioms = new List<TableauInputNode>() {
                        new TableauInputNode() {
                            Formula = new VariableFormula('p'),
                            TruthLabel = TruthLabel.False
                        }
                    }
                };
            }
        }
    }
}