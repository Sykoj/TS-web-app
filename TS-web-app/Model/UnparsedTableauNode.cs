using Ts.IO;

namespace Ts.App.Model {

    public class UnparsedTableauNode {
        public string Formula { get; set; } = string.Empty;
        public TruthLabel TruthLabel { get; set; } = TruthLabel.True;
    }
}
