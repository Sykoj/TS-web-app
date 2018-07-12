using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TsWebApp.Model;

namespace TsWebApp.Data {

    public class ApplicationDbContext : IdentityDbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<TableauRequest> TableauRequests { get; set; }
        public DbSet<UnparsedTableauNode> RawFormulas { get; set; }
    }
}
