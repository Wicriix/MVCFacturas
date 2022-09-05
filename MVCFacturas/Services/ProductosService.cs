using MVCFacturas.Entities;
using MVCFacturas.ExternalConnections.GenericRepository;
using MVCFacturas.GenericResponseNameSpace;
using System.Threading.Tasks;
using System;

namespace MVCFacturas.Services
{
    public class ProductosService
    {
        private readonly IGenericRepository<Productos> ProductosRepository;
        public ProductosService(IGenericRepository<Productos> productosRepository)
        {
            ProductosRepository = productosRepository;
        }
        public async Task<GenericResponse> GetById(long id)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                Productos result = await ProductosRepository.GetById(id) ?? new Productos();

                if (result.IdProducto > 0)
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
        public async Task<GenericResponse> GetProductos()
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                apiResponse.ObjectResponse = await ProductosRepository.GetAll();
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

        public async Task<GenericResponse> EditarAsync(Productos model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(model.Producto))
                {
                    apiResponse.ObjectResponse = await ProductosRepository.UpdateAsync(model);
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
        public async Task<GenericResponse> CrearAsync(Productos model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(model.Producto))
                {
                    model.IdProducto = 0;
                    apiResponse.ObjectResponse = await ProductosRepository.AddAsync(model);
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

        public async Task<GenericResponse> DeleteAsync(Productos model)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                if (!string.IsNullOrEmpty(model.Producto))
                {

                    apiResponse.ObjectResponse = await ProductosRepository.DeleteAsync(model);
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
