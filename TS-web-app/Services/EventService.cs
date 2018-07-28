using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ts.App.Data;
using Ts.App.Model;

namespace Ts.App.Services {

    public class EventService {

        private ApplicationDbContext DbContext { get; set; }

        public EventService(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public async Task<AppSolutionRequest> CreateAppSolutionRequest(AppSolutionRequest appSolutionRequest, ClaimsPrincipal user) {

            appSolutionRequest.User = (user.Identity.IsAuthenticated) ? user.Identity.Name : "default";
            var entity = DbContext.AppSolutionRequests.Add(appSolutionRequest);
            await DbContext.SaveChangesAsync();
            return entity.Entity;
        }

        internal IQueryable<AppSolutionRequest> GetRequestsMadeByUser(string name) {

            var serializedSolutions = DbContext.TableauSerializedSolutions;
            var requests = DbContext.AppSolutionRequests.Where(r => r.User == name);

            return from s in serializedSolutions
                from r in requests
                where s.SolutionId == r.SolutionId
                select LoadSolution(r, s);
        }

        private AppSolutionRequest LoadSolution(AppSolutionRequest request, TableauSolutionSerialized serializedSolution) {

            var solution = serializedSolution.DeserializeSolution();
            request.TableauSolution = solution;
            return request;
        }

        public AppSolutionRequest LoadAppSolutionEventById(int requestId) {
            
            var solution = DbContext.AppSolutionRequests.Find(requestId);
            var serializedSolution = DbContext.TableauSerializedSolutions.Find(solution.SolutionId);
            return LoadSolution(solution, serializedSolution);
        }

        public TableauSolution LogTableauSolution(TableauSolution tableauSolution) {

            var solutionDb = TableauSolutionSerialized.SerializeSolution(tableauSolution);
            var loadedSolutionDb = DbContext.TableauSerializedSolutions.Add(solutionDb).Entity;
            DbContext.SaveChanges();
            tableauSolution.SolutionId = loadedSolutionDb.SolutionId;
            return tableauSolution;
        }

        public TableauSolution GetTableauSolution(int solutionId) {

            var solutionDb = DbContext.TableauSerializedSolutions.Find(solutionId);
            return solutionDb?.DeserializeSolution();
        }
    }
}
