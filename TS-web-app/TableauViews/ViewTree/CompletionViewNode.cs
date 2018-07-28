using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.ViewTree {
    
    public sealed class CompletionViewNode<T> : ViewNode<T> where T : ILayoutable {

        public CompletionViewNode(T view) : base(view) { }
    }
}
