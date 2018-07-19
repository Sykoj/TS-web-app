using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class DisjunctionTableau : AtomicTableau {
        
        private DisjunctionFormula Disjunction { get; }
        
        internal DisjunctionTableau(DisjunctionFormula formula, TruthValue truthValue) {
            Formula = Disjunction = formula;
            TruthValue = truthValue;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Disjunction.LeftFormula, TruthValue.True));
            rigthBranch.AddNewFormula(new BranchItem(Disjunction.RightFormula, TruthValue.True));
            
            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {
            
            branch.AddNewFormula(new BranchItem(Disjunction.LeftFormula, TruthValue.False));
            branch.AddNewFormula(new BranchItem(Disjunction.RightFormula, TruthValue.False));

            ComputeRepresentingNode(branch);
        }
    }
}

