using System;

namespace Ts.App.Exceptions {

    public class ConversionException : Exception {
        public ConversionException(string message) : base(message) {
        }
    }
}
