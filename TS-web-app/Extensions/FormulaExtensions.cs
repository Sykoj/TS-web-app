using Ts.IO;
using TsWebApp.Utilities;

namespace TsWebApp.Extensions {

    public static class FormulaExtensions {

        public static T Apply<T>(this Formula f, IFormulaVisitor<T> visitor) {
            return visitor.Visit(f);
        }
    }
}
