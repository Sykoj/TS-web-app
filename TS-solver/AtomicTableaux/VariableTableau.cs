using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class VariableTableau : AtomicTableau {
        
        private VariableFormula Variable { get; }
        
        internal VariableTableau(VariableFormula formula, TruthLabel truthLabel) {
            Formula = Variable = formula;
            TruthLabel = truthLabel;
        }       
        
        protected override void HandleTrueCase(Branch branch) {
            
            var literal = new Literal(Variable.Symbol, TruthLabel);
            branch.AddLiteral(literal);
            
            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {
            HandleTrueCase(branch);
        }
    }
}
