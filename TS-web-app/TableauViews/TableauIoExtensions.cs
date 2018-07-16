using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauxIO;

namespace TsWebApp.TableauViews {

    public static class TableauIoExtensions {

        public static string GetStringRepresentation(this TruthValue truthValue) {
            if (truthValue == TruthValue.True) return "T";
            if (truthValue == TruthValue.False) return "F";
            else throw new InvalidOperationException();
        }
    }
}
