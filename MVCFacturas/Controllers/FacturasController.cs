using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCFacturas.Entities;
using MVCFacturas.Entities.ViewModels;
using MVCFacturas.GenericResponseNameSpace;
using MVCFacturas.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacturasController : ControllerBase
    {
        private readonly FacturasService FacturasService;
        public FacturasController(FacturasService facturasService)
        {
            FacturasService = facturasService;
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult> getById([FromRoute] int id)
        {
            try
            {
                return Ok(await FacturasService.GetById(id).ConfigureAwait(false));
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
                return Ok(await FacturasService.GetFacturas().ConfigureAwait(false));
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
        public async Task<ActionResult> Crear([FromBody] FacturasViewModels model)
        {
            try
            {
                return Ok(await FacturasService.CrearAsync(model).ConfigureAwait(false));
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
        public async Task<ActionResult> Editar([FromBody] FacturasViewModels model)
        {
            try
            {
                return Ok(await FacturasService.EditarAsync(model).ConfigureAwait(false));
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
        public async Task<ActionResult> Delete([FromBody] FacturasViewModels model)
        {
            try
            {
                return Ok(await FacturasService.DeleteAsync(model).ConfigureAwait(false));
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
