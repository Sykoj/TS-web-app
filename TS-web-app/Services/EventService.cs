using System;
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

        public object LogSolutionEvent(TableauInput tableauInput, RequestResult tableauOutput, ClaimsPrincipal user) {

            //var username = (user.Identity.IsAuthenticated) ? user.Identity.Name : "default";
            //var tableauRequest = new TableauRequest() {
            
            throw new NotImplementedException();
        }
    }
}
