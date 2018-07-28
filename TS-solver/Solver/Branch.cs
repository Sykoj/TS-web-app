using System.Collections.Generic;
using Ts.IO;
using Ts.Solver.AtomicTableaux;

namespace Ts.Solver {
    
    internal class Branch {

        private HashSet<Literal> UsedVariables { get; set; } = new HashSet<Literal>();
        private Queue<BranchItem> UndevelopedFormulas { get; set; } = new Queue<BranchItem>();
        private Queue<BranchItem> UnusedAxioms { get; set; } = new Queue<BranchItem>();

        internal SolutionNode Develop() {

            var atomicTableau = GetAtomicTableau();
            atomicTableau.ResolveChildsFrom(this);
            
            return atomicTableau.RepresentingNode;
        }

        private AtomicTableau GetAtomicTableau() {

            if (ContainsOppositeLiteral()) return new ContradictionTableau();
            var (formula, truthValue) = GetFormulaToDevelop();
            return formula == null ? new CompletionTableau() : formula.GetAtomicTableau(truthValue);
        }

        private (Formula, TruthLabel) GetFormulaToDevelop() {
           
            if (UndevelopedFormulas.Count != 0) {
                return UndevelopedFormulas.Dequeue().GetValueTuple();
                
            }
            if (UnusedAxioms.Count != 0) {
                return UnusedAxioms.Dequeue().GetValueTuple();
            }

            return (null, TruthLabel.False);
        }

        internal void AddNewFormula(BranchItem newBranchItem) {
             UndevelopedFormulas.Enqueue(newBranchItem);
        }

        internal void AddAxiom(BranchItem newBranchItem) {
            UnusedAxioms.Enqueue(newBranchItem);
        }

        internal void AddLiteral(Literal literal) {
            UsedVariables.Add(literal);
        }

        internal Branch GetDeepCopy() {
            return new Branch() {
                UsedVariables = new HashSet<Literal>(UsedVariables),
                UndevelopedFormulas = new Queue<BranchItem>(UndevelopedFormulas),
                UnusedAxioms = new Queue<BranchItem>(UnusedAxioms)
            };
        }

        private bool ContainsOppositeLiteral() {

            foreach (var literal in UsedVariables) {
                if (UsedVariables.Contains(literal.GetOppositeLiteral())) return true;
            }

            return false;
        }        
    }
}
