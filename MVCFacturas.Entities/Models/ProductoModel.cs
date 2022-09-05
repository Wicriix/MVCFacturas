using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities.Models
{
    public class ProductoModel
    {
        public long Id { get; set; }
        public string Producto { get; set; }
        [RegularExpression("^\\d+$", ErrorMessage = "solo se permiten cantidades positivas")]
        public long Cantidad { get; set; }

        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "solo se permiten Precios Unitarios positivos")]
        public decimal PrecioUnitario { get; set; }

    }
}
