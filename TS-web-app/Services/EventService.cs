using System.Linq;
using System.Security.Claims;
using TsWebApp.Data;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class EventService {

        private ApplicationDbContext DbContext { get; set; }

        public EventService(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public AppSolutionEventRequest CreateAppSolutionRequest(AppSolutionEventRequest appSolutionEventRequest, ClaimsPrincipal user) {

            appSolutionEventRequest.User = (user.Identity.IsAuthenticated) ? user.Identity.Name : "default";
            var entity = DbContext.AppSolutionRequests.Add(appSolutionEventRequest);
            DbContext.SaveChanges();
            return entity.Entity;
        }

        internal IQueryable<AppSolutionEventRequest> GetRequestsMadeByUser(string name) {

            var serializedSolutions = DbContext.TableauSolutions;
            var requests = DbContext.AppSolutionRequests.Where(r => r.User == name);

            return from s in serializedSolutions
                from r in requests
                where s.SolutionId == r.SolutionId
                select LoadSolution(r, s);
        }

        private AppSolutionEventRequest LoadSolution(AppSolutionEventRequest request, TableauSolutionSerialized serializedSolution) {

            var solution = serializedSolution.DeserializeSolution();
            request.TableauSolution = solution;
            return request;
        }

        public AppSolutionEventRequest LoadAppSolutionEventById(int requestId) {
            
            var solution = DbContext.AppSolutionRequests.Find(requestId);
            var serializedSolution = DbContext.TableauSolutions.Find(solution.SolutionId);
            return LoadSolution(solution, serializedSolution);
        }

        public TableauSolution LogTableauSolution(TableauSolution tableauSolution) {

            var solutionDb = TableauSolutionSerialized.SerializeSolution(tableauSolution);
            var loadedSolutionDb = DbContext.TableauSolutions.Add(solutionDb).Entity;
            DbContext.SaveChanges();
            tableauSolution.SolutionId = loadedSolutionDb.SolutionId;
            return tableauSolution;
        }

        public TableauSolution GetTableauRequest(int solutionId) {

            var solutionDb = DbContext.TableauSolutions.Find(solutionId);
            return solutionDb.DeserializeSolution();
        }
    }
}
