using Newtonsoft.Json;

namespace Ts.IO {

    /// <summary>
    /// Prepositional formula in form of labeled ordered tree
    /// This node represents root of the tree with one formula as child
    /// </summary>
    public abstract class UnaryFormula : Formula {
        
        /// <summary>
        /// The subformula representing the subtree of the labeled tree of the unary formula
        /// </summary>
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
