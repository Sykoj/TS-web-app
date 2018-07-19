using System;
using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    public abstract class AtomicTableau {

        public SolutionNode RepresentingNode { get; private set; }
        protected Formula Formula { get; set; }
        protected TruthValue TruthValue { get; set; }
        
        internal void ResolveChildsFrom(Branch branch) {
            
            switch (TruthValue) {
                case TruthValue.True:
                    HandleTrueCase(branch);
                    break;
                case TruthValue.False:
                    HandleFalseCase(branch);
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        protected void ComputeRepresentingNode(Branch left, Branch right) {
            
            RepresentingNode = new BinaryNode() {
                LeftChild = left.Develop(),
                RightChild = right.Develop(),
                Formula = Formula,
                TruthValue = TruthValue
            };
        }

        protected void ComputeRepresentingNode(Branch branch) {

            RepresentingNode = new UnaryNode() {
                Child = branch.Develop(),
                Formula = Formula,
                TruthValue = TruthValue
            };
        }

        protected void CompleteBranch() {

            RepresentingNode = new CompletionNode() {
                Formula = Formula,
                TruthValue = TruthValue
            };
        }
        
        protected abstract void HandleTrueCase(Branch branch);
        protected abstract void HandleFalseCase(Branch branch);
    }
}
