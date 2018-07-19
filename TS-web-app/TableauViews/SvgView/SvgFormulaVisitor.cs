using System;
using Ts.IO;
using TsWebApp.Services;

namespace TsWebApp.TableauViews {

    public class SvgFormulaVisitor : ILayoutableVisitor<SvgView> {

        private readonly TextFormulaVisitor _textFormulaVisitor;
        private readonly SvgViewService _svgViewService;

        public SvgFormulaVisitor(SvgViewService svgViewService) {
            _textFormulaVisitor = new TextFormulaVisitor();
            _svgViewService = svgViewService;
        }

        public SvgView Visit(Formula formula) {
            throw new NotImplementedException();
        }

        public SvgView Visit(CompletionClosure completionClosure) {
            throw new NotImplementedException();
        }

        public SvgView Visit(ConjuctionFormula conjuctionFormula) {

            var text = conjuctionFormula.Apply(_textFormulaVisitor);
            return new FormulaTextSvg(14);
        }

        public SvgView Visit(ContradictionClosure contradictionClosure) {
            throw new NotImplementedException();
        }

        public SvgView Visit(DisjunctionFormula disjunctionFormula) {

            var text = disjunctionFormula.Apply(_textFormulaVisitor);
            return new FormulaTextSvg(14);
        }

        public SvgView Visit(EquivalenceFormula equivalenceFormula) {
            throw new NotImplementedException();
        }

        public SvgView Visit(ImplicationFormula implicationFormula) {
            throw new NotImplementedException();
        }

        public SvgView Visit(NegationFormula negationFormula) {
            throw new NotImplementedException();
        }

        public SvgView Visit(VariableFormula variableFormula) {
            throw new NotImplementedException();
        }
    }
}
