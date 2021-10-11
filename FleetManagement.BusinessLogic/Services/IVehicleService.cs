using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleDetailsDto>> GetAllVehicles(PagingParameters pagingParameter = null);
        void UpdateVehicle(VehicleDetailsDto vehicleDetailsDto);
        Task<IdValidationCodes> ValidateId(int id);
        Task<ExecutionError> CheckforIdError(int id);
    }
}
