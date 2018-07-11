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

        public static UnparsedTableauInput CreateResponseFormWithErrors(
            UnparsedTableauInput unparsedTableauInput,
            List<(RawFormula formula, string response)> errorResponses) {

            var newRequests =
                from request in unparsedTableauInput.FormulaParseRequests
                let x = new FormulaParseRequest() {

                    RawFormula = request.RawFormula,
                    ErrorResponse = (from error in errorResponses
                        where error.formula.Equals(request.RawFormula)
                        select error.response).FirstOrDefault()
                }
                select x;

            return new UnparsedTableauInput() {
                FormulaParseRequests = new List<FormulaParseRequest>(newRequests)
            };
        }

        public (TableauInput tableauInput, UnparsedTableauInput errorForm) ParseTableauInput(
            UnparsedTableauInput unparsedTableauInput) {

            if (!unparsedTableauInput.HasAtleastOneParseRequest()) {
                throw new ConversionException("Unparsed tableau input must contain atleast one formula to parse");
            }
            
            if (unparsedTableauInput.HasErrorResponse()) {
                return (new TableauInput(), unparsedTableauInput);
            }

            if ((from request in unparsedTableauInput.FormulaParseRequests
                where request.RawFormula.Formula == null
                select request).Any()) {

                throw new ConstraintException("Unparsed tableau input contains null string as formula's string representation");
            }
 
            var errorResponses = new ConcurrentDictionary<RawFormula, string>();
            var parsedFormulas = new ConcurrentDictionary<RawFormula, Formula>();

            try {
                Parallel.ForEach(unparsedTableauInput.FormulaParseRequests,
                    request => {
                        try {
                            var formula = FormulaParser.ParseFormula(request.RawFormula.Formula);
                            parsedFormulas.TryAdd(request.RawFormula, formula);
                        }
                        catch (ParseException ex) {
                            errorResponses.TryAdd(request.RawFormula, ex.Message);
                        }
                    });
            }
            catch (AggregateException ex) {
                throw new ConversionException($"Formula parser exception {ex.Message}");
            }

            if (!errorResponses.IsEmpty) {
                return (new TableauInput(), CreateResponseFormWithErrors(unparsedTableauInput,
                    (from entry in errorResponses let error = (entry.Key, entry.Value) select error).ToList())
                    );
            }

            var tableauInput = new TableauInput() {

                Root = (parsedFormulas[unparsedTableauInput.FormulaParseRequests[0].RawFormula],
                    unparsedTableauInput.FormulaParseRequests[0].RawFormula.TruthLabel),

                TheoryAxioms = (from requests in unparsedTableauInput.FormulaParseRequests.Skip(1)
                    let axiom = (parsedFormulas[requests.RawFormula], requests.RawFormula.TruthLabel)
                    select axiom).ToList()
            };

            return (tableauInput, new UnparsedTableauInput());
        }
    }
}
