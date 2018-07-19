using System;
using TsWebApp.TableauViews.ViewTree;
using Ts.IO;

namespace TsWebApp.TableauViews.Layout {

    public class ViewTreeBuilder<T> where T : ILayoutable {

        ViewNodeFactory<T> ViewNodeFactory { get; }

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
            }

            throw new InvalidOperationException();
        }

        BinaryViewNode<T> CreateViewTree(BinaryNode node) {

            var rightView = CreateViewTree(node.RightChild);
            var leftView = CreateViewTree(node.LeftChild);
            return ViewNodeFactory.CreateBinaryNode(node, leftView, rightView);
        }

        UnaryViewNode<T> CreateViewTree(UnaryNode node) {

            var childView = CreateViewTree(node.Child);
            return ViewNodeFactory.CreateUnaryNode(node, childView);
        }

        CompletionViewNode<T> CreateViewTree(CompletionNode node) {
            return ViewNodeFactory.CreateCompletionNode(node);
        }
    }
}
