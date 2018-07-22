using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class EquivalenceTableau : AtomicTableau {
        
        private EquivalenceFormula Equivalence { get; }
        
        internal EquivalenceTableau(EquivalenceFormula formula, TruthLabel truthLabel) {
            Formula = Equivalence = formula;
            TruthLabel = truthLabel;
        }

        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Equivalence.LeftSubformula, TruthLabel.True));
            leftBranch.AddNewFormula(new BranchItem(Equivalence.RightSubformula, TruthLabel.True));
            
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.LeftSubformula, TruthLabel.False));
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.RightSubformula, TruthLabel.False));

            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {

            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
            
            leftBranch.AddNewFormula(new BranchItem(Equivalence.LeftSubformula, TruthLabel.True));
            leftBranch.AddNewFormula(new BranchItem(Equivalence.RightSubformula, TruthLabel.False));
            
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.LeftSubformula, TruthLabel.False));
            rigthBranch.AddNewFormula(new BranchItem(Equivalence.RightSubformula, TruthLabel.True));

            ComputeRepresentingNode(leftBranch, rigthBranch);        
        }
    }
}
