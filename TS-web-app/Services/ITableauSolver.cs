using TableauxIO;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public interface ITableauSolver {

        RequestResult SolveTableauInput(TableauInput tableauInput);
    }
}
