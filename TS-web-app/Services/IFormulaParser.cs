using TableauxIO;

namespace TsWebApp.Services {

    public interface IFormulaParser {

        Formula ParseFormula(string rawFormula);
    }
}
