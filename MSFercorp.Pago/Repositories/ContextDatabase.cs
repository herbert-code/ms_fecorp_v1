﻿using Microsoft.EntityFrameworkCore;
using MSFercorp.Pago.Models;

namespace MSFercorp.Pago.Repositories
{
    public class ContextDatabase : DbContext
    {
        public ContextDatabase(DbContextOptions<ContextDatabase> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Models.Pago> Pagos { get; set; }
        public DbSet<DetallePago> DetallePagos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar nombres de tablas
            modelBuilder.Entity<Cliente>().ToTable("clientes"); // 🚨 Nombre exacto de la tabla
            modelBuilder.Entity<Models.Pago>().ToTable("pagos");
            modelBuilder.Entity<DetallePago>().ToTable("detalle_pagos");
            modelBuilder.Entity<Producto>().ToTable("producto");
            modelBuilder.Entity<Categoria>().ToTable("categorias");
            modelBuilder.Entity<Empresa>().ToTable("empresas");

            // Configuraciones de relaciones
            modelBuilder.Entity<Models.DetallePago>(entity =>
            {
                // Mapear columnas
                entity.Property(v => v.PagoId).HasColumnName("pago_id"); // 🚨 Nombre real en DB

                // Relación con Pago
                entity.HasOne(v => v.Pago)
                      .WithMany()
                      .HasForeignKey(v => v.PagoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                // Mapear columnas
                entity.Property(v => v.ClienteId).HasColumnName("cliente_id"); // 🚨 Nombre real en DB

                // Relación con Pago
                entity.HasOne(v => v.Cliente)
                      .WithMany()
                      .HasForeignKey(v => v.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });






        }
    }
}
