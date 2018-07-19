using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal sealed class VariableTableau : AtomicTableau {
        
        private VariableFormula Variable { get; }
        
        internal VariableTableau(VariableFormula formula, TruthValue truthValue) {
            Formula = Variable = formula;
            TruthValue = truthValue;
        }       
        
        protected override void HandleTrueCase(Branch branch) {
            
            var literal = new Literal(Variable.Symbol, TruthValue);
            branch.AddLiteral(literal);
            
            ComputeRepresentingNode(branch);
        }

        protected override void HandleFalseCase(Branch branch) {
            HandleTrueCase(branch);
        }
    }
}
