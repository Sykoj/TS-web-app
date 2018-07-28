using Ts.IO;

namespace Ts.Solver {
    
    internal struct BranchItem {
        
        private Formula Formula { get; }
        private TruthLabel TruthLabel { get; }

        internal BranchItem(TableauInputNode tableauInputNode) {
            Formula = tableauInputNode.Formula;
            TruthLabel = tableauInputNode.TruthLabel;
        }

        internal BranchItem(Formula formula, TruthLabel truthLabel) {
            Formula = formula;
            TruthLabel = truthLabel;
        }

        internal (Formula, TruthLabel ) GetValueTuple() {
            return (Formula, TruthLabel);
        }
    }
}
