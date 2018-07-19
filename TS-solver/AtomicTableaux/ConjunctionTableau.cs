using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class ConjunctionTableau : AtomicTableau {
        
        private ConjuctionFormula Conjunction { get; }
                        
        internal ConjunctionTableau(ConjuctionFormula formula, TruthValue truthValue) {
            Formula = Conjunction = formula;
            TruthValue = truthValue;
        }
        
        protected override void HandleTrueCase(Branch branch) {
            
            branch.AddNewFormula(new BranchItem(Conjunction.RightFormula, TruthValue.True));
            branch.AddNewFormula(new BranchItem(Conjunction.LeftFormula, TruthValue.True));

            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {

            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();

            leftBranch.AddNewFormula(new BranchItem(Conjunction.LeftFormula, TruthValue.False));
            rigthBranch.AddNewFormula(new BranchItem(Conjunction.RightFormula, TruthValue.False));

            ComputeRepresentingNode(leftBranch, rigthBranch);
        }
    }
}
