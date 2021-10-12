using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IVehicleService
    {
        Task<List<VehicleDetailsDto>> GetAllVehicles(CancellationToken cancellationToken, PagingParameters pagingParameter = null);
        void UpdateVehicle(CancellationToken cancellationToken, VehicleDetailsDto vehicleDetailsDto);
        Task<IdValidationCodes> ValidateId(CancellationToken cancellationToken, int id);
        Task<ExecutionError> CheckforIdError(CancellationToken cancellationToken, int id);
    }
}
