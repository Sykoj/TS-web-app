using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class NegationTableau : AtomicTableau {
        
        private NegationFormula Negation { get; }
        
        public NegationTableau(NegationFormula formula, TruthValue truthValue) {
            Formula = Negation = formula;
            TruthValue = truthValue;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            branch.AddNewFormula(new BranchItem(Negation.Subformula, TruthValue.GetOpposite()));
            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {
            branch.AddNewFormula(new BranchItem(Negation.Subformula, TruthValue.GetOpposite()));
            ComputeRepresentingNode(branch);
        }
    }
}
