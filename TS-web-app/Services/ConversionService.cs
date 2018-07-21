using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ts.IO;
using Ts.IO.Parser;
using TsWebApp.Exceptions;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class ConversionService {
        

        public (TableauInput tableauInput, UnparsedTableauInput unparsedModifiedTableauInput)
            ParseTableauInput(UnparsedTableauInput unparsedTableauInput) {

            if (!unparsedTableauInput.HasAtleastOneParseRequest()) {
                throw new ConversionException("Unparsed tableau input must contain atleast one formula to parse");
            }
            
            if ((from request in unparsedTableauInput.FormulaParseRequests
                where request.UnparsedTableauNode.Formula == null
                select request).Any()) {

                throw new ConstraintException("Unparsed tableau input contains null string as formula's string representation");
            }

            var parsedTableauNodes = new List<ParsedTableauNode>();

            try {
                foreach (var request in unparsedTableauInput.FormulaParseRequests) {

                    if (request.ErrorResponse != string.Empty) {
                        continue;
                    }

                    try {
                        var formula = FormulaFactory.Parse(request.UnparsedTableauNode.Formula);
                        parsedTableauNodes.Add(new ParsedTableauNode() {
                            Formula = formula,
                            TruthLabel = request.UnparsedTableauNode.TruthLabel
                        });
                    }
                    catch (ParseException ex) {
                        request.ErrorResponse = ex.Message;
                    }
                }
            }
            catch (Exception ex) {
                throw new ConversionException($"Formula parser exception {ex.Message}");
            }

            if (unparsedTableauInput.HasErrorResponse()) return (new TableauInput(), unparsedTableauInput);

            var tableauInput = new TableauInput() {

                Root = new TableauInputNode() {
                        Formula = parsedTableauNodes[0].Formula,
                        TruthValue = parsedTableauNodes[0].TruthLabel
                    },
                TheoryAxioms = (from request in parsedTableauNodes.Skip(1)
                    let axiom = new TableauInputNode() { Formula = request.Formula, TruthValue = request.TruthLabel} select axiom).ToList()
            };

            return (tableauInput, new UnparsedTableauInput());
        }
    }
}
