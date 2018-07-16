using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TsWebApp.Exceptions;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {

    public class TableauSolutionModel : PageModel {

        public UnparsedTableauInput ErrorResponseForm { get; set; }
        
        private ConversionService ConversionService { get; set; }
        private EventService EventService { get; set; }
        private IFormulaParser FormulaParser { get; set; }
        private ITableauSolver TableauSolverService { get; set; }

        public TableauSolutionModel(
            ConversionService conversionService,
            EventService eventService,
            IFormulaParser formulaParser,
            ITableauSolver tableauSolverService) {

            ConversionService = conversionService;
            EventService = eventService;
            FormulaParser = formulaParser;
            TableauSolverService = tableauSolverService;
        }

        public IActionResult OnPost() {
            
            try {
                var unparsedTableauInput = FormResolver.ResolveForm(HttpContext.Request.Form);
                var (tableauInput, errorForm) = ConversionService.ParseTableauInput(unparsedTableauInput);

                if (errorForm.HasErrorResponse()) {
                    ErrorResponseForm = errorForm;
                    return Page();
                }
                
                var tableauSolution = TableauSolverService.SolveTableauInput(tableauInput);
                HttpContext.Session.SetString(HttpContext.Session.Id, JsonConvert.SerializeObject(tableauSolution));
                var result = EventService.LogSolutionEvent(unparsedTableauInput, tableauSolution, HttpContext.User);
                return RedirectToPage("SolutionView",
                    new { id = result.Id, session = HttpContext.Session.Id, solutionViewType = SolutionViewModel.SolutionViewType.Text });
            }
            catch (FormResolverException) {
                return RedirectToPage("../Error");
            }
            catch (TableauSolverException) {
                return RedirectToPage("../Error");
            }
        }
    }
}
