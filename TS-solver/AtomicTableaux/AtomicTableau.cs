using System;
using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal abstract class AtomicTableau {

        public SolutionNode RepresentingNode { get; private set; }
        protected Formula Formula { get; set; }
        protected TruthLabel TruthLabel { get; set; }
        
        internal void ResolveChildsFrom(Branch branch) {
            
            switch (TruthLabel) {
                case TruthLabel.True:
                    HandleTrueCase(branch);
                    break;
                case TruthLabel.False:
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
                TruthLabel = TruthLabel
            };
        }

        protected void ComputeRepresentingNode(Branch branch) {

            RepresentingNode = new UnaryNode() {
                Child = branch.Develop(),
                Formula = Formula,
                TruthLabel = TruthLabel
            };
        }

        protected void CompleteBranch() {

            RepresentingNode = new CompletionNode();
        }

        protected void ContradictBranch() {

            RepresentingNode = new ContradictionNode();
        }
        
        protected abstract void HandleTrueCase(Branch branch);
        protected abstract void HandleFalseCase(Branch branch);
    }
}
