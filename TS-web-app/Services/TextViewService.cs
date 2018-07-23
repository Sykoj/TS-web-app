using System.Linq;
using System.Text;
using Ts.App.TableauViews.Layout;
using Ts.App.TableauViews.TextView;
using Ts.App.TableauViews.ViewTree;
using Ts.IO;

namespace Ts.App.Services {

    public class TextViewService {

        private readonly LayoutProcessor<TextView> _layoutProcessor;
        private readonly ViewTreeBuilder<TextView> _viewTreeBuilder;

        public TextViewService() {
            _viewTreeBuilder = new ViewTreeBuilder<TextView>(new TextViewFactory());
            _layoutProcessor = new LayoutProcessor<TextView>(new TextViewOptions());
        }

        public string[] GetTextView(SolutionNode solutionNode) {

            var viewTree = _viewTreeBuilder.CreateViewTree(solutionNode);
            _layoutProcessor.SetLayout(viewTree);

            StringBuilder[] viewCanvas =
                GetNewViewCanvas(viewTree.TreeHeight, (int) viewTree.TreeWidth);

            FillCanvas(viewCanvas, viewTree);

            return (from canvasLine in viewCanvas
                    let line = canvasLine.ToString() select line).ToArray();
        }

        private void FillCanvas(StringBuilder[] viewCanvas, ViewNode<TextView> node) {

            GenerateConnections(viewCanvas, node);

            int x = (int)node.Position.X;
            int y = (int)node.Position.Y;

            viewCanvas[y].Remove(x, node.View.Representation.Length);
            viewCanvas[y].Insert(x, node.View.Representation);

            if (node is BinaryViewNode<TextView> binaryNode) {
                FillCanvas(viewCanvas, binaryNode.LeftChild);
                FillCanvas(viewCanvas, binaryNode.RightChild);
            }
            if (node is UnaryViewNode<TextView> unaryNode) {
                FillCanvas(viewCanvas, unaryNode.Child);
            }
        }

        private void GenerateConnections(StringBuilder[] viewCanvas, ViewNode<TextView> node) {

            var (x, y) = node.Position;
            int axis = (int) x + _layoutProcessor.GetAxisPrefixLength(node.View.Width);
            long verticalConnectionBeginHeight = y + 1;
            long verticalConnectionEndHeight = 0;

            if (node is BinaryViewNode<TextView> binaryNode) {

                int leftAxis = (int)binaryNode.LeftChild.Position.X
                    + _layoutProcessor.GetAxisPrefixLength(binaryNode.LeftChild.View.Width);
                int rightAxis = (int)binaryNode.RightChild.Position.X
                    + _layoutProcessor.GetAxisPrefixLength(binaryNode.RightChild.View.Width);

                var axesDiff = rightAxis - leftAxis;
                var nodeHorizontalConnection = new string('-', axesDiff);
                var nodeHorizontalConnectionHeight = binaryNode.RightChild.Position.Y - 1;

                verticalConnectionEndHeight = nodeHorizontalConnectionHeight;

                if (y != nodeHorizontalConnectionHeight) {
                    viewCanvas[nodeHorizontalConnectionHeight]
                        .Remove(leftAxis, nodeHorizontalConnection.Length);

                    viewCanvas[nodeHorizontalConnectionHeight]
                        .Insert(leftAxis, nodeHorizontalConnection);
                }
            }
            else if (node is UnaryViewNode<TextView> unaryNode) {

                if (unaryNode.Child is CompletionViewNode<TextView> && unaryNode.Child.View == null
                   || unaryNode.Child.View.Representation == string.Empty) {
                    return;
                }

                verticalConnectionEndHeight = unaryNode.Child.Position.Y;
            }

            for (var i = verticalConnectionBeginHeight; i < verticalConnectionEndHeight; ++i) {
                viewCanvas[i].Remove(axis, 1);
                viewCanvas[i].Insert(axis,'|');
            }
        }

        private StringBuilder[] GetNewViewCanvas(uint arraySize, int lineCapacity) {

            var emptyLine = new string(' ', lineCapacity);

            var viewCanvas = new StringBuilder[arraySize];
            for (int i = 0; i < arraySize; ++i) {
                viewCanvas[i] = new StringBuilder(emptyLine);
            }

            return viewCanvas;
        }
    }
}
