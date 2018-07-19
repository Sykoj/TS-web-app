using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class EquivalenceTableau : AtomicTableau {
        
        private EquivalenceFormula Equivalence { get; }
        
        internal EquivalenceTableau(EquivalenceFormula formula, TruthValue truthValue) {
            Formula = Equivalence = formula;
            TruthValue = truthValue;
        }

        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Equivalence.LeftFormula, TruthValue.True));
            leftBranch.AddNewFormula(new BranchItem(Equivalence.RightFormula, TruthValue.True));
            
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.LeftFormula, TruthValue.False));
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.RightFormula, TruthValue.False));

            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {

            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Equivalence.LeftFormula, TruthValue.True));
            leftBranch.AddNewFormula(new BranchItem(Equivalence.RightFormula, TruthValue.False));
            
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.LeftFormula, TruthValue.False));
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.RightFormula, TruthValue.True));

            ComputeRepresentingNode(leftBranch, rigthBranch);        
        }
    }
}
