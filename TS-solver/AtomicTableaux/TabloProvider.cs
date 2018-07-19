using System;
using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    public static class TabloProvider {

        public static AtomicTableau GetAtomicTableau(this Formula formula, TruthValue truthValue) {
            
            switch (formula) {
                case CompletionClosure closure:
                    return new CompletionTableau(closure, truthValue);
                case ConjuctionFormula conjunction:
                    return new ConjunctionTableau(conjunction, truthValue);
                case ContradictionClosure contradiction:
                    return new ContradictionTableau(contradiction, truthValue);
                case DisjunctionFormula disjunction:
                    return new DisjunctionTableau(disjunction, truthValue);
                case EquivalenceFormula equivalence:
                    return new EquivalenceTableau(equivalence, truthValue);
                case ImplicationFormula implication:
                    return new ImplicationTableau(implication, truthValue);
                case NegationFormula negation:
                    return new NegationTableau(negation, truthValue);
                case VariableFormula variable:
                    return new VariableTableau(variable, truthValue);
            }

            throw new ArgumentException();
        }
    }
}
