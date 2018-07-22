using Ts.IO.Utilities;

namespace Ts.IO {

    /// <summary>
    /// Provides functionality to convert possible representations of formula to it's labeled ordered tree representation
    /// </summary>
    public static class FormulaFactory {

        /// <summary>
        /// Parses and converts input from argument to formula
        /// </summary>
        /// <exception cref="Parser.ParseException">Thrown if input can't be represented as formula</exception>
        /// <param name="unparsedFormula">String representing formula</param>
        /// <returns>Formula representing the input</returns>
        public static Formula Parse(string unparsedFormula) {

            var parser = new Parser.Parser(unparsedFormula);
            return parser.ParseFormula();
        }
    }
}
