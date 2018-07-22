namespace Ts.IO.Parser {

    internal struct Token {

        internal Token(TokenBounds bounds, TokenType type) {
            Bounds = bounds;
            Type = type;
        }
        internal TokenType Type { get; }
        internal TokenBounds Bounds { get; }

        internal enum TokenType {
            Subformula,
            Variable,
            Junction
        }
    }

    internal struct TokenBounds {
        
        internal TokenBounds(int start, int end) {
            Start = start;
            End = end;
        }

        internal int Start { get; }
        internal int End { get; }
    }
}
