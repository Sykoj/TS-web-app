using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class NegationTableau : AtomicTableau {
        
        private NegationFormula Negation { get; }
        
        public NegationTableau(NegationFormula formula, TruthLabel truthLabel) {
            Formula = Negation = formula;
            TruthLabel = truthLabel;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            branch.AddNewFormula(new BranchItem(Negation.Subformula, TruthLabel.GetOpposite()));
            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {
            branch.AddNewFormula(new BranchItem(Negation.Subformula, TruthLabel.GetOpposite()));
            ComputeRepresentingNode(branch);
        }
    }
}
