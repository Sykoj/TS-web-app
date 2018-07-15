using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews {

    public class TextViewOptions : ILayoutOptions<TextView> {

        public uint HorizontalMargin { get; set; } = 10;
        public uint VerticalMargin { get; set; } = 3;
    }
}
