using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssembly.Server.CapaDataAccess.DBContext;

public partial class DbBlazorMauiContext : DbContext
{
    public DbBlazorMauiContext() { }

    public DbBlazorMauiContext(DbContextOptions<DbBlazorMauiContext> options) : base(options) { }

    public virtual DbSet<TbPersona> TbPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=dbBlazorMAUI;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbPersona>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("tbPersona");

            entity.Property(e => e.PerEdad).HasColumnName("perEdad");
            entity.Property(e => e.PerEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perEmail");
            entity.Property(e => e.PerFechaAlta)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("perFechaAlta");
            entity.Property(e => e.PerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perNombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
