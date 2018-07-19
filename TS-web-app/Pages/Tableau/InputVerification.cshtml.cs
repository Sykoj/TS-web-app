using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ts.Solver;
using TsWebApp.Controllers;
using TsWebApp.Exceptions;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {

    public class TableauSolutionModel : PageModel {

        public UnparsedTableauInput ErrorResponseForm { get; set; }

        private TsController Controller { get; set; }
        private ConversionService ConversionService { get; set; }
        private EventService EventService { get; set; }
        private Solver TableauSolverService { get; set; }

        public TableauSolutionModel(
            TsController controller,
            ConversionService conversionService,
            EventService eventService,
            Solver tableauSolverService) {

            Controller = controller;
            ConversionService = conversionService;
            EventService = eventService;
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

                var tableauSolution = Controller.GetSolution(tableauInput);

                var userRequest = new AppSolutionEventRequest() {                    
                    TableauType = TableauSolutionCategorizer.CategorizeTableauSolution(tableauSolution.SolutionNode),
                    ExpectedTableauType = unparsedTableauInput.ExpectedTableauType,
                    SolutionId = tableauSolution.SolutionId
                };

                var result = EventService.CreateAppSolutionRequest(userRequest, HttpContext.User);

                return RedirectToPage("SolutionView",
                    new { requestId = result.RequestId, solutionViewType = SolutionViewType.Text });
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
