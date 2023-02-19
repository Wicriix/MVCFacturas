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
        DbSet<BaxterMachine> BaxterMachines { get; set; }
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


            modelBuilder.Entity<BaxterMachine>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddressNumber).HasColumnName("Address Number");

                entity.Property(e => e.AddressNumber4)
                    .HasMaxLength(255)
                    .HasColumnName("Address Number4");

                entity.Property(e => e.AssetNumber).HasColumnName("Asset Number");

                entity.Property(e => e.BusinessPurpose)
                    .HasMaxLength(255)
                    .HasColumnName("Business Purpose");

                entity.Property(e => e.BusinessUnit)
                    .HasMaxLength(255)
                    .HasColumnName("Business Unit");

                entity.Property(e => e.Ctry)
                    .HasMaxLength(255)
                    .HasColumnName("Ctry ");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("datetime")
                    .HasColumnName("Date Updated");

                entity.Property(e => e.DivSubDiv)
                    .HasMaxLength(255)
                    .HasColumnName("Div/ Sub-Div");

                entity.Property(e => e.DoTy)
                    .HasMaxLength(255)
                    .HasColumnName("Do Ty");

                entity.Property(e => e.DocCo)
                    .HasMaxLength(255)
                    .HasColumnName("Doc Co");

                entity.Property(e => e.DocumentNumber).HasColumnName("Document Number");

                entity.Property(e => e.DocumentType)
                    .HasMaxLength(255)
                    .HasColumnName("Document Type");

                entity.Property(e => e.GenericCode)
                    .HasMaxLength(255)
                    .HasColumnName("Generic Code");

                entity.Property(e => e.GenericCode2)
                    .HasMaxLength(255)
                    .HasColumnName("Generic Code2");

                entity.Property(e => e.LotSerialNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Lot Serial Number");

                entity.Property(e => e.OrTy)
                    .HasMaxLength(255)
                    .HasColumnName("Or Ty");

                entity.Property(e => e.OrderCo)
                    .HasMaxLength(255)
                    .HasColumnName("Order Co");

                entity.Property(e => e.OrderType)
                    .HasMaxLength(255)
                    .HasColumnName("Order Type");

                entity.Property(e => e.OwnershipFlag)
                    .HasMaxLength(255)
                    .HasColumnName("Ownership Flag");

                entity.Property(e => e.ShipReceiveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Ship/Receive Date");

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(255)
                    .HasColumnName("Ship To");

                entity.Property(e => e.SpecificCode)
                    .HasMaxLength(255)
                    .HasColumnName("Specific Code");

                entity.Property(e => e.SpecificCode3)
                    .HasMaxLength(255)
                    .HasColumnName("Specific Code3");

                entity.Property(e => e.UnitNumber)
                    .HasMaxLength(255)
                    .HasColumnName("Unit Number");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
