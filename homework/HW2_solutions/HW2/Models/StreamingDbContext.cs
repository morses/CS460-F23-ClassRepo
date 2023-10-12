using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HW2.Models;

public partial class StreamingDbContext : DbContext
{
    public StreamingDbContext()
    {
    }

    public StreamingDbContext(DbContextOptions<StreamingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeCertification> AgeCertifications { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<GenreAssignment> GenreAssignments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }

    public virtual DbSet<ProductionCountryAssignment> ProductionCountryAssignments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<ShowType> ShowTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This is so lazy loading will work in LinqPAD, which doesn't use Program.cs
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=StreamingConnectionDocker");
        }
        optionsBuilder.UseLazyLoadingProxies();


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeCertification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgeCerti__3214EC2750A90FB8");
        });

        modelBuilder.Entity<Credit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Credit__3214EC275D3BD4AD");

            entity.HasOne(d => d.Person).WithMany(p => p.Credits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Credit_Fk_Person");

            entity.HasOne(d => d.Role).WithMany(p => p.Credits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Credit_Fk_Role");

            entity.HasOne(d => d.Show).WithMany(p => p.Credits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Credit_Fk_Show");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC2720B800AA");
        });

        modelBuilder.Entity<GenreAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GenreAss__3214EC27E7FC553D");

            entity.HasOne(d => d.Genre).WithMany(p => p.GenreAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GenreAssignment_Fk_Genre");

            entity.HasOne(d => d.Show).WithMany(p => p.GenreAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GenreAssignment_Fk_Show");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC27C99ED1E5");
        });

        modelBuilder.Entity<ProductionCountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3214EC27713D3DA5");
        });

        modelBuilder.Entity<ProductionCountryAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producti__3214EC27D5D9EF70");

            entity.HasOne(d => d.ProductionCountry).WithMany(p => p.ProductionCountryAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProdCountryAssign_Fk_ProductionCountry");

            entity.HasOne(d => d.Show).WithMany(p => p.ProductionCountryAssignments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProdCountryAssign_Fk_Show");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC2737AAF870");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Show__3214EC2712F90B7B");

            entity.HasOne(d => d.AgeCertification).WithMany(p => p.Shows).HasConstraintName("Show_Fk_AgeCertification");

            entity.HasOne(d => d.ShowType).WithMany(p => p.Shows)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Show_Fk_ShowType");
        });

        modelBuilder.Entity<ShowType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShowType__3214EC27BA61BFCA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
