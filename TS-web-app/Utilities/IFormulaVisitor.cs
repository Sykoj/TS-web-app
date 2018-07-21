using Ts.IO;

namespace TsWebApp.Utilities {

    public interface IFormulaVisitor<T> {

        T Visit(Formula formula);
    }
}
