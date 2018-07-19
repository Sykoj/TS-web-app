using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class CompletionTableau : AtomicTableau {

        internal CompletionTableau(CompletionClosure formula, TruthValue truthValue) {
            Formula = formula;
            TruthValue = truthValue;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            CompleteBranch();
        }

        protected override void HandleFalseCase(Branch branch) {
            HandleTrueCase(branch);
        }
    }
}