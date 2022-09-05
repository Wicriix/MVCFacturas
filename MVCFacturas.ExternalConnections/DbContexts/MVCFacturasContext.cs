using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCFacturas.Entities;

namespace MVCFacturas.ExternalConnections.DbContexts
{
    public class MVCFacturasContext : DbContext
    {
        public MVCFacturasContext(DbContextOptions<MVCFacturasContext> options) : base (options)
        {

        }

        DbSet<Facturas> Facturas { get; set; }
        DbSet<Detalles> Detalles { get; set; }
        DbSet<Productos> Productos { get; set; }
        DbSet<TiposDePago> TiposDePagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Facturas>(entity =>
            {
                entity.Property(e => e.NombreCliente)
                .IsRequired()
                .HasMaxLength(50);
               
                entity.Property(e => e.TipodePago)
                .IsRequired()
                .HasMaxLength(50);


                entity.Property(e => e.Descuento)
                .IsRequired()
                .HasMaxLength(50);


                entity.Property(e => e.IVA)
                .IsRequired()
                .HasMaxLength(50);


                entity.Property(e => e.TipodePago)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Fecha)
                .HasColumnType("datetime");
                
            });
            modelBuilder.Entity<Detalles>();
            modelBuilder.Entity<Productos>(entity =>
            {
                entity.Property(p => p.Producto).HasMaxLength(50);
            });
            modelBuilder.Entity<TiposDePago>(entity =>
            {
                entity.Property(p => p.TipodePago).HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
