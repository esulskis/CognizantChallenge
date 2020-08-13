using CognizantChallenge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CognizantChallenge.Data.Configurations
{
    public class UserTaskSolutionConfiguration : IEntityTypeConfiguration<UserTaskSolution>
    {
        public void Configure(EntityTypeBuilder<UserTaskSolution> builder)
        {
            builder.ToTable("UserTaskSolution");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Solution).HasMaxLength(2000);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTaskSolutions)
                .HasForeignKey(x => x.UserId);
        }
    }
}
