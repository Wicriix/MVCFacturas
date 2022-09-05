
using MVCFacturas.Entities;
using MVCFacturas.ExternalConnections.GenericRepository;
using MVCFacturas.GenericResponseNameSpace;
using System;
using System.Threading.Tasks;
using MVCFacturas.Entities.Utilities.Transforms;
using Microsoft.AspNetCore.Mvc;

namespace MVCFacturas.Services
{
    public class TiposDePagoService
    {
        private readonly IGenericRepository<TiposDePago> TiposDePagorepository;
        public TiposDePagoService(IGenericRepository<TiposDePago> tiposDePagorepository)
        {
            TiposDePagorepository = tiposDePagorepository;
        }


        public async Task<GenericResponse> GetById(long id)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                TiposDePago result = await TiposDePagorepository.GetById(id) ?? new TiposDePago();
                if (result.IdTipoDePago > 0)
                {
                    apiResponse.ObjectResponse = result;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.SuccessMessage = "No se obtuvieron resultados";

                }
                apiResponse.OperationSucess = true;
            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;

        }

        public async Task<GenericResponse> GetTiposDePago()
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                apiResponse.ObjectResponse = await TiposDePagorepository.GetAll();
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

        public async Task<GenericResponse> EditarAsync(TiposDePago tipopago)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(tipopago.TipodePago))
                {
                    apiResponse.ObjectResponse = await TiposDePagorepository.UpdateAsync(tipopago);
                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el Tipo de pago no puede ser nulo o vacio";
                }

            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;
        }
        public async Task<GenericResponse> CrearAsync(TiposDePago tipopago)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(tipopago.TipodePago))
                {
                    tipopago.IdTipoDePago = 0;
                    apiResponse.ObjectResponse = await TiposDePagorepository.AddAsync(tipopago);
                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el Tipo de pago no puede ser nulo o vacio";
                }

            }
            catch (Exception ex)
            {
                apiResponse.OperationSucess = false;
                apiResponse.ErrorMessage = $"Algo malo sucedio y no se obtuvieron resultados - {ex.Message ?? string.Empty}";
            }
            return apiResponse;
        }

        public async Task<GenericResponse> DeleteAsync(TiposDePago tipopago)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(tipopago.TipodePago))
                {

                    apiResponse.ObjectResponse = await TiposDePagorepository.DeleteAsync(tipopago);
                    apiResponse.OperationSucess = true;
                    apiResponse.SuccessMessage = "operacion Exitosa";
                }
                else
                {
                    apiResponse.OperationSucess = false;
                    apiResponse.ErrorMessage = $"el Tipo de pago no puede ser nulo o vacio";
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
