using Newtonsoft.Json;

namespace Ts.IO {
    
    public class VariableFormula : Formula {
        
        [JsonProperty("symbol")]
        public char Symbol { get; }

        public VariableFormula(char symbol) {
            Symbol = symbol;
        }

        public override bool Equals(object obj) {
            
            if (obj is VariableFormula v) {
                if (v.Symbol == Symbol) return true;
            }
            return false;
        }

        public override int GetHashCode() {

            unchecked {
                var hash = 27;
                hash = (13 * hash) + Symbol.GetHashCode();
                return hash;
            }
        }
    }
}
