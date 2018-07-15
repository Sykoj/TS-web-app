using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews {

    public class TextViewOptions : ILayoutOptions<TextView> {

        public uint HorizontalMargin { get; set; } = 10;
        public uint VerticalMargin { get; set; } = 2;
        public LayoutProcessor<TextView>.RootPositionSetter RootPosition { get; set; }
            = (treeWidth, treeHeight, nodeWidth, nodeHeight) => {


                return ((int)((treeWidth / 2) - (nodeWidth / 2)), 0);
            };
    }
}
