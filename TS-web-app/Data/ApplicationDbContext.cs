using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TsWebApp.Model;

namespace TsWebApp.Data {

    public class ApplicationDbContext : IdentityDbContext {

        public DbSet<AppSolutionEventRequest> AppSolutionRequests { get; set; }
        public DbSet<TableauSolutionSerialized> TableauSolutions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
    }
}
