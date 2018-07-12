using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Http;
using TableauxIO;
using TsWebApp.Exceptions;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class FormResolver {
        
        public static UnparsedTableauInput ResolveForm(IFormCollection requestForm) {

            var formRows = new List<FormRow>();
            uint index = 0;
               
            while (TryGetFormRow(out var formRow, index, requestForm)) { 

                formRows.Add(formRow);
                ++index;
            }

            var formulaParseRequests = 
                from row in formRows
                let formulaParseRequest = new FormulaParseRequest() {
                    ErrorResponse = row.ErrorResponse,
                    UnparsedTableauNode = new UnparsedTableauNode() {Formula = row.Formula, TruthLabel = row.TruthLabel}
                }
                select formulaParseRequest;

            var unparsedTableauInput = new UnparsedTableauInput() {
                FormulaParseRequests = new List<FormulaParseRequest>(formulaParseRequests)
            };
 
            if (unparsedTableauInput.HasAtleastOneParseRequest()) {
                return unparsedTableauInput;
            }
            else {
                throw new FormResolverException();
            }
        }

        public static bool TryGetFormRow(out FormRow formRow, uint index, IFormCollection requestForm) {

            var hasFormula = requestForm.TryGetValue($"Formula[{index}]", out var formula);
            var hasErrorResponse = requestForm.TryGetValue($"ErrorResponse[{index}]", out var errorResponse);
            var hasTruthLabel = requestForm.TryGetValue($"TruthLabel[{index}]", out var truthLabel);

            if (hasFormula && hasErrorResponse && hasTruthLabel) {

                formRow = new FormRow() {
                    Formula = formula,
                    TruthLabel = StringToTruthValueExtension.ConvertFromString(truthLabel),
                    ErrorResponse = errorResponse
                };
                return true;
            }
            else if (!hasFormula && !hasErrorResponse && !hasTruthLabel) {

                formRow = null;
                return false;
            }
            else {
                throw new FormResolverException();
            }
        } 
    }

    public class FormRow {

        public string Formula { get; set; }
        public TruthValue TruthLabel { get; set; }
        public string ErrorResponse { get; set; }
    }

    internal static class StringToTruthValueExtension {

        public static TruthValue ConvertFromString(this string converted) {

            if (converted == "0") return TruthValue.False;
            if (converted == "1") return TruthValue.True;
            else throw new InvalidEnumArgumentException();
        }
    }
}
