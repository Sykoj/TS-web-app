using System;
using Ts.IO;

namespace Ts.App.Extensions {

    public static class TableauIoExtensions {

        public static string GetStringRepresentation(this TruthLabel truthLabel) {
            if (truthLabel == TruthLabel.True) return "T";
            if (truthLabel == TruthLabel.False) return "F";
            else throw new InvalidOperationException();
        }
    }
}
