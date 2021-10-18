using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetDriverOverviews(CancellationToken cancellationToken, bool onlyInService, PagingParameters pagingParameter = null);
        Task<DriverDetailsDto> GetDriverDetails(CancellationToken cancellationToken, int driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task<List<VehicleDetailsDto>> GetVehiclesForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task UpdateDriver(CancellationToken cancellationToken, AddDriverDetailsDto driverDto, int driverId);
        Task AddDriver(CancellationToken cancellationToken, AddDriverDetailsDto driverDto);
        Task RemoveDriverById(CancellationToken cancellationToken, int driverId);
        Task<ExecutionError> ValidateId(CancellationToken cancellationToken, int id);
    }
}
