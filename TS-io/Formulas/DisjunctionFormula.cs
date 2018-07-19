namespace Ts.IO {
    
    public sealed class DisjunctionFormula : BinaryFormula {

        public DisjunctionFormula(Formula leftFormula, Formula rightFormula)
            : base(leftFormula, rightFormula) {
        }
    }
}
