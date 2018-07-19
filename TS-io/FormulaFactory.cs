namespace Ts.IO {

    public static class FormulaFactory {

        public static Formula Parse(string unparsedFormula) {

            var parser = new Parser.Parser(unparsedFormula.RemoveWhitespace());
            return parser.ParseFormula();
        }
    }
}
