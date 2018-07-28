using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Ts.App.Exceptions;
using Ts.App.Model;
using Ts.IO;

namespace Ts.App.Services {

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

            if (!(requestForm.TryGetValue($"{nameof(UnparsedTableauInput.ExpectedTableauType)}", out var expectedType) 
                && Enum.TryParse(typeof(TableauType), expectedType[0], out var tableauExpectedType))) {
                throw new FormResolverException();
            }

            var unparsedTableauInput = new UnparsedTableauInput() {
                FormulaParseRequests = new List<FormulaParseRequest>(formulaParseRequests),
                ExpectedTableauType = (TableauType) tableauExpectedType
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

            if (!hasTruthLabel) truthLabel = "off";

            if (hasFormula && hasErrorResponse) {

                formRow = new FormRow() {
                    Formula = formula,
                    TruthLabel = ((string) truthLabel).ConvertFromString(),
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
        public TruthLabel TruthLabel { get; set; }
        public string ErrorResponse { get; set; }
    }

    internal static class StringToTruthValueExtension {

        public static TruthLabel ConvertFromString(this string converted) {

            if (converted == "off") return TruthLabel.False;
            if (converted == "on") return TruthLabel.True;
            else throw new InvalidEnumArgumentException();
        }
    }
}
