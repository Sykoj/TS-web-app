using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.ViewTree {

    public sealed class ContradictionViewNode<T> : ViewNode<T> where T : ILayoutable {

        public ContradictionViewNode(T view) : base(view) { }
    }
}
