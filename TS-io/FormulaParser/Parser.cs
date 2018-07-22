using System;
using static Ts.IO.Parser.Token;
using System.Collections.Generic;
using Ts.IO.Utilities;

namespace Ts.IO.Parser {

    internal class Parser {
        
        private TokenFactory Factory { get; }
        private string UnparsedFormula { get; }

        internal Parser(string unparsedFormula) {

            UnparsedFormula = unparsedFormula.RemoveWhitespace();

            if (unparsedFormula.Length == 0) {
                throw new ParseException("The length of formula is 0. The length of formulas must be greater than 0.");
            }

            Factory = new TokenFactory(unparsedFormula);
        }

        internal Parser(TokenFactory factory) {
            Factory = factory;
        }

        internal Formula ParseFormula() {
            var tokens = GetFormulaTokens();
            return AssembleFormula(tokens);
        }

        private List<Token> GetFormulaTokens() {

            var tokens = new List<Token>();
            var position = Factory.Start;

            while (position != Factory.End) {

                var (token, endPosition) = Factory.GetToken(position);

                tokens.Add(token);
                position = endPosition;
            }

            return tokens;
        }

        private Formula AssembleFormula(IReadOnlyList<Token> tokens) {

            if (tokens.Count == 3)
                return AssembleBinaryFormula(tokens);
            else if (tokens.Count == 2) {
                return AssembleUnaryFormula(tokens);
            }
            else if (tokens.Count == 1 && tokens[0].Type == TokenType.Variable) {
                return AssembleVariable(tokens[0]);
            }
            else if (tokens.Count == 1 && tokens[0].Type == TokenType.Subformula) {
                return AssembleSubformula(tokens[0]);
            }

            throw new ParseException("Structure of formula not recognized.");
        }

        private Formula AssembleFormula(Token token) {

            switch (token.Type) {
                case TokenType.Variable:
                    return AssembleVariable(token);
                case TokenType.Subformula:
                    return AssembleSubformula(token);
                case TokenType.Junction:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new ParseException($"Format of subformula at index {token.Bounds.Start} of {UnparsedFormula} not recognized");
        }

        private Formula AssembleBinaryFormula(IReadOnlyList<Token> tokens) {

            var leftSubformula = AssembleFormula(tokens[0]);
            var rightSubformula = AssembleFormula(tokens[2]);

            if (tokens[1].Type != TokenType.Junction)
                throw new ParseException($"Format of binary formula at index {tokens[0].Bounds.Start} of {UnparsedFormula} not recognized");

            var junction = Factory.GetJunction(tokens[1].Bounds);
            if (junction == Junctions.Imp) return new ImplicationFormula(leftSubformula, rightSubformula);
            if (junction == Junctions.Ekv) return new EquivalenceFormula(leftSubformula, rightSubformula);
            if (junction == Junctions.And) return new ConjuctionFormula(leftSubformula, rightSubformula);
            if (junction == Junctions.Or) return new DisjunctionFormula(leftSubformula, rightSubformula);

            throw new ParseException($"Format of binary formula at index {tokens[0].Bounds.Start} of {UnparsedFormula} not recognized");
        }

        private Formula AssembleUnaryFormula(IReadOnlyList<Token> tokens) {

            if (tokens[0].Type == TokenType.Junction && Factory.GetJunction(tokens[0].Bounds) == Junctions.Not) {
                return new NegationFormula(AssembleFormula(tokens[1]));
            }
            throw new ParseException($"Format of unary formula at index {tokens[0].Bounds.Start} of {UnparsedFormula} not recognized");
        }


        private Formula AssembleSubformula(Token token) {

            var factory = Factory.GetNewBounds(token.Bounds);
            var parser = new Parser(factory);
            return parser.ParseFormula();
        }

        private Formula AssembleVariable(Token token) {

            return new VariableFormula(Factory.GetChar(token.Bounds));
        }
    }
}
