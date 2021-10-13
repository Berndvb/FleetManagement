using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using System.Threading;

namespace FleetManagement.BLL.Services
{
    public interface IDriverVehicleService
    {
        void UpdateDriverVehicle(CancellationToken cancellationToken, DriverVehicleDto driverVehicleDto);
        void AddDriverVehicle(CancellationToken cancellationToken, AddDriverVehicleDto driverVehicleDto);
    }
}
