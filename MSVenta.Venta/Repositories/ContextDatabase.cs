﻿using Microsoft.EntityFrameworkCore;
using MSVenta.Venta.Models;

namespace MSVenta.Venta.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Models.Venta> Ventas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<ProductoAlmacen> ProductosAlmacenes { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar nombres de tablas
            modelBuilder.Entity<Cliente>().ToTable("cliente"); // 🚨 Nombre exacto de la tabla
            modelBuilder.Entity<Models.Venta>().ToTable("ventas");
            modelBuilder.Entity<Categoria>().ToTable("categoria");
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<Almacen>().ToTable("almacen");
            modelBuilder.Entity<ProductoAlmacen>().ToTable("producto_almacen");
            modelBuilder.Entity<DetalleVenta>().ToTable("detalle_venta");
            // Configuraciones de relaciones
            modelBuilder.Entity<Models.Producto>(entity =>
            {
                // Mapear columnas
                entity.Property(v => v.CategoriaId).HasColumnName("id_categoria"); // 🚨 Nombre real en DB
                

                // Relación con Categoría
                entity.HasOne(v => v.Categoria)
                      .WithMany()
                      .HasForeignKey(v => v.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Models.Venta>(entity =>
            {
                // Mapear columnas
                entity.Property(v => v.ClienteId).HasColumnName("id_cliente"); // 🚨 Nombre real en DB
                entity.Property(v => v.UsuarioId).HasColumnName("id_usuario"); // Si existe en el modelo

                // Relación con Cliente
                entity.HasOne(v => v.Cliente)
                      .WithMany()
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductoAlmacen>()
                .HasOne(pa => pa.Producto)
                .WithMany()
                .HasForeignKey(pa => pa.ProductoId);

            modelBuilder.Entity<ProductoAlmacen>(entity =>
            {
                entity.ToTable("producto_almacen");

                entity.Property(pa => pa.ProductoId)
                      .HasColumnName("id_producto");

                entity.Property(pa => pa.AlmacenId)
                      .HasColumnName("id_almacen");  // 👈 Asegúrate de que coincida con la DB

                entity.Property(pa => pa.Stock)
                      .HasColumnName("stock");

                // Relaciones
                entity.HasOne(pa => pa.Producto)
                      .WithMany()
                      .HasForeignKey(pa => pa.ProductoId);

                entity.HasOne(pa => pa.Almacen)
                      .WithMany()
                      .HasForeignKey(pa => pa.AlmacenId);
            });

            
            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("detalle_venta");    

                // Mapear columnas
                entity.Property(dv => dv.ProductoAlmacenId)
                      .HasColumnName("id_producto_almacen"); // 🚨 Nombre real en la DB

                entity.Property(dv => dv.VentaId)
                      .HasColumnName("id_venta");

                // Configurar relaciones
                entity.HasOne(dv => dv.ProductoAlmacen)
                      .WithMany()
                      .HasForeignKey(dv => dv.ProductoAlmacenId);

                entity.HasOne(dv => dv.Venta)
                      .WithMany()
                      .HasForeignKey(dv => dv.VentaId);
            });

          
        }
    }
}
