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

    public virtual DbSet<TPeliculaAlquiladum> TPeliculaAlquilada { get; set; }

    public virtual DbSet<TPeliculaVendidum> TPeliculaVendida { get; set; }

    public virtual DbSet<TRol> TRols { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

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

        modelBuilder.Entity<TPeliculaAlquiladum>(entity =>
        {
            entity.HasKey(e => e.CodPeliculaAlquilada);

            entity.ToTable("tPeliculaAlquilada");

            entity.Property(e => e.CodPeliculaAlquilada).HasColumnName("cod_pelicula_alquilada");
            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CodUsuarioCliente).HasColumnName("cod_usuario_cliente");
            entity.Property(e => e.CodUsuarioCreador).HasColumnName("cod_usuario_creador");
            entity.Property(e => e.Devuelta).HasColumnName("devuelta");
            entity.Property(e => e.FechaDevuelta)
                .HasColumnType("datetime")
                .HasColumnName("fecha_devuelta");
            entity.Property(e => e.FechaTomada)
                .HasColumnType("datetime")
                .HasColumnName("fecha_tomada");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.CodPeliculaNavigation).WithMany(p => p.TPeliculaAlquilada)
                .HasForeignKey(d => d.CodPelicula)
                .HasConstraintName("FK_tPeliculaAlquilada_tPelicula");

            entity.HasOne(d => d.CodUsuarioClienteNavigation).WithMany(p => p.TPeliculaAlquiladumCodUsuarioClienteNavigations)
                .HasForeignKey(d => d.CodUsuarioCliente)
                .HasConstraintName("FK_tPeliculaAlquilada_tUsersCliente");

            entity.HasOne(d => d.CodUsuarioCreadorNavigation).WithMany(p => p.TPeliculaAlquiladumCodUsuarioCreadorNavigations)
                .HasForeignKey(d => d.CodUsuarioCreador)
                .HasConstraintName("FK_tPeliculaAlquilada_tUsersCreador");
        });

        modelBuilder.Entity<TPeliculaVendidum>(entity =>
        {
            entity.HasKey(e => e.CodPeliculaVendida);

            entity.ToTable("tPeliculaVendida");

            entity.Property(e => e.CodPeliculaVendida).HasColumnName("cod_pelicula_vendida");
            entity.Property(e => e.CodPelicula).HasColumnName("cod_pelicula");
            entity.Property(e => e.CodUsuarioCliente).HasColumnName("cod_usuario_cliente");
            entity.Property(e => e.CodUsuarioCreador).HasColumnName("cod_usuario_creador");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.CodPeliculaNavigation).WithMany(p => p.TPeliculaVendida)
                .HasForeignKey(d => d.CodPelicula)
                .HasConstraintName("FK_tPeliculaVendida_tPelicula");

            entity.HasOne(d => d.CodUsuarioClienteNavigation).WithMany(p => p.TPeliculaVendidumCodUsuarioClienteNavigations)
                .HasForeignKey(d => d.CodUsuarioCliente)
                .HasConstraintName("FK_tPeliculaVendida_tUsersCliente");

            entity.HasOne(d => d.CodUsuarioCreadorNavigation).WithMany(p => p.TPeliculaVendidumCodUsuarioCreadorNavigations)
                .HasForeignKey(d => d.CodUsuarioCreador)
                .HasConstraintName("FK_tPeliculaVendida_tUsersCreador");
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
