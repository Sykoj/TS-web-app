namespace TsWebApp.TableauViews.Layout {

    public interface ILayoutOptions<T> where T : ILayoutable {
        uint HorizontalMargin { get; set; }
        uint VerticalMargin { get; set; }
    }
}
