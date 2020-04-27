using Excel_Reader.Models;
using ExcelReporter.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExcelReporter.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<ProjectSheet> ProjectSheets { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

    }
}
