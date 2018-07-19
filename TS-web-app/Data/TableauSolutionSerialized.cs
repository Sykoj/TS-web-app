using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Ts.IO;
using TsWebApp.Model;

namespace TsWebApp.Data {

    public class TableauSolutionSerialized {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong SolutionId { get; set; }
        public string TableauInputSerialized { get; set; }
        public string SolutionNodeSerialized { get; set; }
        public DateTime RequestDateTime { get; set; }

        public TableauSolution DeserializeSolution() {

           return new TableauSolution() {
               SolutionId = SolutionId,
               TableauInput = JsonConvert.DeserializeObject<TableauInput>(TableauInputSerialized),
               SolutionNode = JsonConvert.DeserializeObject<SerializationWrapper>(SolutionNodeSerialized).SolutionNode,
               RequestDateTime = RequestDateTime
           };
        }

        public static TableauSolutionSerialized SerializeSolution(TableauSolution tableauSolution) {

            return new TableauSolutionSerialized() {
                SolutionId = tableauSolution.SolutionId,
                TableauInputSerialized = JsonConvert.SerializeObject(tableauSolution.TableauInput),
                SolutionNodeSerialized = JsonConvert.SerializeObject(
                    new SerializationWrapper() { SolutionNode = tableauSolution.SolutionNode}),
                RequestDateTime = tableauSolution.RequestDateTime
            };
        }
    }

    internal class SerializationWrapper {
        [JsonProperty]
        internal SolutionNode SolutionNode { get; set; }
    }
}
