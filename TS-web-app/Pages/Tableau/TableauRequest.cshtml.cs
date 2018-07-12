using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using TableauxIO;
using TsWebApp.Exceptions;
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

    /*
    internal static class FormResolver {

        internal static IList<FormulaParseRequest> ResolveFormulas(IFormCollection formCollection) {

            var formulaParseRequests = new List<FormulaParseRequest>();

            var nodeCount = (formCollection.Count - 1) / 3;
            for (var i = 0; i < nodeCount; ++i) {

                var rawFormula = new RawFormula() {
                    Formula = formCollection[$"Formula[{i}]"],
                    TruthLabel = (formCollection[$"TruthLabel[{i}]"] == "1") ? TruthValue.True : TruthValue.False
                };

                formulaParseRequests.Add(new FormulaParseRequest() {
                    RawFormula = rawFormula,
                    ErrorResponse = formCollection[$"ErrorResponse[{i}]"]
                });
            }

            return formulaParseRequests;
        }

        public static TableauRequest Resolve(IFormCollection requestForm) {

            var tableauRequest = new TableauRequest();


            var index = 0;

            while (requestForm.TryGetValue($"Formula[{index}]", out var formula)) {

                if (!requestForm.TryGetValue($"TruthLabel[{index}]", out var truthLabel) 
                    || !(truthLabel == "1" || truthLabel == "0")) {
                    
                    throw new FormResolverException();
                }

                if (!requestForm.TryGetValue($"ErrorResponse[{index}]", out var errorResponse)) {
                    throw new FormResolverException();
                }

                tableauRequest.RawFormulas.Add(new RawFormula() {

                    Formula = formula,
                    TruthLabel = 
                });

                ++index;
            }
        }
    }*/
}
