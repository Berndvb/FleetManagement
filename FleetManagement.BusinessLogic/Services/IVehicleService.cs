using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.BLL.Services.Models;
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
        Task UpdateVehicle(CancellationToken cancellationToken, VehicleDetailsDto vehicleDetailsDto);
        Task AddVehicle(CancellationToken cancellationToken, AddVehicleDetailsDto addVehicleDto);
        Task<InputValidationCodes> ValidateId(CancellationToken cancellationToken, int id);
        Task<ExecutionError> CheckforIdError(CancellationToken cancellationToken, int id);
    }
}
