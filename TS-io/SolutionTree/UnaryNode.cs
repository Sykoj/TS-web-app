using Newtonsoft.Json;

namespace Ts.IO {
    
    public class UnaryNode : SolutionNode {
        
        [JsonProperty("child")]
        public SolutionNode Child { get; set; }
    }
}
