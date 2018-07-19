using Ts.IO;

namespace TsWebApp.TableauViews {

    public interface ILayoutableVisitor<T> : IFormulaVisitor<T> {

        T Visit(CompletionClosure completionClosure);
        T Visit(ConjuctionFormula conjuctionFormula);
        T Visit(ContradictionClosure contradictionClosure);
        T Visit(DisjunctionFormula disjunctionFormula);
        T Visit(EquivalenceFormula equivalenceFormula);
        T Visit(ImplicationFormula implicationFormula);
        T Visit(NegationFormula negationFormula);
        T Visit(VariableFormula variableFormula);
    }
}
