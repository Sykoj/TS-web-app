using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class ImplicationTableau : AtomicTableau {
        
        private ImplicationFormula Implication { get; }
        
        internal ImplicationTableau(ImplicationFormula formula, TruthLabel truthLabel) {
            Formula = Implication = formula;
            TruthLabel = truthLabel;
        }

        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
           
            leftBranch.AddNewFormula(new BranchItem(Implication.LeftSubformula, TruthLabel.False));
            rigthBranch.AddNewFormula(new BranchItem(Implication.RightSubformula, TruthLabel.True));
            
            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {

            branch.AddNewFormula(new BranchItem(Implication.LeftSubformula, TruthLabel.True));
            branch.AddNewFormula(new BranchItem(Implication.RightSubformula, TruthLabel.False));
            
            ComputeRepresentingNode(branch);
        }
    }
}
