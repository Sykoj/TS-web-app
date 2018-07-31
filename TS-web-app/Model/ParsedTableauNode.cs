using Ts.IO;

namespace Ts.App.Model {

    /// <summary>
    /// Represents single unit of tableau input as (Formula, TruthLabel) pair
    /// </summary>
    public class ParsedTableauNode {
        public Formula Formula { get; set; } 
        public TruthLabel TruthLabel { get; set; }
    }
}
