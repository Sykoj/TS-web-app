using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ts.IO {

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TruthValue {

        [EnumMember(Value = "True")]
        True,
        [EnumMember(Value = "False")]
        False
    }
    
    public static class TruthValueExtensions {
        
        public static TruthValue GetOpposite(this TruthValue value) {
            var oppositeValue = TruthValue.True == value ? TruthValue.False : TruthValue.True;
            return oppositeValue;
        }

        public static int GetBinaryValue(this TruthValue value) {
            return (value == TruthValue.True) ? 1 : 0;
        }

        public static string ToString(this TruthValue truthValue) {
            return (truthValue == TruthValue.True) ? "True" : "False";
        }
    }
}
