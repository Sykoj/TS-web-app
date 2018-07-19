using Ts.IO;

namespace TsWebApp.TableauViews.Layout {

    public interface IViewFactory<T> where T : ILayoutable {
        T GetView(SolutionNode node);
    }
}
