using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ts.App.Model;

namespace Ts.App.Data {

    public class ApplicationDbContext : IdentityDbContext {

        public DbSet<AppSolutionRequest> AppSolutionRequests { get; set; }
        public DbSet<TableauSolutionSerialized> TableauSerializedSolutions { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options) {
        }
    }
}
