namespace Ts.IO {
    
    public sealed class EquivalenceFormula : BinaryFormula {

        public EquivalenceFormula(Formula leftFormula, Formula rightFormula) :
            base(leftFormula, rightFormula) {
        }
    }
}
