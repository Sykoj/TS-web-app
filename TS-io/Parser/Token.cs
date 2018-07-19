namespace Ts.IO.Parser {

    internal struct Token {

        public Token(TokenBounds bounds, TokenType type) {
            Bounds = bounds;
            Type = type;
        }
        public TokenType Type { get; }
        public TokenBounds Bounds { get; }

        public enum TokenType {
            Subformula,
            Variable,
            Junction
        }
    }

    public struct TokenBounds {
        
        public TokenBounds(int start, int end) {
            Start = start;
            End = end;
        }

        public int Start { get; }
        public int End { get; }
    }
}
