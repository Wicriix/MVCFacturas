using Microsoft.AspNetCore.Mvc;
using MVCFacturas.Services;
using MVCFacturas.GenericResponseNameSpace;
using System;
using System.Threading.Tasks;
using MVCFacturas.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MVCFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TiposDePagoController : ControllerBase
    {
        private readonly TiposDePagoService TiposDePagoService;

        public TiposDePagoController(TiposDePagoService tiposDePagoService)
        {
            TiposDePagoService = tiposDePagoService;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult> getById([FromRoute] int id)
        {
            try
            {
                return Ok(await TiposDePagoService.GetById(id).ConfigureAwait(false));
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
        [Route("All")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await TiposDePagoService.GetTiposDePago().ConfigureAwait(false));
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
        public async Task<ActionResult> Crear([FromBody] TiposDePago tiposDePago)
        {
            try
            {
                return Ok(await TiposDePagoService.CrearAsync(tiposDePago).ConfigureAwait(false));
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
        public async Task<ActionResult> Delete([FromBody] TiposDePago tiposDePago)
        {
            try
            {
                return Ok(await TiposDePagoService.DeleteAsync(tiposDePago).ConfigureAwait(false));
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
        public async Task<ActionResult> Editar([FromBody] TiposDePago tiposDePago)
        {
            try
            {
                return Ok(await TiposDePagoService.EditarAsync(tiposDePago).ConfigureAwait(false));
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
