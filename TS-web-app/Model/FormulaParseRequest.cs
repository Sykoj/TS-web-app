using System.Collections.Generic;
using System.Linq;

namespace TsWebApp.Model {

    public class UnparsedTableauInput {
        
        public IList<FormulaParseRequest> FormulaParseRequests { get; set; } = new List<FormulaParseRequest>();

        public bool HasAtleastOneParseRequest() {
            return FormulaParseRequests.Count != 0;
        }

        public bool HasErrorResponse() {

            return (from f in FormulaParseRequests
                where f.ErrorResponse != string.Empty
                select f).Any();
        }
    }

    public class FormulaParseRequest {

        public RawFormula RawFormula { get; set; } = new RawFormula();
        public string ErrorResponse { get; set; } = string.Empty;
    }
}
