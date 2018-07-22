using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ts.IO {
    
    /// <summary>
    /// Tableau input for tableau solver consists of pair
    /// (formula, truth label) used as tableau root and
    /// following pairs used as theory axioms
    /// </summary>
    public class TableauInput {
        
        [JsonProperty("root")]
        public TableauInputNode TableauRoot;
        [JsonProperty("theoryAxioms")]
        public IList<TableauInputNode> TheoryAxioms;

        public IEnumerable<TableauInputNode> GetAllNodes() {

            yield return TableauRoot;

            foreach (var axiom in TheoryAxioms) {
                yield return axiom;
            }
        }
    }

    /// <summary>
    /// Tableau input's node containing formula and it's truth label
    /// </summary>
    public struct TableauInputNode {

        [JsonProperty("formula")]
        public Formula Formula { get; set; }
        [JsonProperty("truthValue")]
        public TruthLabel TruthLabel { get; set; }
    }
}
