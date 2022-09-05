using MVCFacturas.Entities.Models;
using MVCFacturas.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFacturas.Entities.Utilities.Transforms
{
    public static class FacturasTransform
    {

        public static IEnumerable<FacturasViewModels> TransformToFacturasViewModels(this IEnumerable<Facturas> model)
        {
            return model.Select(x=> new FacturasViewModels
            {
                IdFacturas = x.IdFacturas,
                NumeroFactura = long.Parse(x.NumeroFactura),
                Fecha = x.Fecha,
                NombreCliente = x.NombreCliente,
                Total = x.Total,
                DocumentoCliente = x.DocumentoCliente,
                TipodePago = x.TipodePago,
                Subtotal = x.Subtotal,
                Descuento = decimal.Parse(x.Descuento.Replace("%","")),
                IVA = decimal.Parse(x.IVA.Replace("%", "")),
                TotalDescuento = x.TotalDescuento,
                TotalImpuesto = x.TotalImpuesto,

            }).ToList();
        }

        public static FacturasViewModels TransformToFacturasViewModels(this Facturas model)
        {
            return  new FacturasViewModels
            {
                IdFacturas = model.IdFacturas,
                NumeroFactura = long.Parse(model.NumeroFactura),
                Fecha = model.Fecha,
                NombreCliente = model.NombreCliente,
                Total = model.Total,
                DocumentoCliente = model.DocumentoCliente,
                TipodePago = model.TipodePago,
                Subtotal =  model.Subtotal,
                Descuento = decimal.Parse(model.Descuento.Replace("%", "")),
                IVA = decimal.Parse(model.IVA.Replace("%", "")),
                TotalDescuento=model.TotalDescuento,
                TotalImpuesto = model.TotalImpuesto,

            };
        }


        //public static IEnumerable<FacturasViewModels> TransformToFacturasViewModels(this IEnumerable<Detalles> model)
        //{
        //    List<ProductoModel> ProductosFactura = new List<ProductoModel>();
        //    ProductosFactura = model.Select(x => new ProductoModel
        //    {
        //        Producto = x.ProductoNavigation.Producto,
        //        Cantidad = x.Cantidad,
        //        PrecioUnitario = x.PrecioUnitario

        //    }).ToList();
        //    List<FacturasViewModels> resp = model.Select(x => new FacturasViewModels
        //    {
        //        IdFacturas = x.FacturasNavigation.IdFacturas,
        //        NumeroFactura = x.FacturasNavigation.NumeroFactura,
        //        Fecha = x.FacturasNavigation.Fecha,
        //        NombreCliente = x.FacturasNavigation.NombreCliente,
        //        Total = x.FacturasNavigation.Total,
        //    }).ToList();

        //    return resp;
        //}
    }
}
