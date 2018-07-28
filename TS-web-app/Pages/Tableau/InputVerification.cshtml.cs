using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Ts.App.Exceptions;
using Ts.App.Model;
using Ts.App.Services;

namespace Ts.App.Pages.Tableau {

    public class TableauSolutionModel : PageModel {

        public static readonly string SolutionName = typeof(TableauSolution).FullName;
        public static readonly string RequestName = typeof(AppSolutionRequest).FullName;

        public UnparsedTableauInput ErrorResponseForm { get; set; }

        private ConversionService ConversionService { get; }
        private EventService EventService { get; }
        private TableauSolutionService TableauSolutionService { get; }

        public TableauSolutionModel(
            ConversionService conversionService,
            EventService eventService,
            TableauSolutionService tableauSolutionService) {

            ConversionService = conversionService;
            EventService = eventService;
            TableauSolutionService = tableauSolutionService;
        }

        public async Task<IActionResult> OnPost() {
            
            try {
                var unparsedTableauInput = FormResolver.ResolveForm(HttpContext.Request.Form);
                var (tableauInput, errorForm) = ConversionService.ParseTableauInput(unparsedTableauInput);

                if (errorForm.HasErrorResponse()) {
                    ErrorResponseForm = errorForm;
                    return Page();
                }

                var tableauSolution = TableauSolutionService.ComputeTableauSolution(tableauInput);
                EventService.LogTableauSolution(tableauSolution);

                var userRequest = new AppSolutionRequest() {                    
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
        }
    }
}
