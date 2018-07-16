using System.Linq;
using System.Security.Claims;
using TsWebApp.Data;
using TsWebApp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
                SolverRequestId = tableauOutput.RequestId,
                Date = tableauOutput.RequestDate
            };
            DbContext.TableauRequests.Add(tableauRequest);
            DbContext.SaveChanges();
            return tableauRequest;
        }

        internal List<TableauRequest> GetRequestsMadeByUser(string name) {

            var userRequestsQuery
                = DbContext.TableauRequests
                  .Where(r => r.User == name)
                  .Include(r => r.RawFormulas);

            return userRequestsQuery.ToList();
        }
    }
}
