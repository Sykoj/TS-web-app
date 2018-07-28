using Newtonsoft.Json;

namespace Ts.IO {

    /// <summary>
    /// Node of tableau solution tree representing an atomic tableau
    /// </summary>
    public abstract class SolutionNode {
        
        /// <summary>
        /// Root formula of atomic tableau
        /// </summary>
        [JsonProperty("formula")]
        public Formula Formula { get; set; }
        
        /// <summary>
        /// Truth label of atomic tableau
        /// </summary>
        [JsonProperty("truthValue")]
        public TruthLabel TruthLabel { get; set; }
    }
}
