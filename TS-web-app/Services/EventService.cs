using System.Linq;
using System.Security.Claims;
using TsWebApp.Data;
using TsWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace TsWebApp.Services {

    public class EventService {

        private ApplicationDbContext DbContext { get; set; }

        public EventService(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public TableauSolutionEvent LogSolutionEvent(UnparsedTableauInput tableauInput, TableauOutput tableauOutput, ClaimsPrincipal user) {

            var username = (user.Identity.IsAuthenticated) ? user.Identity.Name : "default";
            var tableauRequest = new TableauSolutionEvent() {
                RawFormulas = (from f in tableauInput.FormulaParseRequests select f.UnparsedTableauNode).ToList(),
                User = username,
                SolverRequestId = tableauOutput.RequestId,
                Date = tableauOutput.RequestDate,
                ExpectedTableauType = tableauInput.ExpectedTableauType,
                TableauType = tableauOutput.TableauType
            };
            DbContext.TableauRequests.Add(tableauRequest);
            DbContext.SaveChanges();
            return tableauRequest;
        }

        internal IQueryable<TableauSolutionEvent> GetRequestsMadeByUser(string name) {

            return DbContext.TableauRequests
                  .Where(r => r.User == name)
                  .Include(r => r.RawFormulas);
        }

        public TableauSolutionEvent LoadTableauSolutionEventById(ulong id) {

            var solutionEvent = DbContext.TableauRequests.Find(id);
            DbContext.Entry(solutionEvent).Collection(p => p.RawFormulas).Load();
            return solutionEvent;
        }
    }
}
