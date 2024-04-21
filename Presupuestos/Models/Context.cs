﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Presupuestos;

public partial class Context : DbContext
{
    private static Context? instance;

    public static Context Instance
    {
        get { return instance = new Context(); }
    }

    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<BudgetAccount> BudgetAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=Presupuestos;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("Area");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([Value]*[Amount])", false)
                .HasColumnType("decimal(29, 0)");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.NumberAccount });

            entity.ToTable("Budget");

            entity.Property(e => e.NumberAccount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ValueStart).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Area).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Budget_Area");

            entity.HasOne(d => d.NumberAccountNavigation).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.NumberAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Budget_BudgetAccount");
        });

        modelBuilder.Entity<BudgetAccount>(entity =>
        {
            entity.HasKey(e => e.NumberAccount);

            entity.ToTable("BudgetAccount");

            entity.Property(e => e.NumberAccount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.BudgetAccountCode).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Level).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Number).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.BudgetAccountCodeNavigation).WithMany(p => p.InverseBudgetAccountCodeNavigation)
                .HasForeignKey(d => d.BudgetAccountCode)
                .HasConstraintName("FK_BudgetAccount_BudgetAccount");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
