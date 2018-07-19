using Ts.IO;

namespace Ts.Solver {
    
    internal struct Literal {
        
        internal char Symbol { get; }
        internal TruthValue TruthValue { get; }

        internal Literal(char symbol, TruthValue truthValue) {
            Symbol = symbol;
            TruthValue = truthValue;
        }

        internal Literal GetOppositeLiteral() {

            var oppositeValue = TruthValue.True == TruthValue ? TruthValue.False : TruthValue.True;
            return new Literal(Symbol, oppositeValue);            
        }
    }
}
