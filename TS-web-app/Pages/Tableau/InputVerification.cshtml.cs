using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Ts.Solver;
using TsWebApp.Controllers;
using TsWebApp.Exceptions;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {

    public class TableauSolutionModel : PageModel {

        public static readonly string SolutionName = typeof(TableauSolution).FullName;
        public static readonly string RequestName = typeof(AppSolutionEventRequest).FullName;

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

        public async Task<IActionResult> OnPost() {
            
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

                HttpContext.Session.SetString(SolutionName, JsonConvert.SerializeObject(tableauSolution));
                HttpContext.Session.SetString(RequestName, JsonConvert.SerializeObject(userRequest));
                
                await EventService.CreateAppSolutionRequest(userRequest, HttpContext.User);
                    
                return RedirectToPage("SolutionView",
                    new { isSession = true, solutionViewType = SolutionViewType.Text });
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
