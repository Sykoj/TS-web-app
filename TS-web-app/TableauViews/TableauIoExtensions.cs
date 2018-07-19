using System;
using Ts.IO;

namespace TsWebApp.TableauViews {

    public static class TableauIoExtensions {

        public static string GetStringRepresentation(this TruthValue truthValue) {
            if (truthValue == TruthValue.True) return "T";
            if (truthValue == TruthValue.False) return "F";
            else throw new InvalidOperationException();
        }
    }
}
