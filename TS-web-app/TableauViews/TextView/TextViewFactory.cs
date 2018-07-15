using TsWebApp.TableauViews.Layout;
using TableauxIO;
using System;

namespace TsWebApp.TableauViews {

    public class TextViewFactory : IViewFactory<TextView> {

        TextFormulaVisitor TextFormulaVisitor { get; set; } = new TextFormulaVisitor();

        public TextView GetView(SolutionNode node) {

            string text = node.Formula.Apply(TextFormulaVisitor);
            string truthValue = (node.GetType() != typeof(CompletionNode)) ? node.TruthValue.GetStringRepresentation() : string.Empty;

            string representation = text;
            if (!HasParenthesis(representation)) {
                representation = $"({representation})";
            }

            return new TextView() {
                Width = (uint)(representation.Length + truthValue.Length),
                Height = 1,
                Representation = truthValue + representation
            };
        }

        private bool HasParenthesis(string representation) {

            if (representation == null || representation == string.Empty) {
                return true;
            }

            else {
                return representation[0] == '(' && representation[representation.Length - 1] == ')';
            }
        }
    }
}
