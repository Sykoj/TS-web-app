using System;
using Ts.App.Extensions;
using Ts.App.Services;
using Ts.App.TableauViews.TextView;
using Ts.App.TableauViews.Visitors;
using Ts.IO;

namespace Ts.App.TableauViews.SvgView {

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

        public SvgView Visit(ConjuctionFormula conjuctionFormula) {

            var text = conjuctionFormula.Apply(_textFormulaVisitor);
            return new FormulaTextSvg(14);
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
