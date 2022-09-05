
using MVCFacturas.ExternalConnections.DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities
{
    public class Facturas : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdFacturas { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public string TipodePago { get; set; }
        public string DocumentoCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal Subtotal { get; set; }
        public string Descuento { get; set; }
        public string IVA { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal Total { get; set; }

    }
}
