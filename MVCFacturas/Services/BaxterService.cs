using MVCFacturas.Entities;
using MVCFacturas.Entities.Models;
using MVCFacturas.Entities.Specifications;
using MVCFacturas.Entities.ViewModels;
using MVCFacturas.ExternalConnections.GenericRepository;
using MVCFacturas.GenericResponseNameSpace;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MVCFacturas.Services
{
    public class BaxterService
    {
        private readonly IGenericRepository<BaxterMachine> _BaxterMachineRepository;

        public BaxterService(IGenericRepository<BaxterMachine> BaxterMachineRepository)
        {
            _BaxterMachineRepository= BaxterMachineRepository;
        }

        public async Task<GenericResponse> getbyDateAndCountry(string country, DateTime date)
        {
            GenericResponse apiResponse = new GenericResponse();
            try
            {
                List<BaxterMachine> result = (await _BaxterMachineRepository.GetAll()).Where(x=> x.Ctry.ToLower().Equals(country.ToLower()) && x.ShipReceiveDate == date).ToList() ;
                apiResponse.OperationSucess = true;
                apiResponse.ObjectResponse = result;
                apiResponse.SuccessMessage = "operacion Exitosa";
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
