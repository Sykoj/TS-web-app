using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews.ViewTree {
    
    public sealed class CompletionViewNode<T> : ViewNode<T> where T : ILayoutable {

        public CompletionViewNode(T view) : base(view) { }
    }
}
