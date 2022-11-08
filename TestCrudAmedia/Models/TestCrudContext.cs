using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestCrudAmedia.Models;

public partial class TestCrudContext : DbContext
{
    public TestCrudContext()
    {
    }

    public TestCrudContext(DbContextOptions<TestCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TGenero> TGeneros { get; set; }

    public virtual DbSet<TPelicula> TPeliculas { get; set; }

    public virtual DbSet<TRol> TRols { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-HENB25G;Database=TestCrud;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TGenero>(entity =>
        {
            entity.HasKey(e => e.CodGenero).HasName("PK__tGenero__0DACB9D5F5FC84CB");

            entity.ToTable("tGenero");

            entity.Property(e => e.CodGenero).HasColumnName("cod_genero");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");
        });

        modelBuilder.Entity<TPelicula>(entity =>
        {
            entity.HasKey(e => e.CodPelicula).HasName("PK__tPelicul__225F6E0801314B2E");

            entity.ToTable("tPelicula");

            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CantDisponiblesAlquiler).HasColumnName("cant_disponibles_alquiler");
            entity.Property(e => e.CantDisponiblesVenta).HasColumnName("cant_disponibles_venta");
            entity.Property(e => e.PrecioAlquiler)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_alquiler");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");

            entity.HasMany(d => d.CodGeneros).WithMany(p => p.CodPeliculas)
                .UsingEntity<Dictionary<string, object>>(
                    "TGeneroPelicula",
                    r => r.HasOne<TGenero>().WithMany()
                        .HasForeignKey("CodGenero")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_pelicula_genero"),
                    l => l.HasOne<TPelicula>().WithMany()
                        .HasForeignKey("CodPelicula")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_genero_pelicula"),
                    j =>
                    {
                        j.HasKey("CodPelicula", "CodGenero").HasName("PK__tGeneroP__6285A595C96AA3E2");
                        j.ToTable("tGeneroPelicula");
                    });
        });

        modelBuilder.Entity<TRol>(entity =>
        {
            entity.HasKey(e => e.CodRol).HasName("PK__tRol__F13B121117421CA9");

            entity.ToTable("tRol");

            entity.Property(e => e.CodRol).HasColumnName("cod_rol");
            entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            entity.Property(e => e.TxtDesc)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("txt_desc");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.CodUsuario).HasName("PK__tUsers__EA3C9B1A62B3B88A");

            entity.ToTable("tUsers");

            entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");
            entity.Property(e => e.CodRol).HasColumnName("cod_rol");
            entity.Property(e => e.NroDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nro_doc");
            entity.Property(e => e.SnActivo).HasColumnName("sn_activo");
            entity.Property(e => e.TxtApellido)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("txt_apellido");
            entity.Property(e => e.TxtNombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("txt_nombre");
            entity.Property(e => e.TxtPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("txt_password");
            entity.Property(e => e.TxtUser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("txt_user");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.CodRol)
                .HasConstraintName("fk_user_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
