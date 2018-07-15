using TsWebApp.TableauViews.Layout;

namespace TsWebApp.TableauViews {
    
    public class TextView : ILayoutable {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public string Representation { get; set; }
    }
}
