using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews.ViewTree {

    public sealed class UnaryViewNode<T> : ViewNode<T> where T : ILayoutable {

        public ViewNode<T> Child { get; }

        public UnaryViewNode(T view, ViewNode<T> child) : base(view) {
            Child = child;
        }
    }
}
