using Newtonsoft.Json;

namespace Ts.IO {
    
    public abstract class UnaryFormula : Formula {
        
        [JsonProperty("subformula")]
        public Formula Subformula { get; }

        protected UnaryFormula(Formula subformula) {
            Subformula = subformula;
        }
        
        public override bool Equals(object obj) {
            return obj is UnaryFormula u && u.Subformula.Equals(Subformula);
        }

        public override int GetHashCode() {

            unchecked {
                var hash = 27;
                hash = (13 * hash) + Subformula.GetHashCode();
                return hash;
            }
        }
    }
}
