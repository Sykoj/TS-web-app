using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TableauxIO;
using TsWebApp.Data;
using TsWebApp.Model;

namespace TsWebApp.Pages.Tableau {
    public class SolutionViewModel : PageModel {

        private ApplicationDbContext Persistence { get; set; }

        public TableauRequest TableauRequest { get; set; }

        public SolutionNode SolutionNode { get; set; }

        public string ViewForm { get; set; }

        public SolutionViewModel(ApplicationDbContext persistence) {
            Persistence = persistence;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong id, string session) {

            var request = Persistence.TableauRequests.Find(id);
            Persistence.Entry(request).Collection(p => p.RawFormulas).Load();
            TableauRequest = request;

            string solutionJson = null;
            if (session != null) {

                solutionJson = HttpContext.Session.GetString(session);
                var solution = JsonConvert.DeserializeObject<Solution>(solutionJson);
                SolutionNode = solution.SolutionNode;
            }
        }
    }
}