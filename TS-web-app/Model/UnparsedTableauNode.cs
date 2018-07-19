using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ts.IO;

namespace TsWebApp.Model {

    public class UnparsedTableauNode {
        public string Formula { get; set; } = string.Empty;
        public TruthValue TruthLabel { get; set; } = TruthValue.True;
    }
}
