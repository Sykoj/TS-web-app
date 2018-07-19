using Ts.IO;
using Ts.IO.Parser;
using TsWebApp.TableauViews;

namespace TsWebApp.Services {

    public static class FormulaRawInputView {

        public static RawVisitor _rawVisitor = new RawVisitor();

        public static string GetFormulaView(Formula formula) {

            return formula.Apply(_rawVisitor);
        }
    }

    public class RawVisitor : ILayoutableVisitor<string> {

        public string Visit(CompletionClosure completionClosure) {
            return string.Empty;
        }

        public string Visit(ConjuctionFormula conjuctionFormula) {
            return $"({conjuctionFormula.LeftFormula.Apply(this)} {Junctions.And} {conjuctionFormula.RightFormula.Apply(this)})";
        }

        public string Visit(ContradictionClosure contradictionClosure) {
            return "X";
        }

        public string Visit(DisjunctionFormula disjunctionFormula) {
            return $"({disjunctionFormula.LeftFormula.Apply(this)} {Junctions.Or} {disjunctionFormula.RightFormula.Apply(this)})";
        }

        public string Visit(EquivalenceFormula equivalenceFormula) {
            return $"({equivalenceFormula.LeftFormula.Apply(this)} {Junctions.Ekv} {equivalenceFormula.RightFormula.Apply(this)})";
        }

        public string Visit(ImplicationFormula implicationFormula) {
            return $"({implicationFormula.LeftFormula.Apply(this)} {Junctions.Imp} {implicationFormula.RightFormula.Apply(this)})";
        }

        public string Visit(NegationFormula negationFormula) {
            return $"({Junctions.Not} {negationFormula.Subformula.Apply(this)})";
        }

        public string Visit(VariableFormula variableFormula) {
            return $"{variableFormula.Symbol}";
        }

        public string Visit(Formula formula) {

            if (formula is CompletionClosure completionClosure) return Visit(completionClosure);
            if (formula is ConjuctionFormula conjuctionFormula) return Visit(conjuctionFormula);
            if (formula is ContradictionClosure contradictionClosure) return Visit(contradictionClosure);
            if (formula is DisjunctionFormula disjunctionFormula) return Visit(disjunctionFormula);
            if (formula is EquivalenceFormula equivalenceFormula) return Visit(equivalenceFormula);
            if (formula is ImplicationFormula implicationFormula) return Visit(implicationFormula);
            if (formula is NegationFormula negationFormula) return Visit(negationFormula);
            if (formula is VariableFormula variableFormula) return Visit(variableFormula);

            return default(string);
        }
    }


}
