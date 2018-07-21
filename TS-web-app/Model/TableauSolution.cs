using System;
using Ts.IO;

namespace TsWebApp.Model {

    public class TableauSolution {

        public int SolutionId { get; set; }
        public TableauInput TableauInput { get; set; }
        public SolutionNode SolutionNode { get; set; }
        public DateTime RequestDateTime { get; set; }
    }
}
