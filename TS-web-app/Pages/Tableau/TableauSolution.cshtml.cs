﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
                Task.Run(() => EventService.LogSolutionEvent(tableauInput, tableauSolution, HttpContext.User));
                return RedirectToPage("SolutionView", new { session = HttpContext.Session.Id });
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
