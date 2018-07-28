using System;
using Ts.App.TableauViews.Layout;
using Ts.IO;

namespace Ts.App.TableauViews.ViewTree {

    public class ViewTreeBuilder<T> where T : ILayoutable {

        private ViewNodeFactory<T> ViewNodeFactory { get; }

        public ViewTreeBuilder(IViewFactory<T> viewFactory) {
            ViewNodeFactory = new ViewNodeFactory<T>(viewFactory);
        }

        public ViewNode<T> CreateViewTree(SolutionNode node) {

            if (node is BinaryNode binaryNode) {
                return CreateViewTree(binaryNode);
            } else if (node is UnaryNode unaryNode) {
                return CreateViewTree(unaryNode);
            } else if (node is CompletionNode completionNode) {
                return CreateViewTree(completionNode);
            } else if (node is ContradictionNode contradictionNode) {
                return CreateViewTree(contradictionNode);
            }

            throw new InvalidOperationException();
        }

        private BinaryViewNode<T> CreateViewTree(BinaryNode node) {

            var rightView = CreateViewTree(node.RightChild);
            var leftView = CreateViewTree(node.LeftChild);
            return ViewNodeFactory.CreateBinaryNode(node, leftView, rightView);
        }

        public UnaryViewNode<T> CreateViewTree(UnaryNode node) {

            var childView = CreateViewTree(node.Child);
            return ViewNodeFactory.CreateUnaryNode(node, childView);
        }

        public CompletionViewNode<T> CreateViewTree(CompletionNode node) {
            return ViewNodeFactory.CreateCompletionNode(node);
        }

        public ContradictionViewNode<T> CreateViewTree(ContradictionNode node) {
            return ViewNodeFactory.CreateContradictionNode(node);
        }
    }
}
