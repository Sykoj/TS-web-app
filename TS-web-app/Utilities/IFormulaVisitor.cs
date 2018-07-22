using Ts.IO;

namespace Ts.App.Utilities {

    public interface IFormulaVisitor<T> {

        T Visit(Formula formula);
    }
}
