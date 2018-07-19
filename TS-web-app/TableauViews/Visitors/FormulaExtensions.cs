using Ts.IO;

namespace TsWebApp.TableauViews {

    public static class FormulaExtensions {

        public static T Apply<T>(this Formula f, IFormulaVisitor<T> visitor) {
            return visitor.Visit(f);
        }
    }
}
