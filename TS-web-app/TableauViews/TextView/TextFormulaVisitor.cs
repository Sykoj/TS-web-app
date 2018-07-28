using Ts.App.Extensions;
using Ts.App.TableauViews.Visitors;
using Ts.IO;

namespace Ts.App.TableauViews.TextView {

        public class TextFormulaVisitor : ILayoutableVisitor<string> {

        public string Visit(ConjuctionFormula conjuctionFormula) {
            return $"({conjuctionFormula.LeftSubformula.Apply(this)} ∧ {conjuctionFormula.RightSubformula.Apply(this)})";
        }

        public string Visit(DisjunctionFormula disjunctionFormula) {
            return $"({disjunctionFormula.LeftSubformula.Apply(this)} ∨ {disjunctionFormula.RightSubformula.Apply(this)})";
        }

        public string Visit(EquivalenceFormula equivalenceFormula) {
            return $"({equivalenceFormula.LeftSubformula.Apply(this)} ↔ {equivalenceFormula.RightSubformula.Apply(this)})";
        }

        public string Visit(ImplicationFormula implicationFormula) {
            return $"({implicationFormula.LeftSubformula.Apply(this)} → {implicationFormula.RightSubformula.Apply(this)})";
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

            if (formula is ConjuctionFormula conjuctionFormula) return Visit(conjuctionFormula);
            if (formula is DisjunctionFormula disjunctionFormula) return Visit(disjunctionFormula);
            if (formula is EquivalenceFormula equivalenceFormula) return Visit(equivalenceFormula);
            if (formula is ImplicationFormula implicationFormula) return Visit(implicationFormula);
            if (formula is NegationFormula negationFormula) return Visit(negationFormula);
            if (formula is VariableFormula variableFormula) return Visit(variableFormula);

            return default(string);
        }
    }
}
