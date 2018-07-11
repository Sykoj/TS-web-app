using Newtonsoft.Json;
using TableauxIO;

namespace TsWebApp.Model {

    public class Solution {

        [JsonProperty("requestId")]
        public ulong RequestId { get; set; }
        [JsonProperty("solution")]
        public SolutionNode SolutionNode { get; set; }
    }
}
