﻿using System.Collections.Generic;
using System.Linq;

namespace Ts.App.Model {

    public class UnparsedTableauInput {
        
        public IList<FormulaParseRequest> FormulaParseRequests { get; set; } 
            = new List<FormulaParseRequest>();

        public TableauType ExpectedTableauType { get; set; }

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

        public UnparsedTableauNode UnparsedTableauNode { get; set; } = new UnparsedTableauNode();
        public string ErrorResponse { get; set; } = string.Empty;
    }
}
