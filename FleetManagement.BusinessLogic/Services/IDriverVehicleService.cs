using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Models.WriteDtos;

namespace FleetManagement.BLL.Services
{
    public interface IDriverVehicleService
    {
        void UpdateDriverVehicle(DriverVehicleDto driverVehicleDto);
        void AddDriverVehicle(AddDriverVehicleDto driverVehicleDto);
    }
}
