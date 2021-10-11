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
        Task<DriverDetailsDto> GetDriverDetails(string driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(string driverId, PagingParameters pagingParameter = null);
        Task<List<VehicleDetailsDto>> GetVehicleInfoForDriver(string driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriver(string driverId, PagingParameters pagingParameter = null);
        Task<List<AppealDto>> GetAppealsForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null);
        Task<List<MaintenanceDto>> GetMaintenancesForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null);
        Task<List<RepareDto>> GetRepairsForDriverPerCar(string driverId, string vehicleId, PagingParameters pagingParameter = null);
        void UpdateDriver(DriverDetailsDto driverDto);
        void AddDriver(AddDriverDto driverDto);
        void RemoveDriver(DriverDetailsDto driverDto);
        void RemoveDriver(string driverId);
        Task<IdValidationCodes> ValidateId(int id);
        Task<ExecutionError> CheckforIdError(string driverId);

    }
}
