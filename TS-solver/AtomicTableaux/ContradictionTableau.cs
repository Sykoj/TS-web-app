namespace Ts.Solver.AtomicTableaux {
    
    internal class ContradictionTableau : AtomicTableau {
        
        protected override void HandleTrueCase(Branch branch) {
            ContradictBranch();
        }

        protected override void HandleFalseCase(Branch branch) {
            HandleTrueCase(branch);
        }
    }
}
