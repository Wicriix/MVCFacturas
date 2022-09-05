using MVCFacturas.Entities;
using MVCFacturas.ExternalConnections.GenericRepository;
using MVCFacturas.GenericResponseNameSpace;
using System.Threading.Tasks;
using System;
using MVCFacturas.Entities.Utilities.Transforms;
using MVCFacturas.Entities.Specifications;
using MVCFacturas.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using MVCFacturas.Entities.ViewModels;

namespace MVCFacturas.Services
{
    public class FacturasService
    {
        private readonly IGenericRepository<Facturas> FacturasRepository;
        private readonly IGenericRepository<Detalles> DetalleRepository;
        public FacturasService(IGenericRepository<Facturas> facturasRepository,
            IGenericRepository<Detalles> detalleRepository)
        {
            FacturasRepository = facturasRepository;
            DetalleRepository = detalleRepository;
        }

        public async Task<GenericResponse> GetById(long id)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                FacturasViewModels result = (await FacturasRepository.GetById(id)).TransformToFacturasViewModels() ?? new FacturasViewModels();
                apiResponse.OperationSucess = true;

                if (result.IdFacturas > 0)
                {
                    List<ProductoModel> resultProductosFactura = (await DetalleRepository.ListSelectAsync(new DetallesSpecifications(id), x => new ProductoModel
                    {
                        Id = x.IdProducto,
                        Cantidad = x.Cantidad,
                        PrecioUnitario = x.PrecioUnitario,
                        Producto = x.ProductoNavigation.Producto,
                    })).ToList();

                    result.ProductosFactura = resultProductosFactura;
                    apiResponse.ObjectResponse = result;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.SuccessMessage = "No se obtuvieron resultados";
                }


            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;

        }

        public async Task<GenericResponse> GetFacturas()
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                apiResponse.ObjectResponse = (await FacturasRepository.GetAll()).TransformToFacturasViewModels();
                apiResponse.OperationSucess = true;
                apiResponse.SuccessMessage = "operacion Exitosa";
            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;


        }

        public async Task<GenericResponse> CrearAsync(FacturasViewModels model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {

                if (model != null)
                {
                    List<Detalles> ListDetalles = new List<Detalles>();
                    Facturas factura = new Facturas
                    {
                        IdFacturas = model.IdFacturas,
                        NumeroFactura = model.NumeroFactura.ToString(),
                        Fecha = model.Fecha,
                        NombreCliente = model.NombreCliente,
                        Total = model.Total,
                        DocumentoCliente = model.DocumentoCliente,
                        TipodePago = model.TipodePago,
                        Subtotal = model.Subtotal,
                        Descuento = model.Descuento.ToString() + "%",
                        IVA = model.IVA.ToString() + "%",
                        TotalDescuento = model.TotalDescuento,
                        TotalImpuesto = model.TotalImpuesto,
                    };

                    foreach (var item in model.ProductosFactura)
                    {
                        Detalles detalleToInsert = new Detalles();
                        detalleToInsert.IdProducto = item.Id;
                        detalleToInsert.PrecioUnitario = item.PrecioUnitario;
                        detalleToInsert.Cantidad = item.Cantidad;
                        detalleToInsert.FacturasNavigation = factura;

                        ListDetalles.Add(detalleToInsert);
                    }

                    apiResponse.ObjectResponse = await DetalleRepository.AddRangeAsync(ListDetalles);
                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el producto no puede ser nulo o vacio";
                }

            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;
        }


        public async Task<GenericResponse> EditarAsync(FacturasViewModels model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (model.IdFacturas > 0)
                {

                    List<Detalles> ListDetalles = new List<Detalles>();
                    List<Detalles> resultDetallesFactura = (await DetalleRepository.ListSelectAsync(new DetallesSpecifications(model.IdFacturas), x => x)).ToList();
                    await DetalleRepository.DeleteRangeAsync(resultDetallesFactura);

                    foreach (var item in model.ProductosFactura)
                    {
                        Detalles detalleToInsert = new Detalles();
                        detalleToInsert.IdProducto = item.Id;
                        detalleToInsert.PrecioUnitario = item.PrecioUnitario;
                        detalleToInsert.Cantidad = item.Cantidad;
                        detalleToInsert.IdFactura = model.IdFacturas;

                        ListDetalles.Add(detalleToInsert);
                    }

                    Facturas factura = new Facturas
                    {
                        IdFacturas = model.IdFacturas,
                        NumeroFactura = model.NumeroFactura.ToString(),
                        Fecha = model.Fecha,
                        NombreCliente = model.NombreCliente,
                        Total = model.Total,
                        DocumentoCliente = model.DocumentoCliente,
                        TipodePago = model.TipodePago,
                        Subtotal = model.Subtotal,
                        Descuento = model.Descuento.ToString() + "%",
                        IVA = model.IVA.ToString() + "%",
                        TotalDescuento = model.TotalDescuento,
                        TotalImpuesto = model.TotalImpuesto,
                    };

                    apiResponse.ObjectResponse = await FacturasRepository.UpdateAsync(factura);


                    apiResponse.ObjectResponse = await DetalleRepository.AddRangeAsync(ListDetalles);

                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el producto no puede ser nulo o vacio";
                }

            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;
        }


        public async Task<GenericResponse> DeleteAsync(FacturasViewModels model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (model.IdFacturas>0)
                {
                    Facturas factura = new Facturas
                    {
                        IdFacturas = model.IdFacturas,
                        NumeroFactura = model.NumeroFactura.ToString(),
                        Fecha = model.Fecha,
                        NombreCliente = model.NombreCliente,
                        Total = model.Total,
                        DocumentoCliente = model.DocumentoCliente,
                        TipodePago = model.TipodePago,
                        Subtotal = model.Subtotal,
                        Descuento = model.Descuento.ToString()+"%",
                        IVA = model.IVA.ToString()+"%",
                        TotalDescuento = model.TotalDescuento,
                        TotalImpuesto = model.TotalImpuesto,
                    };

                    apiResponse.ObjectResponse = await FacturasRepository.DeleteAsync(factura);
                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el producto no puede ser nulo o vacio";
                }

            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;
        }
    }
}
