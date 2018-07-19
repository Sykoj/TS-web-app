using static Ts.IO.Parser.Token;

namespace Ts.IO.Parser {
    
    public class TokenFactory {
        
        private string UnparsedFormula { get; }
        private TokenBounds Bounds { get; }
        internal int End => Bounds.End;
        internal int Start => Bounds.Start;

        public TokenFactory(string unparsedFormula) {
            UnparsedFormula = unparsedFormula;
            Bounds = new TokenBounds(0, unparsedFormula.Length);
        }

        public TokenFactory(string unparsedFormula, TokenBounds bounds) {
            UnparsedFormula = unparsedFormula;
            Bounds = bounds;
        }

        internal (Token token, int endPosition) GetToken(int startPosition) {

            var c = UnparsedFormula[startPosition];

            if (c == '(') {
                return GetUnparsedSubformula(startPosition);
            }
            if (char.IsUpper(c)) {
                return GetJunction(startPosition);
            }
            if (char.IsLower(c)) {
                return GetVariable(startPosition);
            }

            throw new ParseException($"Symbol {c} is not matching a start of new token as position {startPosition} of {UnparsedFormula}");
        }

        private (Token token, int endPosition) GetUnparsedSubformula(int startPosition) {

            var parenthesisDepth = 0;
            var position = startPosition;

            do {
                var character = UnparsedFormula[position];
                if (character == '(') ++parenthesisDepth;
                if (character == ')') --parenthesisDepth;
                ++position;

                if (position == End && parenthesisDepth > 0) {
                    throw new ParseException($"Depth of parenthesis of subformula starting at {startPosition} of {UnparsedFormula} is invalid");
                }

            } while (parenthesisDepth > 0);

            var token = new Token(new TokenBounds(startPosition + 1, position - 1), TokenType.Subformula);
            return (token, position);
        }

        private (Token token, int endPosition) GetVariable(int startPosition) {

            var token = new Token(new TokenBounds(startPosition, startPosition + 1), TokenType.Variable);
            return (token, startPosition + 1);
        }

        private (Token, int endPosition) GetJunction(int startPosition) {

            var position = startPosition;
            while (char.IsUpper(UnparsedFormula[position])) {
                ++position;
                if (position == End) break;
            }

            var token = new Token(new TokenBounds(startPosition, position), TokenType.Junction);
            return (token, position);
        }

        internal string GetJunction(TokenBounds bounds) {

            if (bounds.End - bounds.Start == 3) {

                if (UnparsedFormula[bounds.Start] == 'I'
                    && UnparsedFormula[bounds.Start + 1] == 'M'
                    && UnparsedFormula[bounds.Start + 2] == 'P') {
                    return Junctions.Imp;
                }

                if (UnparsedFormula[bounds.Start] == 'A'
                    && UnparsedFormula[bounds.Start + 1] == 'N'
                    && UnparsedFormula[bounds.Start + 2] == 'D') {
                    return Junctions.And;
                }

                if (UnparsedFormula[bounds.Start] == 'E'
                    && UnparsedFormula[bounds.Start + 1] == 'K'
                    && UnparsedFormula[bounds.Start + 2] == 'V') {
                    return Junctions.Ekv;
                }

                if (UnparsedFormula[bounds.Start] == 'N'
                    && UnparsedFormula[bounds.Start + 1] == 'O'
                    && UnparsedFormula[bounds.Start + 2] == 'T') {
                    return Junctions.Not;
                }
            }

            if (bounds.End - bounds.Start == 2) {

                if (UnparsedFormula[bounds.Start] == 'O'
                    && UnparsedFormula[bounds.Start + 1] == 'R') {
                    return Junctions.Or;
                }
            }

            throw new ParseException($"Token starting with uppercase symbol at index {bounds.Start} of {UnparsedFormula} was not recognized as junction.");
        }

        internal char GetChar(TokenBounds bounds) {
            return UnparsedFormula[bounds.Start];
        }

        internal TokenFactory GetNewBounds(TokenBounds bounds) {
            return new TokenFactory(UnparsedFormula, bounds);
        }
    }
}
