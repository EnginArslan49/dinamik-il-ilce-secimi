using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ililceSecimi.Models;

public partial class DbIlIlceSecimiContext : DbContext
{
    public DbIlIlceSecimiContext()
    {
    }

    public DbIlIlceSecimiContext(DbContextOptions<DbIlIlceSecimiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ilceler> Ilcelers { get; set; }

    public virtual DbSet<Iller> Illers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=<localhost, . veya .\\SQLEXPRESS>;Database=DB_il_ilceSecimi;User Id=<sqlServerDogrulamaKullaniciAdiniz>;Password=<sqlServerDogrulamaKullaniciSifreniz>;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ilceler>(entity =>
        {
            entity.HasKey(e => e.IlceId);

            entity.ToTable("Ilceler");

            entity.Property(e => e.IlceId).HasColumnName("ilceID");
            entity.Property(e => e.IlId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ilID");
            entity.Property(e => e.IlceAdi)
                .HasMaxLength(50)
                .HasColumnName("ilceAdi");
        });

        modelBuilder.Entity<Iller>(entity =>
        {
            entity.HasKey(e => e.IlId);

            entity.ToTable("Iller");

            entity.Property(e => e.IlId).HasColumnName("ilID");
            entity.Property(e => e.IlAdi)
                .HasMaxLength(50)
                .HasColumnName("ilAdi");
            entity.Property(e => e.IlKodu)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ilKodu");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
