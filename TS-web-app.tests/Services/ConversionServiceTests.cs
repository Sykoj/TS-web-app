using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TableauxIO.Parser;
using TableauxIO;
using TsWebApp.Exceptions;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.tests.Services {

    [TestClass]
    public class ConversionServiceTests {

        private UnparsedTableauInput _inputSingleFormula =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        RawFormula = new RawFormula() {
                            Formula = "p IMP q",
                            TruthLabel = TruthValue.False
                        }
                    }
                }
            };

        private UnparsedTableauInput _inputTwoFormulas =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        RawFormula = new RawFormula() {
                            Formula = "p IMP q",
                            TruthLabel = TruthValue.False
                        }
                    },
                    new FormulaParseRequest() {

                        RawFormula = new RawFormula() {
                            Formula = "p IMP q",
                            TruthLabel = TruthValue.True
                        }
                    }
                }
            };

        private UnparsedTableauInput _inputDuplicitFormulas =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        RawFormula = new RawFormula() {
                            Formula = "p IMP q",
                            TruthLabel = TruthValue.True
                        }
                    },
                    new FormulaParseRequest() {

                        RawFormula = new RawFormula() {
                            Formula = "p IMP q",
                            TruthLabel = TruthValue.True
                        }
                    }
                }
            };

        [TestInitialize]
        public void InitializeMocks() {
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        [ExpectedException(typeof(ConversionException))]
        public void ParseTableauInputThrowsOnEmptyUnparsedInput() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.Setup(t => t.ParseFormula(It.IsAny<string>())).Returns(new VariableFormula('m'));

            var conversionService = new ConversionService(formulaParser.Object);
            conversionService.ParseTableauInput(new UnparsedTableauInput());
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        [ExpectedException(typeof(ConversionException))]
        public void FormulaParserUnknownExceptionThrowsConversionException() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.Setup(t => t.ParseFormula(It.IsAny<string>())).Throws(new NullReferenceException());

            var conversionService = new ConversionService(formulaParser.Object);
            conversionService.ParseTableauInput(_inputSingleFormula);
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void CreatesErrorResponseOnParserException() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.Setup(t => t.ParseFormula(It.IsAny<string>())).Throws(new ParseException());

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputSingleFormula);

            Assert.IsTrue(errorResponse.HasErrorResponse());
            Assert.IsTrue(errorResponse.FormulaParseRequests.Count == 1);
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void ShouldFindError() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.SetupSequence(t => t.ParseFormula(It.IsAny<string>()))
                .Returns(new VariableFormula('n'))
                .Throws(new ParseException());

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputTwoFormulas);

            Assert.IsTrue(errorResponse.HasErrorResponse() && errorResponse.FormulaParseRequests.Count == 2);
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void DuplicitRawFormulasAllowed() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.SetupSequence(t => t.ParseFormula(It.IsAny<string>()))
                .Returns(new VariableFormula('n'))
                .Returns(new VariableFormula('n'));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputDuplicitFormulas);

            formulaParser.Verify(f => f.ParseFormula(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void DuplicitFormulasShouldNotBeEqual() {

            var f = _inputDuplicitFormulas.FormulaParseRequests[0].RawFormula;
            var c = _inputDuplicitFormulas.FormulaParseRequests[1].RawFormula;
            Assert.IsFalse(f.Equals(c));
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void ParserCorrectlyToTableauInput() {

            var formulaParser = new Mock<IFormulaParser>();
            formulaParser.SetupSequence(t => t.ParseFormula(It.IsAny<string>()))
                .Returns(new VariableFormula('a'))
                .Returns(new VariableFormula('b'));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputTwoFormulas);

            formulaParser.Verify(f => f.ParseFormula(It.IsAny<string>()), Times.Exactly(2));

            Assert.AreEqual(new VariableFormula('a'), tableauInput.Root.Item1);
            Assert.AreEqual(new VariableFormula('b'), tableauInput.TheoryAxioms[0].Item1);
            Assert.AreEqual(tableauInput.Root.Item2, _inputTwoFormulas.FormulaParseRequests[0].RawFormula.TruthLabel);
            Assert.AreEqual(tableauInput.TheoryAxioms[0].Item2, _inputTwoFormulas.FormulaParseRequests[1].RawFormula.TruthLabel);

            Assert.IsTrue(!errorResponse.HasErrorResponse());
        }
    }
}
