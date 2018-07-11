using TableauxIO;

namespace TsWebApp.Services {

    public class FormulaParser : IFormulaParser {

        public Formula ParseFormula(string rawFormula) {

            return FormulaFactory.Parse(rawFormula);
        }
    }
}
