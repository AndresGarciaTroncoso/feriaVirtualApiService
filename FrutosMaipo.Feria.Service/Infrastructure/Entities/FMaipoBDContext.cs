﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FrutosMaipo.Feria.Service.Infrastructure.Entities
{
    public partial class FMaipoBDContext : DbContext
    {
        public FMaipoBDContext()
        {
        }

        public FMaipoBDContext(DbContextOptions<FMaipoBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<EstadoProcesoVenta> EstadoProcesoVenta { get; set; }
        public virtual DbSet<EstadoSubasta> EstadoSubasta { get; set; }
        public virtual DbSet<Funcion> Funcion { get; set; }
        public virtual DbSet<FuncionRol> FuncionRol { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<ProcesoVenta> ProcesoVenta { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoPedido> ProductoPedido { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<Subasta> Subasta { get; set; }
        public virtual DbSet<TipoEstado> TipoEstado { get; set; }
        public virtual DbSet<TipoVenta> TipoVenta { get; set; }
        public virtual DbSet<Transporte> Transporte { get; set; }
        public virtual DbSet<Transportista> Transportista { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI;Initial Catalog=FMaipoBD;Persist Security Info=False;User ID=sa;Password=sa123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato);

                entity.Property(e => e.FechaContrato).HasColumnType("date");

                entity.Property(e => e.Vigencia).HasMaxLength(10);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoEstadoNavigation)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.TipoEstado)
                    .HasConstraintName("FK_Estado_TipoEstado");
            });

            modelBuilder.Entity<EstadoProcesoVenta>(entity =>
            {
                entity.HasKey(e => e.IdEstadoProcesoVenta);

                entity.Property(e => e.FechaEstado).HasColumnType("date");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.EstadoProcesoVenta)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoProcesoVenta_Estado");

                entity.HasOne(d => d.Estado1)
                    .WithMany(p => p.EstadoProcesoVenta)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoProcesoVenta_ProcesoVenta");
            });

            modelBuilder.Entity<EstadoSubasta>(entity =>
            {
                entity.HasKey(e => e.IdEstadoSubasta);

                entity.Property(e => e.FechaEstado).HasColumnType("date");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.EstadoSubasta)
                    .HasForeignKey(d => d.Estado)
                    .HasConstraintName("FK_EstadoSubasta_Estado");
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(e => e.IdFuncion);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoFuncion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FuncionRol>(entity =>
            {
                entity.HasKey(e => e.IdFuncionRol);

                entity.HasOne(d => d.FuncionNavigation)
                    .WithMany(p => p.FuncionRol)
                    .HasForeignKey(d => d.Funcion)
                    .HasConstraintName("FK_FuncionRol_Funcion");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.FuncionRol)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_FuncionRol_Rol");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Vigencia).HasMaxLength(10);
            });

            modelBuilder.Entity<ProcesoVenta>(entity =>
            {
                entity.HasKey(e => e.IdProcesoVenta);

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.FechaTermino).HasColumnType("date");

                entity.HasOne(d => d.SolicitudNavigation)
                    .WithMany(p => p.ProcesoVenta)
                    .HasForeignKey(d => d.Solicitud)
                    .HasConstraintName("FK_ProcesoVenta_Solicitud");

                entity.HasOne(d => d.TipoVentaNavigation)
                    .WithMany(p => p.ProcesoVenta)
                    .HasForeignKey(d => d.TipoVenta)
                    .HasConstraintName("FK_ProcesoVenta_TipoVenta");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductoPedido>(entity =>
            {
                entity.HasKey(e => e.IdProductoPedido);

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany(p => p.ProductoPedido)
                    .HasForeignKey(d => d.Pedido)
                    .HasConstraintName("FK_ProductoPedido_Pedido");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.ProductoPedido)
                    .HasForeignKey(d => d.Producto)
                    .HasConstraintName("FK_ProductoPedido_Producto");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vigencia).HasMaxLength(10);
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud);

                entity.Property(e => e.FechaSolicitud).HasColumnType("date");

                entity.HasOne(d => d.PedidoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.Pedido)
                    .HasConstraintName("FK_Solicitud_Pedido");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.Usuario)
                    .HasConstraintName("FK_Solicitud_Usuario");
            });

            modelBuilder.Entity<Subasta>(entity =>
            {
                entity.HasKey(e => e.IdSubasta);

                entity.HasOne(d => d.ProcesoVentaNavigation)
                    .WithMany(p => p.Subasta)
                    .HasForeignKey(d => d.ProcesoVenta)
                    .HasConstraintName("FK_Subasta_ProcesoVenta");

                entity.HasOne(d => d.TranportistaNavigation)
                    .WithMany(p => p.Subasta)
                    .HasForeignKey(d => d.Tranportista)
                    .HasConstraintName("FK_Subasta_Transportista");
            });

            modelBuilder.Entity<TipoEstado>(entity =>
            {
                entity.HasKey(e => e.IdTipoEstado);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoVenta>(entity =>
            {
                entity.HasKey(e => e.IdTipoVenta);

                entity.Property(e => e.Descipcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transporte>(entity =>
            {
                entity.HasKey(e => e.IdTransporte);

                entity.Property(e => e.Patente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Refrigeracion).HasMaxLength(10);
            });

            modelBuilder.Entity<Transportista>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.Property(e => e.Rut).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.TransporteNavigation)
                    .WithMany(p => p.Transportista)
                    .HasForeignKey(d => d.Transporte)
                    .HasConstraintName("FK_Transportista_Transporte");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.Property(e => e.Rut).ValueGeneratedNever();

                entity.Property(e => e.Dv)
                    .HasColumnName("DV")
                    .HasMaxLength(10);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Vigencia).HasMaxLength(10);

                entity.HasOne(d => d.ContratoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Contrato)
                    .HasConstraintName("FK_Usuario_Contrato");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.Rol)
                    .HasConstraintName("FK_Usuario_Rol");
            });
        }
    }
}