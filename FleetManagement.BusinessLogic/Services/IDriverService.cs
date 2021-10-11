using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService, PagingParameters pagingParameter = null);
        Task<DriverDetailsDto> GetDriverDetails(int driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(int driverId, PagingParameters pagingParameter = null);
        Task<List<VehicleDetailsDto>> GetVehicleInfoForDriver(int driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriver(int driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriverPerCar(int driverId, int vehicleId, PagingParameters pagingParameter = null);
        Task<List<MaintenanceDto>> GetMaintenancesForDriverPerCar(int driverId, int vehicleId, PagingParameters pagingParameter = null);
        Task<List<RepareDto>> GetRepairsForDriverPerCar(int driverId, int vehicleId, PagingParameters pagingParameter = null);
        void UpdateDriver(DriverDetailsDto driverDto);
        void AddDriver(AddDriverDto driverDto);
        void RemoveDriver(DriverDetailsDto driverDto);
        void RemoveDriver(int driverId);
        Task<IdValidationCodes> ValidateId(int id);
        Task<ExecutionError> CheckforIdError(int driverId);

    }
}
