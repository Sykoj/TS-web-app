using Ts.IO;

namespace Ts.Solver {
    
    public interface ITableauSolver {

        SolutionNode Solve(TableauInput input);
    }
}