﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime RequestDateTime { get; set; }
    }
}
