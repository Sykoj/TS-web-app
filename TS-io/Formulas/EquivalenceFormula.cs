namespace Ts.IO {

    /// <inheritdoc cref="BinaryFormula"/>
    public sealed class EquivalenceFormula : BinaryFormula {

        public EquivalenceFormula(Formula leftSubformula, Formula rightSubformula) :
            base(leftSubformula, rightSubformula) {
        }
    }
}
