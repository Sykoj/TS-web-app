using Newtonsoft.Json;

namespace Ts.IO {

    /// <summary>
    /// Node of tableau solution tree representing an atomic tableau that forks the current branch
    /// </summary>
    public sealed class BinaryNode : SolutionNode {
        
        /// <summary>
        /// First node of the left branch that is product of current node's atomic tableau fork
        /// </summary>
        [JsonProperty("leftChild")]
        public SolutionNode LeftChild { get; set; }

        /// <summary>
        /// First node of the right branch that is product of current node's atomic tableau fork
        /// </summary>
        [JsonProperty("rightChild")]
        public SolutionNode RightChild { get; set; }
    }
}
