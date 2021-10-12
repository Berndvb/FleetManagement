using FleetManagement.Framework.Models.Dtos;
using FleetManagement.Framework.Models.Dtos.ReadDtos;
using FleetManagement.Framework.Models.Dtos.WriteDtos;
using FleetManagement.Framework.Models.WriteDtos;
using System.Threading;

namespace FleetManagement.BLL.Services
{
    public interface IDriverVehicleService
    {
        void UpdateDriverVehicle(CancellationToken cancellationToken, DriverVehicleDto driverVehicleDto);
        void AddDriverVehicle(CancellationToken cancellationToken, AddDriverVehicleDto driverVehicleDto);
    }
}
