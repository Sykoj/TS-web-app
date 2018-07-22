using Ts.App.Utilities;
using Ts.IO;

namespace Ts.App.TableauViews.Visitors {

    public interface ILayoutableVisitor<T> : IFormulaVisitor<T> {

        T Visit(ConjuctionFormula conjuctionFormula);
        T Visit(DisjunctionFormula disjunctionFormula);
        T Visit(EquivalenceFormula equivalenceFormula);
        T Visit(ImplicationFormula implicationFormula);
        T Visit(NegationFormula negationFormula);
        T Visit(VariableFormula variableFormula);
    }
}
