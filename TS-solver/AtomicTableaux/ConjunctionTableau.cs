using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class ConjunctionTableau : AtomicTableau {
        
        private ConjuctionFormula Conjunction { get; }
                        
        internal ConjunctionTableau(ConjuctionFormula formula, TruthLabel truthLabel) {
            Formula = Conjunction = formula;
            TruthLabel = truthLabel;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            
            branch.AddNewFormula(new BranchItem(Conjunction.RightSubformula, TruthLabel.True));
            branch.AddNewFormula(new BranchItem(Conjunction.LeftSubformula, TruthLabel.True));

            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {

            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();

            leftBranch.AddNewFormula(new BranchItem(Conjunction.LeftSubformula, TruthLabel.False));
            rigthBranch.AddNewFormula(new BranchItem(Conjunction.RightSubformula, TruthLabel.False));

            ComputeRepresentingNode(leftBranch, rigthBranch);
        }
    }
}
