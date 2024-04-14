using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Presupuestos;

public partial class Context : DbContext
{
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

            entity.HasOne(d => d.Budget).WithMany(p => p.Articles)
                .HasForeignKey(d => d.BudgetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Article_Budget");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("Budget");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ValueStart).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Area).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Budget_Area");

            entity.HasOne(d => d.BudgetAccount).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.BudgetAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Budget_Budget");
        });

        modelBuilder.Entity<BudgetAccount>(entity =>
        {
            entity.ToTable("BudgetAccount", tb => tb.HasTrigger("TR_NumberAccount_INSERT"));

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
