using Microsoft.AspNetCore.Mvc;
using MVCFacturas.Services;
using MVCFacturas.GenericResponseNameSpace;
using System;
using System.Threading.Tasks;
using MVCFacturas.Entities;

namespace MVCFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService ProductosService;

        public ProductosController(ProductosService productosService)
        {
            ProductosService = productosService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await ProductosService.GetProductos().ConfigureAwait(false));
            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse
                {
                    OperationSucess = false,
                    ErrorMessage = $"Algo salio mal ------ {ex.Message ?? string.Empty}"
                });
            }
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult> getById([FromRoute] int id)
        {
            try
            {
                return Ok(await ProductosService.GetById(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse
                {
                    OperationSucess = false,
                    ErrorMessage = $"Algo salio mal ------ {ex.Message ?? string.Empty}"
                });
            }
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult> Crear([FromBody] Productos model)
        {
            try
            {
                return Ok(await ProductosService.CrearAsync(model).ConfigureAwait(false));
            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse
                {
                    OperationSucess = false,
                    ErrorMessage = $"Algo salio mal ------ {ex.Message ?? string.Empty}"
                });
            }
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> Delete([FromBody] Productos model)
        {
            try
            {
                return Ok(await ProductosService.DeleteAsync(model).ConfigureAwait(false));
            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse
                {
                    OperationSucess = false,
                    ErrorMessage = $"Algo salio mal ------ {ex.Message ?? string.Empty}"
                });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult> Editar([FromBody] Productos model)
        {
            try
            {
                return Ok(await ProductosService.EditarAsync(model).ConfigureAwait(false));
            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse
                {
                    OperationSucess = false,
                    ErrorMessage = $"Algo salio mal ------ {ex.Message ?? string.Empty}"
                });
            }
        }
    }
}
