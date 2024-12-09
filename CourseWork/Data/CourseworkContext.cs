using System;
using System.Collections.Generic;
using CourseWork.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data;

public partial class CourseworkContext : DbContext
{
    public CourseworkContext()
    {
    }

    public CourseworkContext(DbContextOptions<CourseworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Changed> Changeds { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Stuff> Stuffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=coursework;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cabinet_pkey");

            entity.ToTable("cabinet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .HasColumnName("number");
        });

        modelBuilder.Entity<Changed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("changed_pkey");

            entity.ToTable("changed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cabinetout).HasColumnName("cabinetout");
            entity.Property(e => e.Cabinetto).HasColumnName("cabinetto");
            entity.Property(e => e.Stuffid).HasColumnName("stuffid");

            entity.HasOne(d => d.CabinetoutNavigation).WithMany(p => p.ChangedCabinetoutNavigations)
                .HasForeignKey(d => d.Cabinetout)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("changed_cabinetout_fkey");

            entity.HasOne(d => d.CabinettoNavigation).WithMany(p => p.ChangedCabinettoNavigations)
                .HasForeignKey(d => d.Cabinetto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("changed_cabinetto_fkey");

            entity.HasOne(d => d.Stuff).WithMany(p => p.Changeds)
                .HasForeignKey(d => d.Stuffid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("changed_stuffid_fkey");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("item_pkey");

            entity.ToTable("item");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

            entity.ToTable("status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Stuff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stuff_pkey");

            entity.ToTable("stuff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cabinetid).HasColumnName("cabinetid");
            entity.Property(e => e.Itemid).HasColumnName("itemid");
            entity.Property(e => e.Statusid).HasColumnName("statusid");

            entity.HasOne(d => d.Cabinet).WithMany(p => p.Stuffs)
                .HasForeignKey(d => d.Cabinetid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stuff_cabinetid_fkey");

            entity.HasOne(d => d.Item).WithMany(p => p.Stuffs)
                .HasForeignKey(d => d.Itemid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stuff_itemid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Stuffs)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stuff_statusid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
