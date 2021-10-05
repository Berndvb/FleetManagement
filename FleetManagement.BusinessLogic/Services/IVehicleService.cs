using FleetManagement.Framework.Models.Dtos;

namespace FleetManagement.BLL.Services
{
    public interface IVehicleService
    {
        void UpdateVehicle(VehicleDto vehicleDto);
        void UpdateVehicle(VehicleDetailsDto vehicleDetailsDto);
    }
}
