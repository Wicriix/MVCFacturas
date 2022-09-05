using MVCFacturas.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities.ViewModels
{
    public class FacturasViewModels
    {
        public long IdFacturas { get; set; }
        [Required(ErrorMessage = "El numero de factura es requerido")]
        [RegularExpression("^\\d+$", ErrorMessage = "solo se permiten Numeros de facturas positivos")]
        public long NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El tipo de pago es requerido")]

        public string TipodePago { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es requerido")]

        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El numero de factura es requerido")]
        public string DocumentoCliente { get; set; }
        public decimal Subtotal { get; set; }
        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "solo se permiten Descuento positivos")]
        public decimal Descuento { get; set; }
        [RegularExpression("^[0-9]+([,][0-9]+)?$", ErrorMessage = "solo se permiten valor IVA positivo")]
        public decimal IVA { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal Total { get; set; }
        [Required(ErrorMessage = "Debe haber al menos un Producto")]
        public List<ProductoModel> ProductosFactura { get; set; } = new List<ProductoModel>();

    }
}
