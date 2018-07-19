namespace Ts.IO {
    
    public sealed class ConjuctionFormula : BinaryFormula {

        public ConjuctionFormula(Formula leftFormula, Formula rightFormula)
            : base(leftFormula, rightFormula) {
        }
    }
}
