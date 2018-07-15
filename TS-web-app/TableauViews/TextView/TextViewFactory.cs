using TsWebApp.TableauViews.Layout;
using TableauxIO;

namespace TsWebApp.TableauViews {

    public class TextViewFactory : IViewFactory<TextView> {

        TextFormulaVisitor TextFormulaVisitor { get; set; } = new TextFormulaVisitor();

        public TextView GetView(SolutionNode node) {

            string text = node.Formula.Apply(TextFormulaVisitor);
            string truthValue = (node.GetType() != typeof(CompletionNode)) ? node.TruthValue.GetStringRepresentation() : string.Empty;

            string representation = text;
            if (node.Formula.GetType() == typeof(VariableFormula) && node.GetType() == typeof(UnaryNode)) {
                representation = $"({representation})";
            }

            return new TextView() {
                Width = (uint)(representation.Length + truthValue.Length),
                Height = 1,
                Representation = truthValue + representation
            };
        }
    }
}
