using FleetManagement.BLL.Services.Model;
using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetDriverOverviews(bool onlyInService);
        Task<DriverDetailsDto> GetDriverDetails(int driverId);
        Task<List<FuelCardDto>> GetFuelCardsForDriver(int driverId);
        Task<List<VehicleDetailsDto>> GetVehiclesForDriver(int driverId);
        Task<List<AppealDto>> GetAppealsForDriver(int driverId);
        Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(int driverId, int vehicleId);
        Task<List<VehicleMaintenanceDto>> GetMaintenancesForDriverPerCar(int driverId, int vehicleId);
        Task<List<VehicleRepareDto>> GetRepairsForDriverPerCar(int driverId, int vehicleId);
        void UpdateDriver(DriverDetailsDto driverDto);
        void AddDriver(DriverDto driverDto);
        void RemoveDriver(DriverDto driverDto);
        void RemoveDriver(int driverId);
        Task<InputValidationCodes> DriverIdIsUnique(int id);
    }
}
