namespace Ts.IO {
    
    /// <inheritdoc cref="BinaryFormula"/>
    public sealed class ConjuctionFormula : BinaryFormula {

        public ConjuctionFormula(Formula leftSubformula, Formula rightSubformula)
            : base(leftSubformula, rightSubformula) {
        }
    }
}
