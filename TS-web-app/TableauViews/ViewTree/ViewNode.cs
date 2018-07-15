using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews.ViewTree {

    public abstract class ViewNode<T> where T : ILayoutable {

        public T View { get; }
        public ViewNode(T view) {
            View = view;
        }

        public (long X, long Y) Position { get; set; }
        public uint TreeWidth { get; set; }
        public uint TreeHeight { get; set; }

    }
}
