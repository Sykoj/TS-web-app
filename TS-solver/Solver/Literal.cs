using Ts.IO;

namespace Ts.Solver {
    
    internal struct Literal {
        
        internal char Symbol { get; }
        internal TruthLabel TruthLabel { get; }

        internal Literal(char symbol, TruthLabel truthLabel) {
            Symbol = symbol;
            TruthLabel = truthLabel;
        }

        internal Literal GetOppositeLiteral() {

            var oppositeValue = TruthLabel.True == TruthLabel ? TruthLabel.False : TruthLabel.True;
            return new Literal(Symbol, oppositeValue);            
        }
    }
}
