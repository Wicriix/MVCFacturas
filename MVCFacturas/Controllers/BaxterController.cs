using Microsoft.AspNetCore.Mvc;
using MVCFacturas.GenericResponseNameSpace;
using MVCFacturas.Services;
using System.Threading.Tasks;
using System;
using MVCFacturas.Entities.ViewModels;

namespace MVCFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaxterController : ControllerBase
    {
        private readonly BaxterService baxterService;

        public BaxterController(BaxterService _BaxterService)
        {
            baxterService = _BaxterService;
        }


        [HttpGet]
        [Route("findInformationByDateAndCountry/{country}/{date}")]
        public async Task<ActionResult> GetAll(string country,  DateTime date)
        {
            try
            {
                return Ok(await baxterService.getbyDateAndCountry(country, date).ConfigureAwait(false));
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
        [Route("findInformationByDateAndCountryQuery")]
        public async Task<ActionResult> GetAllQuery([FromQuery]string country, [FromQuery] DateTime date)
        {
            try
            {
                return Ok(await baxterService.getbyDateAndCountry(country, date).ConfigureAwait(false));
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
        [Route("findInformationByDateAndCountryPost")]
        public async Task<ActionResult> GetAllQuery([FromBody] BaxterViewModel baxterViewModel)
        {
            try
            {
                return Ok(await baxterService.getbyDateAndCountry(baxterViewModel.country, baxterViewModel.date).ConfigureAwait(false));
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
