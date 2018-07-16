using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TableauxIO;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {
    public class TableauRequestModel : PageModel {

        public IList<FormulaParseRequest> FormulaParseRequests { get; set; }

        private FormResolver FormResolver { get; set; }

        public TableauRequestModel(FormResolver formResolver) {
            FormResolver = formResolver;
        }

        public void OnGet() {

            var initialRequest = new FormulaParseRequest() {
                UnparsedTableauNode = new UnparsedTableauNode() { Formula = string.Empty, TruthLabel = TruthValue.True },
                ErrorResponse = string.Empty
            };

            FormulaParseRequests = new List<FormulaParseRequest>() {
                initialRequest
            };
        }
        public void OnPost() {
            
           FormulaParseRequests = FormResolver.ResolveForm(HttpContext.Request.Form).FormulaParseRequests;
        }
    }
}
