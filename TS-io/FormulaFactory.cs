namespace Ts.IO {
    
    /// <inheritdoc cref="IFormulaFactory"/>
    public class FormulaFactory : IFormulaFactory {

        /// <summary>
        /// Parses and converts input from argument to formula
        /// </summary>
        /// <exception cref="Parser.ParseException">Thrown if input can't be represented as formula</exception>
        /// <param name="unparsedFormula">String representing formula</param>
        /// <returns>Formula representing the input</returns>
        public Formula Parse(string unparsedFormula) {

            var parser = new Parser.Parser(unparsedFormula);
            return parser.ParseFormula();
        }
    }
}
