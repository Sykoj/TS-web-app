using Ts.IO;

namespace TsWebApp.Utilities {

    public class FormulaValidator : IFormulaVisitor<bool> {

        public bool Visit(Formula formula) {

            if (formula == null) return false;

            switch (formula) {
                case BinaryFormula binaryFormula:
                    return Validate(binaryFormula);
                case UnaryFormula unaryFormula:
                    return Validate(unaryFormula);
                default:
                    return true;
            }
        }

        private bool Validate(UnaryFormula formula) {
            return Visit(formula.Subformula);
        }

        private bool Validate(BinaryFormula binaryFormula) {
            return Visit(binaryFormula.LeftFormula) && Visit(binaryFormula.RightFormula);
        }
    }
}
