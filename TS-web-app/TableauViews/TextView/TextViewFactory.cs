using Ts.App.Extensions;
using Ts.App.TableauViews.ViewTree;
using Ts.IO;

namespace Ts.App.TableauViews.TextView {

    public class TextViewFactory : IViewFactory<TextView> {

        TextFormulaVisitor TextFormulaVisitor { get; set; } = new TextFormulaVisitor();

        public TextView GetView(SolutionNode node) {

            var representation = string.Empty;

            if (node is ContradictionNode) {
                representation = "X";
            }
            else if (node is CompletionNode) {
            }
            else {
                var formulaRepresentation = node.Formula.Apply(TextFormulaVisitor);
                var truthLabel = node.TruthLabel.GetStringRepresentation();

                if (!HasParenthesis(formulaRepresentation)) {
                    formulaRepresentation = $"({formulaRepresentation})";
                }

                representation = $"{truthLabel}{formulaRepresentation}";
            }

            return new TextView() {
                Width = (uint) representation.Length,
                Height = 1,
                Representation = representation
            };
        }

        private static bool HasParenthesis(string representation) {

            if (string.IsNullOrEmpty(representation)) {
                return true;
            }
            else {
                return representation[0] == '(' && representation[representation.Length - 1] == ')';
            }
        }
    }
}
