using System;
using Ts.IO;

namespace Ts.Solver.AtomicTableaux {
    
    internal static class TabloProvider {

        public static AtomicTableau GetAtomicTableau(this Formula formula, TruthLabel truthLabel) {
            
            switch (formula) {
                case ConjuctionFormula conjunction:
                    return new ConjunctionTableau(conjunction, truthLabel);
                case DisjunctionFormula disjunction:
                    return new DisjunctionTableau(disjunction, truthLabel);
                case EquivalenceFormula equivalence:
                    return new EquivalenceTableau(equivalence, truthLabel);
                case ImplicationFormula implication:
                    return new ImplicationTableau(implication, truthLabel);
                case NegationFormula negation:
                    return new NegationTableau(negation, truthLabel);
                case VariableFormula variable:
                    return new VariableTableau(variable, truthLabel);
            }

            throw new ArgumentException();
        }
    }
}
