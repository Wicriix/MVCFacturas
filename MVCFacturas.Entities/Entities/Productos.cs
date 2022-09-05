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
    public class Productos: EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdProducto{ get; set; }
        public string Producto { get; set; }
    }
}
