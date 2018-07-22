using Ts.App.TableauViews.Layout;
using Ts.IO;

namespace Ts.App.TableauViews.ViewTree {

    public interface IViewFactory<T> where T : ILayoutable {
        T GetView(SolutionNode node);
    }
}
