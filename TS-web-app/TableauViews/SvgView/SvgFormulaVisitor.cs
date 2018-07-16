using TableauxIO;

namespace TsWebApp.TableauViews.SvgView {

    public class SvgFormulaVisitor : ILayoutableVisitor<SvgView> {

        public SvgView Visit(CompletionClosure completionClosure) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(ConjuctionFormula conjuctionFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(ContradictionClosure contradictionClosure) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(DisjunctionFormula disjunctionFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(EquivalenceFormula equivalenceFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(ImplicationFormula implicationFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(NegationFormula negationFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(VariableFormula variableFormula) {
            throw new System.NotImplementedException();
        }

        public SvgView Visit(Formula formula) {
            throw new System.NotImplementedException();
        }
    }
}
