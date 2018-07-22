using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ts.IO.Parser;

namespace Ts.IO.tests {

    [TestClass]
    public class ParserTests {

        [TestMethod]
        public void ParserDoNotThrowParserException() {

            FormulaFactory.Parse("p IMP (q IMP p)");
            FormulaFactory.Parse("(p IMP (q IMP p))");
            FormulaFactory.Parse("(p EKV (NOT (NOT p)))");
            FormulaFactory.Parse("(NOT (p OR q)) EKV ((NOT p) AND (NOT q))");
            FormulaFactory.Parse("(p IMP q) EKV ((NOT q) IMP (NOT p))");
            FormulaFactory.Parse("(p IMP (q IMP r)) IMP ((p IMP q) IMP (p IMP r))");
            FormulaFactory.Parse("(p IMP (q IMP r)) IMP ((p IMP q) IMP (p IMP r))");
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void ParserDontAcceptsOmmitedParenthesisWithNoAmbiguity() {

            FormulaFactory.Parse("p IMP NOT q");
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void ParserDontAcceptEmptyInput() {

            FormulaFactory.Parse("");
        }

        [TestMethod]
        public void VariableIsValidFormula() {

            FormulaFactory.Parse("p");
            FormulaFactory.Parse("(p)");
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void CaseSensivityOnJunctionsMatters() {

            FormulaFactory.Parse("q imp p");
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void CaseSensitivityOnVariablesMatters() {

            FormulaFactory.Parse("P");
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void InvalidInputThrows() {

            FormulaFactory.Parse("p IMP should throw");
        }

        [TestMethod]
        public void AcceptsMultipleNesting() {

            FormulaFactory.Parse("((p))");
        }
    }
}
