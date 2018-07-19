using System.Collections.Generic;
using Ts.IO;

namespace Ts.Solver {
    
    public class Solver : ITableauSolver {
        
        public SolutionNode Solve(TableauInput input) {

            var initialBranch = new Branch();
            initialBranch.AddNewFormula(new BranchItem(input.Root));

            if (input.TheoryAxioms == null) input.TheoryAxioms = new List<TableauInputNode>();
            
            foreach (var axiom in input.TheoryAxioms) {
                initialBranch.AddAxiom(new BranchItem(axiom));
            }

            return initialBranch.Develop();
        }
    }
}
