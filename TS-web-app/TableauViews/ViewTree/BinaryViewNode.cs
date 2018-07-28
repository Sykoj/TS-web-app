using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.ViewTree {

    public sealed class BinaryViewNode<T> : ViewNode<T> where T : ILayoutable {

        public ViewNode<T> RightChild { get; }
        public ViewNode<T> LeftChild { get; }

        public BinaryViewNode(T view, ViewNode<T> leftChild, ViewNode<T> rightChild) : base(view) {
            RightChild = rightChild;
            LeftChild = leftChild;
        }
    }
}
