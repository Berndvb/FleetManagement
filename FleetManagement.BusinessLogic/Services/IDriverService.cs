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
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetDriverOverviews(CancellationToken cancellationToken, bool onlyInService, PagingParameters pagingParameter = null);
        Task<DriverDetailsDto> GetDriverDetails(CancellationToken cancellationToken, int driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task<List<VehicleDetailsDto>> GetVehicleInfoForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriver(CancellationToken cancellationToken, int driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriverPerCar(CancellationToken cancellationToken, int driverId, int vehicleId, PagingParameters pagingParameter = null);
        Task<List<MaintenanceDto>> GetMaintenancesForDriverPerCar(CancellationToken cancellationToken, int driverId, int vehicleId, PagingParameters pagingParameter = null);
        Task<List<RepareDto>> GetRepairsForDriverPerCar(CancellationToken cancellationToken, int driverId, int vehicleId, PagingParameters pagingParameter = null);
        void UpdateDriver(CancellationToken cancellationToken, DriverDetailsDto driverDto);
        Task AddDriver(CancellationToken cancellationToken, AddDriverDetailsDto driverDto);
        void RemoveDriverById(CancellationToken cancellationToken, int driverId);
        Task<IdValidationCodes> ValidateId(CancellationToken cancellationToken, int id);
        Task<ExecutionError> CheckforIdError(CancellationToken cancellationToken, int driverId);
    }
}
