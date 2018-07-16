using TableauxIO;

namespace TsWebApp.TableauViews.Layout {

    public interface IViewFactory<T> where T : ILayoutable {
        T GetView(SolutionNode node);
    }
}
