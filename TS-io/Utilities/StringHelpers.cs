using System.Linq;

namespace Ts.IO.Utilities {

    internal static class StringExtensions {

        internal static string RemoveWhitespace(this string input) {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
