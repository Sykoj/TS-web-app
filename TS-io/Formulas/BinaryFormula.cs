using Newtonsoft.Json;

namespace Ts.IO {

    /// <summary>
    /// Propositional formula in form of labeled ordered tree
    /// This node represents root of the tree with two subformulas as childs
    /// </summary>
    public abstract class BinaryFormula : Formula {

        /// <summary>
        /// The subformula representing the right subtree of the labeled tree of the binary formula
        /// </summary>
        [JsonProperty("rightSubformula")]
        public Formula RightSubformula { get; }

        /// <summary>
        /// The subformula representing the left subtree of the labeled tree of the binary formula
        /// </summary>
        [JsonProperty("leftSubformula")]
        public Formula LeftSubformula { get; }

        protected BinaryFormula(Formula leftSubformula, Formula rightSubformula) {
            RightSubformula = rightSubformula;
            LeftSubformula = leftSubformula;
        }

        public override bool Equals(object obj) {

            if (!(obj is BinaryFormula other)) return false;
            return RightSubformula.Equals(other.RightSubformula)
                   && LeftSubformula.Equals(other.LeftSubformula);
        }

        public override int GetHashCode() {

            unchecked {
                var hash = 27;
                hash = (13 * hash) + RightSubformula.GetHashCode();
                hash = (13 * hash) + LeftSubformula.GetHashCode();
                return hash;
            }
        }
    }
}
