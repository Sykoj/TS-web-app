using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.TextView {

    public class TextViewOptions : ILayoutOptions<TextView> {

        public uint HorizontalMargin { get; set; } = 10;
        public uint VerticalMargin { get; set; } = 3;
    }
}
