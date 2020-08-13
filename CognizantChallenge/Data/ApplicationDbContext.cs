using CognizantChallenge.Data.Configurations;
using CognizantChallenge.Data.Models;
using CognizantChallenge.Extensions;
using CognizantChallenge.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace CognizantChallenge.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserTaskSolution> UserTaskSolutions { get; set; }
        public DbSet<TopUserView> TopUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TopUserView>().HasNoKey().ToView("TopUser");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTaskSolutionConfiguration).Assembly);
            modelBuilder.Seed();
        }
    }
}
