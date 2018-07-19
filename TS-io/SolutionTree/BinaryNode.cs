using Newtonsoft.Json;

namespace Ts.IO {
    
    public sealed class BinaryNode : SolutionNode {
        
        [JsonProperty("leftChild")]
        public SolutionNode LeftChild { get; set; }
        [JsonProperty("rightChild")]
        public SolutionNode RightChild { get; set; }
    }
}
