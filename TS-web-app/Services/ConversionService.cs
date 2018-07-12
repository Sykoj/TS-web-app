using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TableauxIO;
using TableauxIO.Parser;
using TsWebApp.Exceptions;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class ConversionService {

        private IFormulaParser FormulaParser { get; set; }

        public ConversionService(IFormulaParser formulaParser) {
            FormulaParser = formulaParser;
        }
        
        public (TableauInput tableauInput, UnparsedTableauInput unparsedModifiedTableauInput)
            ParseTableauInput(UnparsedTableauInput unparsedTableauInput) {

            if (!unparsedTableauInput.HasAtleastOneParseRequest()) {
                throw new ConversionException("Unparsed tableau input must contain atleast one formula to parse");
            }
            if (unparsedTableauInput.HasErrorResponse()) {
                return (new TableauInput(), unparsedTableauInput);
            }
            if ((from request in unparsedTableauInput.FormulaParseRequests
                where request.UnparsedTableauNode.Formula == null
                select request).Any()) {

                throw new ConstraintException("Unparsed tableau input contains null string as formula's string representation");
            }

            var parsedTableauNodes = new List<ParsedTableauNode>();

            try {
                foreach (var request in unparsedTableauInput.FormulaParseRequests) {

                    try {
                        var formula = FormulaParser.ParseFormula(request.UnparsedTableauNode.Formula);
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

                Root = (parsedTableauNodes[0].Formula, parsedTableauNodes[0].TruthLabel),
                TheoryAxioms = (from request in parsedTableauNodes.Skip(1)
                    let axiom = (request.Formula, request.TruthLabel) select axiom).ToList()
            };

            return (tableauInput, new UnparsedTableauInput());
        }
    }
}
