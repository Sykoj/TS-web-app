using Newtonsoft.Json;

namespace Ts.IO {
    
    public abstract class BinaryFormula : Formula {
        
        [JsonProperty("rightFormula")]
        public Formula RightFormula { get; }
        [JsonProperty("leftFormula")]
        public Formula LeftFormula { get; }

        protected BinaryFormula(Formula leftFormula, Formula rightFormula) {
            RightFormula = rightFormula;
            LeftFormula = leftFormula;
        }

        public override bool Equals(object obj) {

            if (!(obj is BinaryFormula other)) return false;
            return RightFormula.Equals(other.RightFormula)
                   && LeftFormula.Equals(other.LeftFormula);
        }

        public override int GetHashCode() {

            unchecked {
                var hash = 27;
                hash = (13 * hash) + RightFormula.GetHashCode();
                hash = (13 * hash) + LeftFormula.GetHashCode();
                return hash;
            }
        }
    }
}
