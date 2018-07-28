using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ts.App.Model;
using Ts.App.Services;
using Ts.IO;

namespace Ts.App.Pages.Tableau {

    public class TableauRequestModel : PageModel {

        public IList<FormulaParseRequest> FormulaParseRequests { get; set; }
        public TableauType ExpectedTableauType { get; set; }

        private FormResolver FormResolver { get; set; }

        public TableauRequestModel(FormResolver formResolver) {
            FormResolver = formResolver;
        }

        public void OnGet() {

            var initialRequest = new FormulaParseRequest() {
                UnparsedTableauNode = new UnparsedTableauNode() { Formula = string.Empty, TruthLabel = TruthLabel.False },
                ErrorResponse = string.Empty
            };

            FormulaParseRequests = new List<FormulaParseRequest>() {
                initialRequest
            };
        }
        public void OnPost() {

            var unparsedTableauInput = FormResolver.ResolveForm(HttpContext.Request.Form);
            FormulaParseRequests = unparsedTableauInput.FormulaParseRequests;
            ExpectedTableauType = unparsedTableauInput.ExpectedTableauType;
        }
    }
}
