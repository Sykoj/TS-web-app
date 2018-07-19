using Ts.IO;
using TsWebApp.TableauViews.ViewTree;

namespace TsWebApp.TableauViews.Layout {

    internal class ViewNodeFactory<T> where T : ILayoutable {

        private IViewFactory<T> ViewFactory { get; }

        internal ViewNodeFactory(IViewFactory<T> viewFactory) {
            ViewFactory = viewFactory;
        }

        internal UnaryViewNode<T> CreateUnaryNode(UnaryNode node, ViewNode<T> child) {

            var nodeView = ViewFactory.GetView(node);
            return new UnaryViewNode<T>(nodeView, child);
        }

        internal BinaryViewNode<T> CreateBinaryNode(BinaryNode node, ViewNode<T> leftChild, ViewNode<T> rightChild) {

            var nodeView = ViewFactory.GetView(node);
            return new BinaryViewNode<T>(nodeView, leftChild, rightChild);
        }

        internal CompletionViewNode<T> CreateCompletionNode(CompletionNode node) {

            var nodeView = ViewFactory.GetView(node);
            return new CompletionViewNode<T>(nodeView);
        }
    }
}
