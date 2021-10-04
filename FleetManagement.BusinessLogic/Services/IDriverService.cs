using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ShowDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverService
    {
        Task<List<DriverOverviewDto>> GetAllDriverOverviews(bool onlyInService);
        Task<DriverDetailsDto> GetDriverDetails(int driverId);
        Task<List<FuelCardDto>> GetFuelCardDetailsForDriver(int driverId);
        Task<List<AppealDto>> GetAllAppealsForDriver(int driverId);
        Task<List<VehicleAppealDto>> GetAppealsForDriverPerCar(int driverId, int vehicleId);
        void UpdateDriver(DriverDetailsDto driverDto);
        void AddDriver(DriverDto driverDto);
        void RemoveDriver(DriverDto driverDto);
        void RemoveDriver(int driverId);
    }
}
