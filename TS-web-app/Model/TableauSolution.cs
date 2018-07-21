using System;
using System.Globalization;
using Newtonsoft.Json;
using Ts.IO;

namespace TsWebApp.Model {

    public class TableauSolution {

        [JsonProperty("solutionId")]
        public int SolutionId { get; set; }

        [JsonProperty("tableauInput")]
        public TableauInput TableauInput { get; set; }

        [JsonProperty("solutionNode")]
        public SolutionNode SolutionNode { get; set; }

        [JsonProperty("requestDate")]
        [JsonConverter(typeof(Iso8601DateConverter))]
        public DateTime RequestDateTime { get; set; }
    }

    internal class Iso8601DateConverter : JsonConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            if (value is DateTime date) {
                writer.WriteValue(date.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return false;
        }

        public override bool CanConvert(Type objectType) {
            return false;
        }
    }
}
