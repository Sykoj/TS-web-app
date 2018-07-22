using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ts.IO;

namespace Ts.App.Model {

    public class TableauSolution {

        [JsonProperty("solutionId")]
        public int SolutionId { get; set; }

        [JsonProperty("tableauInput")]
        public TableauInput TableauInput { get; set; }

        [JsonProperty("solutionNode")]
        public SolutionNode SolutionNode { get; set; }

        [JsonProperty("requestDate")]
        [JsonConverter(typeof(IsoDateTimeFormattedConverter))]
        public DateTime RequestDateTime { get; set; }

    }

    public class IsoDateTimeFormattedConverter : IsoDateTimeConverter {

        public IsoDateTimeFormattedConverter() {
            base.DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss'Z'";
        }
    }
}
