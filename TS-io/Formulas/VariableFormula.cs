using Newtonsoft.Json;

namespace Ts.IO {
    
    /// <summary>
    /// Formula representing leaf of the labeled ordered tree which is variable
    /// </summary>
    public class VariableFormula : Formula {
        
        [JsonProperty("symbol")]
        public char Symbol { get; }

        public VariableFormula(char symbol) {
            Symbol = symbol;
        }

        public override bool Equals(object obj) {

            if (!(obj is VariableFormula v)) return false;
            return v.Symbol == Symbol;
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
