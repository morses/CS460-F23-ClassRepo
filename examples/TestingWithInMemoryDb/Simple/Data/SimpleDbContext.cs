using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Simple.Models;

namespace Simple.Data;

public partial class SimpleDbContext : DbContext
{
    public SimpleDbContext()
    {
    }

    public SimpleDbContext(DbContextOptions<SimpleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<UserLog> UserLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=AppConnection");
        }
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Color__3214EC27A791E074");
        });

        modelBuilder.Entity<UserLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLog__3214EC2715F4C843");

            entity.HasOne(d => d.Color).WithMany(p => p.UserLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserLog_Fk_Color");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
