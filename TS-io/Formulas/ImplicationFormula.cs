namespace Ts.IO {

    /// <inheritdoc cref="BinaryFormula"/>
    public class ImplicationFormula : BinaryFormula {

        public ImplicationFormula(Formula leftSubformula, Formula rightSubformula) 
            : base(leftSubformula, rightSubformula) {
        }
    }
}
