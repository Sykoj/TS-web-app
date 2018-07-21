using System;
using Ts.IO;
using Ts.Solver;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class TableauSolutionService {

        private Solver TableauSolver { get; set; }

        public TableauSolutionService(Solver tableauSolver) {
            TableauSolver = tableauSolver;
        }

        public TableauSolution ComputeTableauSolution(TableauInput tableauInput) {

            var solutionTableau = TableauSolver.Solve(tableauInput);

            var tableauSolution = new TableauSolution() {
                SolutionNode = solutionTableau,
                TableauInput = tableauInput,
                RequestDateTime = DateTime.Now
            };

            return tableauSolution;
        }

    }
}
