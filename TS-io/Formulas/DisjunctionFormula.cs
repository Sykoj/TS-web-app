namespace Ts.IO {
    
    /// <inheritdoc cref="BinaryFormula"/>
    public sealed class DisjunctionFormula : BinaryFormula {

        public DisjunctionFormula(Formula leftSubformula, Formula rightSubformula)
            : base(leftSubformula, rightSubformula) {
        }
    }
}
