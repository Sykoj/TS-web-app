using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TableauxIO;
using TsWebApp.Data;
using TsWebApp.Model;
using TsWebApp.Services;

namespace TsWebApp.Pages.Tableau {

    public class SolutionViewModel : PageModel {

        public enum SolutionViewType { Text, Svg };

        public SolutionViewType ViewType { get; set; } 

        private ApplicationDbContext Persistence { get; set; }

        public TableauRequest TableauRequest { get; set; }

        public SolutionNode SolutionNode { get; set; }
        
        public TableauSolver TableauSolver { get; }

        public SolutionViewModel(ApplicationDbContext persistence, TableauSolver tableauSolver) {
            Persistence = persistence;
            TableauSolver = tableauSolver;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong id, string session, SolutionViewType solutionViewType) {

            ViewType = solutionViewType;

            var request = Persistence.TableauRequests.Find(id);
            Persistence.Entry(request).Collection(p => p.RawFormulas).Load();
            TableauRequest = request;

            if (session != null) {

                var solutionJson = HttpContext.Session.GetString(session);
                var result = JsonConvert.DeserializeObject<RequestResult>(solutionJson);
                SolutionNode = result.SolutionNode;
            }
            else {
                SolutionNode = TableauSolver.GetTableauInput((long) request.SolverRequestId).SolutionNode;
            }
        }
    }
}
