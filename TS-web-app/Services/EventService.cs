using System.Linq;
using System.Security.Claims;
using TableauxIO;
using TsWebApp.Data;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class EventService {

        private ApplicationDbContext DbContext { get; set; }

        public EventService(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public TableauRequest LogSolutionEvent(UnparsedTableauInput tableauInput, RequestResult tableauOutput, ClaimsPrincipal user) {

            var username = (user.Identity.IsAuthenticated) ? user.Identity.Name : "default";
            var tableauRequest = new TableauRequest() {
                RawFormulas = (from f in tableauInput.FormulaParseRequests select f.UnparsedTableauNode).ToList(),
                User = username,
                SolverRequestId = tableauOutput.RequestId
            };
            DbContext.TableauRequests.Add(tableauRequest);
            DbContext.SaveChanges();
            return tableauRequest;
        }
    }
}
