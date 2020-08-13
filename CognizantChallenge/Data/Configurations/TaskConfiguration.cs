using CognizantChallenge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CognizantChallenge.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Input).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Output).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.HasMany(x => x.UserTaskSolutions)
                .WithOne(x => x.Task)
                .HasForeignKey(x => x.TaskId);
        }
    }
}
