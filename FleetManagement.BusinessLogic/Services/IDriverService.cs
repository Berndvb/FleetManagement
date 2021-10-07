using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService);
        Task<DriverDetailsDto> GetDriverDetails(string driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(string driverId);
        Task<List<VehicleDetailsDto>> GetVehiclesForDriver(string driverId);
        Task<List<AppealDto>> GetAppealsForDriver(string driverId);
        Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(string driverId, string vehicleId);
        Task<List<VehicleMaintenanceDto>> GetMaintenancesForDriverPerCar(string driverId, string vehicleId);
        Task<List<VehicleRepareDto>> GetRepairsForDriverPerCar(string driverId, string vehicleId);
        void UpdateDriver(DriverDetailsDto driverDto);
        void AddDriver(DriverDto driverDto);
        void RemoveDriver(DriverDto driverDto);
        void RemoveDriver(string driverId);
        Task<IdValidationCodes> ValidateId(int id);
        Task<ExecutionError> CheckforIdError(string driverId);

    }
}
