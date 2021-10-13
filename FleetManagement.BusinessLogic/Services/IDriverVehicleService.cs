using FleetManagement.BLL.Models.Dtos.ReadDtos;
using FleetManagement.BLL.Models.Dtos.WriteDtos;
using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public interface IDriverVehicleService
    {
        void UpdateDriverVehicle(CancellationToken cancellationToken, DriverVehicleDto driverVehicleDto);
        void AddDriverVehicle(CancellationToken cancellationToken, AddDriverVehicleDto driverVehicleDto);
        Task<ExecutionError> HasOtherActiveDriverVehicles(CancellationToken cancellationToken, int vehicleId, int driverId);
    }
}
