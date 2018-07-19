using Ts.IO;

namespace TsWebApp.TableauViews {

        public class TextFormulaVisitor : ILayoutableVisitor<string> {

        public string Visit(CompletionClosure completionClosure) {
            return string.Empty;
        }

        public string Visit(ConjuctionFormula conjuctionFormula) {
            return $"({conjuctionFormula.LeftFormula.Apply(this)} ∧ {conjuctionFormula.RightFormula.Apply(this)})";
        }

        public string Visit(ContradictionClosure contradictionClosure) {
            return "X";
        }

        public string Visit(DisjunctionFormula disjunctionFormula) {
            return $"({disjunctionFormula.LeftFormula.Apply(this)} ∨ {disjunctionFormula.RightFormula.Apply(this)})";
        }

        public string Visit(EquivalenceFormula equivalenceFormula) {
            return $"({equivalenceFormula.LeftFormula.Apply(this)} ↔ {equivalenceFormula.RightFormula.Apply(this)})";
        }

        public string Visit(ImplicationFormula implicationFormula) {
            return $"({implicationFormula.LeftFormula.Apply(this)} → {implicationFormula.RightFormula.Apply(this)})";
        }

        public string Visit(NegationFormula negationFormula) {

            if (negationFormula.Subformula.GetType() == typeof(VariableFormula)) {
                return $"¬{negationFormula.Subformula.Apply(this)}";
            }

            return $"(¬{negationFormula.Subformula.Apply(this)})";
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
