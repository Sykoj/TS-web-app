using System.Collections.Generic;
using Ts.IO;
using Ts.Solver.AtomicTableaux;

namespace Ts.Solver {
    
    public class Branch {

        private HashSet<Literal> UsedVariables { get; set; } = new HashSet<Literal>();
        private Stack<BranchItem> UndevelopedFormulas { get; set; } = new Stack<BranchItem>();
        private Queue<BranchItem> UnusedAxioms { get; set; } = new Queue<BranchItem>();

        internal SolutionNode Develop() {

            var (formula, truthValue) = GetFormulaToDevelop();
            var atomicTableau = formula.GetAtomicTableau(truthValue);
            atomicTableau.ResolveChildsFrom(this);
            
            return atomicTableau.RepresentingNode;
        }

        private (Formula, TruthValue) GetFormulaToDevelop() {
            
            if (ContainsOppositeLiteral()) {
                return (new ContradictionClosure(), TruthValue.True);
                
            } if (UndevelopedFormulas.Count != 0) {
                return UndevelopedFormulas.Pop().GetValueTuple();
                
            } if (UnusedAxioms.Count != 0) {
                return UnusedAxioms.Dequeue().GetValueTuple();
                
            } else {
                return (new CompletionClosure(), TruthValue.True);
            }
        }

        internal void AddNewFormula(BranchItem newBranchItem) {
             UndevelopedFormulas.Push(newBranchItem);
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
                UndevelopedFormulas = new Stack<BranchItem>(UndevelopedFormulas),
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
