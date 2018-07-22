using Ts.App.TableauViews.Layout;

namespace Ts.App.TableauViews.TextView {
    
    public class TextView : ILayoutable {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public string Representation { get; set; }
    }
}
