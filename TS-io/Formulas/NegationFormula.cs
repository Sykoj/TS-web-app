namespace Ts.IO {

    /// <inheritdoc cref="UnaryFormula"/>
    public sealed class NegationFormula : UnaryFormula {

        public NegationFormula(Formula subformula) : base(subformula) {           
        }
    }
}
