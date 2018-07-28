using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ts.App.Exceptions;
using Ts.App.Model;
using Ts.App.Services;
using Ts.IO;
using Ts.IO.Parser;

namespace Ts.App.Tests.Services {

    [TestClass]
    public class ConversionServiceTests {

        private readonly UnparsedTableauInput _inputSingleFormula =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        UnparsedTableauNode = new UnparsedTableauNode() {
                            Formula = "p IMP q",
                            TruthLabel = TruthLabel.False
                        }
                    }
                }
            };

        private readonly UnparsedTableauInput _inputTwoFormulas =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        UnparsedTableauNode = new UnparsedTableauNode() {
                            Formula = "p IMP q",
                            TruthLabel = TruthLabel.False
                        }
                    },
                    new FormulaParseRequest() {

                        UnparsedTableauNode = new UnparsedTableauNode() {
                            Formula = "p IMP q",
                            TruthLabel = TruthLabel.True
                        }
                    }
                }
            };

        private readonly UnparsedTableauInput _inputDuplicitFormulas =
            new UnparsedTableauInput {
                FormulaParseRequests = new List<FormulaParseRequest>() {
                    new FormulaParseRequest() {

                        UnparsedTableauNode = new UnparsedTableauNode() {
                            Formula = "p IMP q",
                            TruthLabel = TruthLabel.True
                        }
                    },
                    new FormulaParseRequest() {

                        UnparsedTableauNode = new UnparsedTableauNode() {
                            Formula = "p IMP q",
                            TruthLabel = TruthLabel.True
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

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.Setup(t => t.Parse(It.IsAny<string>())).Returns(new VariableFormula('m'));

            var conversionService = new ConversionService(formulaParser.Object);
            conversionService.ParseTableauInput(new UnparsedTableauInput());
            
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        [ExpectedException(typeof(ConversionException))]
        public void FormulaParserUnknownExceptionThrowsConversionException() {

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.Setup(t => t.Parse(It.IsAny<string>())).Throws(new NullReferenceException());

            var conversionService = new ConversionService(formulaParser.Object);
            conversionService.ParseTableauInput(_inputSingleFormula);
            
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void CreatesErrorResponseOnParserException() {

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.Setup(t => t.Parse(It.IsAny<string>())).Throws(new ParseException("..."));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputSingleFormula);

            Assert.IsTrue(errorResponse.HasErrorResponse());
            Assert.IsTrue(errorResponse.FormulaParseRequests.Count == 1);
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void ShouldFindError() {

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.SetupSequence(t => t.Parse(It.IsAny<string>()))
                .Returns(new VariableFormula('n'))
                .Throws(new ParseException("..."));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputTwoFormulas);

            Assert.IsTrue(errorResponse.HasErrorResponse());
            Assert.IsTrue(errorResponse.FormulaParseRequests.Count == 2);
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void DuplicitRawFormulasAllowed() {

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.SetupSequence(t => t.Parse(It.IsAny<string>()))
                .Returns(new VariableFormula('n'))
                .Returns(new VariableFormula('n'));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputDuplicitFormulas);

            formulaParser.Verify(f => f.Parse(It.IsAny<string>()), Times.Exactly(2));
        }

        [TestMethod]
        [TestCategory("ParseTableauInput")]
        public void ParserCorrectlyToTableauInput() {

            var formulaParser = new Mock<IFormulaFactory>();
            formulaParser.SetupSequence(t => t.Parse(It.IsAny<string>()))
                .Returns(new VariableFormula('a'))
                .Returns(new VariableFormula('b'));

            var conversionService = new ConversionService(formulaParser.Object);
            var (tableauInput, errorResponse) = conversionService.ParseTableauInput(_inputTwoFormulas);

            formulaParser.Verify(f => f.Parse(It.IsAny<string>()), Times.Exactly(2));

            Assert.AreEqual(new VariableFormula('a'), tableauInput.TableauRoot.Formula);
            Assert.AreEqual(new VariableFormula('b'), tableauInput.TheoryAxioms[0].Formula);
            Assert.AreEqual(tableauInput.TableauRoot.TruthLabel, _inputTwoFormulas.FormulaParseRequests[0].UnparsedTableauNode.TruthLabel);
            Assert.AreEqual(tableauInput.TheoryAxioms[0].TruthLabel, _inputTwoFormulas.FormulaParseRequests[1].UnparsedTableauNode.TruthLabel);

            Assert.IsTrue(!errorResponse.HasErrorResponse());
        }
    }
}