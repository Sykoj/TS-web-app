using System;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TableauxIO;
using TsWebApp.Model;

namespace TsWebApp.Services {

    public class TableauSolver : ITableauSolver {

        private readonly HttpClient _solverService;

        public TableauSolver(IConfiguration configuration) {
            _solverService = new HttpClient { BaseAddress = new Uri(configuration["TableauSolverService"]) };
        }

        public TableauOutput SolveTableauInput(TableauInput tableauInput) {

            var json = JsonConvert.SerializeObject(tableauInput);

            var content = new StringContent(
                JsonConvert.SerializeObject(tableauInput),
                Encoding.UTF8,
                "application/json");
           
            var responseTask = _solverService.PostAsync("api/solve-tableau", content);
            var response = responseTask.Result;
            var jsonResponse = response.Content.ReadAsStringAsync();
            var serializedNode = jsonResponse.Result;
            
            var tableauOutput = JsonConvert.DeserializeObject<TableauOutput>(serializedNode);
            tableauOutput.TableauType =
                TableauSolutionCategorizer.CategorizeTableauSolution(tableauOutput.SolutionNode);
            return tableauOutput;
        }

        public TableauOutput GetTableauInput(long solutionRequestId) {

            var responseTask = _solverService.GetAsync($"api/responses/{solutionRequestId}");
            var response = responseTask.Result;
            var jsonResponse = response.Content.ReadAsStringAsync();
            var serializedNode = jsonResponse.Result;

            return JsonConvert.DeserializeObject<TableauOutput>(serializedNode);
        }
    }
}
