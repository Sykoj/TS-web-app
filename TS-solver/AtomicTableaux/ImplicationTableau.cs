using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal class ImplicationTableau : AtomicTableau {
        
        private ImplicationFormula Implication { get; }
        
        internal ImplicationTableau(ImplicationFormula formula, TruthValue truthValue) {
            Formula = Implication = formula;
            TruthValue = truthValue;
        }

        protected override void HandleTrueCase(Branch branch) {
            
            var leftBranch = branch;
            var rigthBranch = branch.GetDeepCopy();
           
            leftBranch.AddNewFormula(new BranchItem(Implication.LeftFormula, TruthValue.False));
            rigthBranch.AddNewFormula(new BranchItem(Implication.RightFormula, TruthValue.True));
            
            ComputeRepresentingNode(leftBranch, rigthBranch);
        }

        protected override void HandleFalseCase(Branch branch) {

            branch.AddNewFormula(new BranchItem(Implication.LeftFormula, TruthValue.True));
            branch.AddNewFormula(new BranchItem(Implication.RightFormula, TruthValue.False));
            
            ComputeRepresentingNode(branch);
        }
    }
}
