using System;

namespace Ts.IO.Parser {

    public class ParseException : Exception {

        public ParseException(string message)
            : base(message) {
        }
    }
}
