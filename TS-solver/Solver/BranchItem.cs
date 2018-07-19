using Ts.IO;

namespace Ts.Solver {
    
    internal struct BranchItem {
        
        private Formula Formula { get; }
        private TruthValue TruthValue { get; }

        internal BranchItem(TableauInputNode tableauInputNode) {
            Formula = tableauInputNode.Formula;
            TruthValue = tableauInputNode.TruthValue;
        }

        internal BranchItem(Formula formula, TruthValue truthValue) {
            Formula = formula;
            TruthValue = truthValue;
        }

        internal (Formula, TruthValue ) GetValueTuple() {
            return (Formula, TruthValue);
        }
    }
}
