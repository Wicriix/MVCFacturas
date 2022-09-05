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
    public class TiposDePago: EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdTipoDePago { get; set; }
        public string TipodePago { get; set; }
    }
}
