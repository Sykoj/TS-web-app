using Newtonsoft.Json;
using TableauxIO;

namespace TsWebApp.Model {

    public class RequestResult {

        [JsonProperty("requestId")]
        public ulong RequestId { get; private set; }

        [JsonProperty("solution")]
        public SolutionNode SolutionNode { get; private set; }
    }
}
