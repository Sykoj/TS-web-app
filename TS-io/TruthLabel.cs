using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ts.IO {

    /// <summary>
    /// Value representing whether a formula should is true or false on tableau branch
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TruthLabel {

        [EnumMember(Value = "True")]
        True,
        [EnumMember(Value = "False")]
        False
    }
    
    public static class TruthValueExtensions {
        
        public static TruthLabel GetOpposite(this TruthLabel label) {
            var oppositeValue = TruthLabel.True == label ? TruthLabel.False : TruthLabel.True;
            return oppositeValue;
        }

        public static int GetBinaryValue(this TruthLabel label) {
            return (label == TruthLabel.True) ? 1 : 0;
        }

        public static string ToString(this TruthLabel truthLabel) {
            return (truthLabel == TruthLabel.True) ? "True" : "False";
        }
    }
}
