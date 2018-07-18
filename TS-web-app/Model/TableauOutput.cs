using System;
using Newtonsoft.Json;
using TableauxIO;

namespace TsWebApp.Model {

    public class TableauOutput {

        [JsonProperty("requestId")]
        public ulong RequestId { get; private set; }

        [JsonProperty("solution")]
        public SolutionNode SolutionNode { get; private set; }

        [JsonProperty("requestDate")]
        public DateTime RequestDate { get; private set; }

        public TableauType TableauType { get; set; }
    }
}
