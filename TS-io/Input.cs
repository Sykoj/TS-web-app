using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ts.IO {
    
    public class TableauInput {
        
        [JsonProperty("root")]
        public TableauInputNode Root;
        [JsonProperty("theoryAxioms")]
        public IList<TableauInputNode> TheoryAxioms;

        public IEnumerable<TableauInputNode> GetAllNodes() {

            yield return Root;

            foreach (var axiom in TheoryAxioms) {
                yield return axiom;
            }
        }
    }

    public struct TableauInputNode {

        [JsonProperty("formula")]
        public Formula Formula { get; set; }
        [JsonProperty("truthValue")]
        public TruthValue TruthValue { get; set; }
    }
}
