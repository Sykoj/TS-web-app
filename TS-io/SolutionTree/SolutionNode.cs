using Newtonsoft.Json;

namespace Ts.IO {
    
    public abstract class SolutionNode {
        
        [JsonProperty("formula")]
        public Formula Formula { get; set; }
        [JsonProperty("truthValue")]
        public TruthValue TruthValue { get; set; }
    }
}
