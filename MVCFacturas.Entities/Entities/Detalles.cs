using MVCFacturas.ExternalConnections.DbContexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities
{
    public class Detalles: EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdDetalle { get; set; }
        public long IdFactura { get; set; }
        public long IdProducto { get; set; }
        public long Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("IdFactura")]
        public virtual Facturas FacturasNavigation { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Productos ProductoNavigation { get; set; }

    }
}
