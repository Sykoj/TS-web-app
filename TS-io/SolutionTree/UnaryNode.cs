using Newtonsoft.Json;

namespace Ts.IO {

    /// <summary>
    /// Node of tableau solution tree representing an atomic tableau developing
    /// this node on the same branch
    /// </summary>
    public class UnaryNode : SolutionNode {

        /// <summary>
        /// First node of the same branch that is product of current node's atomic tableau
        /// </summary>
        [JsonProperty("child")]
        public SolutionNode Child { get; set; }
    }
}
