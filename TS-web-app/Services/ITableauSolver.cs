using TableauxIO;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public interface ITableauSolver {

        TableauOutput SolveTableauInput(TableauInput tableauInput);
    }
}
