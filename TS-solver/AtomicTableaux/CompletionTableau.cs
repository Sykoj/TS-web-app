namespace Ts.Solver.AtomicTableaux {
    
    internal class CompletionTableau : AtomicTableau {

        protected override void HandleTrueCase(Branch branch) {
            CompleteBranch();
        }

        protected override void HandleFalseCase(Branch branch) {
            HandleTrueCase(branch);
        }
    }
}
