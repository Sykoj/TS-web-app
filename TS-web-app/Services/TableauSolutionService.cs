using System;
using Ts.App.Model;
using Ts.IO;

namespace Ts.App.Services {

    public class TableauSolutionService {

        private Solver.Solver TableauSolver { get; set; }

        public TableauSolutionService(Solver.Solver tableauSolver) {
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
