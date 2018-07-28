using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class DisjunctionTableau : AtomicTableau {
        
        private DisjunctionFormula Disjunction { get; }
        
        internal DisjunctionTableau(DisjunctionFormula formula, TruthLabel truthLabel) {
            Formula = Disjunction = formula;
            TruthLabel = truthLabel;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Disjunction.LeftSubformula, TruthLabel.True));
            rigthBranch.AddNewFormula(new BranchItem(Disjunction.RightSubformula, TruthLabel.True));
            
            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {
            
            branch.AddNewFormula(new BranchItem(Disjunction.LeftSubformula, TruthLabel.False));
            branch.AddNewFormula(new BranchItem(Disjunction.RightSubformula, TruthLabel.False));

            ComputeRepresentingNode(branch);
        }
    }
}

