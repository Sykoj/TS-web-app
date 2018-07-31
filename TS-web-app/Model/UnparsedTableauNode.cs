using Ts.IO;

namespace Ts.App.Model {
    
    /// <summary>
    /// Represents single unit of unparsed input as (unparsed formula, truth label) pair
    /// </summary>
    public class UnparsedTableauNode {
        public string Formula { get; set; } = string.Empty;
        public TruthLabel TruthLabel { get; set; } = TruthLabel.True;
    }
}
