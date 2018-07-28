using Ts.App.Utilities;
using Ts.IO;

namespace Ts.App.Extensions {

    public static class FormulaExtensions {

        public static T Apply<T>(this Formula f, IFormulaVisitor<T> visitor) {
            return visitor.Visit(f);
        }
    }
}
