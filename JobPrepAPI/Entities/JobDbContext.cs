using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobPrepAPI.Entities;

public partial class JobDbContext : DbContext
{
    public JobDbContext()
    {
    }

    public JobDbContext(DbContextOptions<JobDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<JobDescription> JobDescriptions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobDescr__3214EC0701A9311D");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DescriptionText).HasColumnType("text");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07E480BB23");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.QuestionText).HasColumnType("text");

            entity.HasOne(d => d.JobDescription).WithMany(p => p.Questions)
                .HasForeignKey(d => d.JobDescriptionId)
                .HasConstraintName("FK__Questions__JobDe__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
